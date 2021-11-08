using CollegeImport.TimetableDataSetTableAdapters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebData;

namespace CollegeImport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            SendOverHTTP();
            //new DBUpdater().Update();
        }

        private void SendOverHTTP()
        {
            SPGRUPTableAdapter GroupAdapter = new SPGRUPTableAdapter();
            var maxCourse = GroupAdapter.GetData().Max(x => x.KURS);
            List<JClassGroup> StreamList = new List<JClassGroup>();
            for (int i = 1; i <= maxCourse; i++)
            {
                StreamList.Add(new JClassGroup() { ID = i, Name = $"{i} курс", SortValue = i });
            }
            var GroupList = GroupAdapter.GetData().Select(x => new JClass() { ID = x.IDG, ClassGroupID = x.KURS, Name = x.NAIM }).ToList();

            SPPREPTableAdapter TeacherAdapter = new SPPREPTableAdapter();
            var TeacherList = TeacherAdapter.GetData()
                .Select(x => new JTeacher()
                {
                    ID = x.IDP,
                    FirstName = new SmartFioCreator().ParseLongFio(x.FAMIO).FirstName,
                    LastName = new SmartFioCreator().ParseLongFio(x.FAMIO).LastName,
                    MiddleName = new SmartFioCreator().ParseLongFio(x.FAMIO).MiddleName
                }).ToList();

            SPKAUDTableAdapter RoomAdapter = new SPKAUDTableAdapter();
            var RoomList = RoomAdapter.GetData().Select(x => new JClassRoom() { ID = x.IDA, Name = x.KAUDI }).ToList();

            SPPREDTableAdapter SubjectAdapter = new SPPREDTableAdapter();
            var SubjectList = SubjectAdapter.GetData().Select(x => new JSubject() { ID = x.IDD, Name = x.NAIM }).ToList();

            UROKITableAdapter TimeTableAdapter = new UROKITableAdapter();

            List<JLessonTime> TimesList = new List<JLessonTime>();
            var maxLesson = TimeTableAdapter.GetData().Max(x => x.UR);
            var startTime = DateTime.Parse("08:00");
            for (int u = 1; u <= maxLesson; u++)
            {
                TimesList.Add(new JLessonTime()
                {
                    ID = u,
                    TimeBegin = startTime.AddHours(u - 1),
                    TimeEnd = startTime.AddHours(u - 1).AddMinutes(50)
                });
            }


            int diff = GetDayOfWeek(DateTime.Now) == 7 ? +1 : -GetDayOfWeek(DateTime.Now) + 1;

            var startDate = DateTime.Now.AddDays(diff);
            var endDate = startDate.AddDays(7);

            var tabsList = TimeTableAdapter.GetData()
                           .Where(t => t.DAT >= new DateTime(startDate.Year, startDate.Month, startDate.Day) 
                                && t.DAT < new DateTime(endDate.Year, endDate.Month, endDate.Day))
                           .GroupBy(x => new { x.IDG, x.IDA, x.IDD, x.UR, x.IDP }).ToList();

            var TimeTableList = new List<JTimeTable>();
            int idx = 0;
            foreach (var tab in tabsList)
            {
                var days = tab.Select(x => GetDayOfWeek(x.DAT)).Distinct().ToList();
                days.ForEach(d =>
                {
                    var x = new JTimeTable()
                    {
                        ID = idx++,
                        DateFrom = new DateTime(startDate.Year, startDate.Month, startDate.Day),
                        DateTo = new DateTime(startDate.Year, startDate.Month, startDate.Day).AddDays(30),
                        ClassID = tab.Key.IDG,
                        ClassroomID = tab.Key.IDA,
                        SubjectID = tab.Key.IDD,
                        LessonTimeID = tab.Key.UR,
                        TeacherID = tab.Key.IDP,
                        DayOfWeek = d
                    };
                    TimeTableList.Add(x);
                });
            }

            Transfer trans = new Transfer()
            {
                Times = TimesList,
                ClassGroups = StreamList,
                Classes = GroupList,
                Teachers = TeacherList,
                ClassRooms = RoomList,
                Subjects = SubjectList,
                TimeTables = TimeTableList
            };

            Task.Run(async () =>
            {
                await SendDataAsync(trans);
            });

        }

        async Task SendDataAsync(Transfer trans)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();

                string json = JsonConvert.SerializeObject(trans, Formatting.Indented);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                string addr = Properties.Settings.Default.ServerAddress;

                string url = $"http://{addr}/api/jimport/load";

                form.Add(new ByteArrayContent(byteArray, 0, byteArray.Length), "data", "data");

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = form;
                HttpResponseMessage response = await httpClient.PostAsync(url, form);

                using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    while (!reader.EndOfStream)
                    {
                        Debug.WriteLine(reader.ReadLine());
                    }
                }

                Dispatcher.Invoke(() => {
                    MessageBox.Show(this, "Загрузка завершена!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }

        }

        int GetDayOfWeek(DateTime date)
        {
            int dayNum = (Int32)date.DayOfWeek == 0 ? 7 : (Int32)date.DayOfWeek;

            return dayNum;
        }
    }
}

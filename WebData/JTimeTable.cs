namespace WebData
{
    using System;
    using System.Collections.Generic;
    
    public partial class JTimeTable
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public short RegularSubject { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DayOfWeek { get; set; }
        public int? SubjectID { get; set; }
        public int? SubjectTypeID { get; set; }
        public int? LessonTimeID { get; set; }
        public int? TeacherID { get; set; }
        public int? ClassroomID { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int? SortValue { get; set; }
        public string ExternalId { get; set; }
        public DateTime? updated { get; set; }
        public int? WeekType { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }


        // Этого нет в БД
        public int LessonOfDay { get; set; }

    }
}

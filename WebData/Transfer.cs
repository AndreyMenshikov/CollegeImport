using System.Collections.Generic;

namespace WebData
{
    public class Transfer
    {
        public List<JLessonTime> Times { get; set; }
        public List<JTeacher> Teachers { get; set; }
        public List<JClassRoom> ClassRooms { get; set; }
        public List<JSubject> Subjects { get; set; }
        public List<JClass> Classes { get; set; }
        public List<JTimeTable> TimeTables { get; set; }
        public List<JSetting> Settings { get; set; }
        public List<JClassGroup> ClassGroups { get; set; }
        public List<JMultimediaItem> MultimediaItems { get; set; }
        public List<JMessage> Messages { get; set; }
        public List<JSubjectType> SubjectTypes { get; set; }
        public List<JOwnerInfo> OwnerInfos { get; set; }
        public List<JColorSetting> ColorSettings { get; set; }
    }

}
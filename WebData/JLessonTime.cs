namespace WebData
{
    using System;
    using System.Collections.Generic;
    
    public partial class JLessonTime
    {
        public int ID { get; set; }
        public DateTime? TimeBegin { get; set; }
        public DateTime? TimeEnd { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int? SortValue { get; set; }
        public bool? IsSecondShift { get; set; }
        public string ExternalId { get; set; }
        public DateTime? updated { get; set; }
        public bool? RestTime { get; set; }
    }
}

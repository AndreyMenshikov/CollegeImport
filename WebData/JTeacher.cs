namespace WebData
{
    using System;
    using System.Collections.Generic;
    
    public partial class JTeacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int? SortValue { get; set; }
        public string JobSubject { get; set; }
        public string JobName { get; set; }
        public string JobStage { get; set; }
        public string EmailAddress { get; set; }
        public string ExternalId { get; set; }
        public DateTime? updated { get; set; }
    }
}

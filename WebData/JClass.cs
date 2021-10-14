namespace WebData
{
    using System;
    using System.Collections.Generic;
    
    public partial class JClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int? SortValue { get; set; }
        public int? ClassGroupID { get; set; }
        public int? Color { get; set; }
        public string ExternalId { get; set; }
        public DateTime? updated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData
{
    public class JMultimediaItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PanelCode { get; set; }
        public string Description { get; set; }
        public int? SortValue { get; set; }
        public int? MediaType { get; set; }
    }
}

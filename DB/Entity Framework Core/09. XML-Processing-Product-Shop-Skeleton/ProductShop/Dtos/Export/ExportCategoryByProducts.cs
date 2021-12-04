using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
   public class ExportCategoryByProducts
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlElement("averagePrice")]
        public decimal Average { get; set; }
        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}

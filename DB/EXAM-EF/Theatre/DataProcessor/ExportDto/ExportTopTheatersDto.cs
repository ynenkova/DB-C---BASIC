using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.DataProcessor.ExportDto
{
  public  class ExportTopTheatersDto
    {
        public string Name { get; set; }
        public sbyte Halls { get; set; }
        public decimal TotalIncome { get; set; }
        public List<ExportTickets> Tickets { get; set; }


    }
    public class ExportTickets
    {
        public decimal Price { get; set; }
        public sbyte RowNumber { get; set; }
    }
}

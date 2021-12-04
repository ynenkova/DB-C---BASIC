using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
  public  class ImportProjectionsDto
    {
        
        [Required]
        [StringLength(30,MinimumLength =4)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(sbyte),"1","10")]
        public sbyte NumberOfHalls { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }
        public ICollection<ImportTicketDto> Tickets { get; set; }
    }
    public class ImportTicketDto
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }
        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }
        [Required]
        [ForeignKey("PlayId")]
        public int PlayId { get; set; }
    }

}

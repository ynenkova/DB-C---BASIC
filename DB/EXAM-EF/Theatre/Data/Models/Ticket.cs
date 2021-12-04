using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
   public class Ticket
    {
       
      
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public sbyte RowNumber { get; set; }
        [Required]
        [ForeignKey("PlayId")]
        public int PlayId { get; set; }
        public Play Play { get; set; }
        [Required]
        [ForeignKey("TheatreId")]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}

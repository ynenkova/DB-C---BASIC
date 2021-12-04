using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
   public class Cast
    {


        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public Boolean IsMainCharacter { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [ForeignKey("PlayId")]
        public int PlayId { get; set; }
        public Play Play { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
   public class ImportCastDto
    {
        [Required]
        [StringLength(30,MinimumLength =4)]
        public string FullName { get; set; }
        [Required]
        public Boolean IsMainCharacter { get; set; }
        [Required]
        [RegularExpression(@"^\+44-\d{2}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }
        [Required]
        [ForeignKey("PlayId")]
        public int PlayId { get; set; }
    }
}

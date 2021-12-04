﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
   public class ImportPlaysDto
    {
        //•	Duration – TimeSpan in format {hours:minutes:seconds
        //    }, with a minimum length of 1 hour. (required)
       
        [Required]
        [StringLength(50,MinimumLength =4)]
        [XmlElement("Title")]
        public string Title { get; set; }
        [Required]
        [Timestamp()]
       
        [XmlElement("Duration")]
        public string Duration { get; set; }
        [Required]
        [Range(typeof(float),"0.00","10.00")]
        [XmlElement("Rating")]
        public float Rating { get; set; }
        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [Required]
        [StringLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}

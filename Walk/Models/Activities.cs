using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Activities
    {
        
        [MaxLength(120)]
        [MinLength(3)]
        [Required]
        public string ActivityName { get; set; }
        [Required]
        public double Distance { get; set; }
        public DateTime Date { get; set; }
        public Member Participant { get; set; }
        [Key]
        public int ActivityId { get; set; }
    }
}
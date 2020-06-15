using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [MinLength(2)]
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2)]
        public string WedderTwo { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(6)]
        public string Address { get; set; }

        public int UserId { get; set; }

        public User Creator { get; set; }

        public List<Attending> Attendees { get; set;}
    }
}
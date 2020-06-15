using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Attending
    {
        [Key]
        public int AttendingId { get; set; }

        public int UserId { get; set; }

        public int WeddingId { get; set; }

        public User Attendee { get; set; }

        public Wedding Wedding { get; set; }
    }
}
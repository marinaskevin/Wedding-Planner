using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class RSVP : BaseEntity
    {
        public int RSVPid { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public RSVP()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
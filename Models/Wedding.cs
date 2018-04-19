using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        
        [Required(ErrorMessage = "Name of future newlywed is missing!")]
        [MinLength(2)]
        [Display(Name="Wedder One")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "Name of future newlywed is missing!")]
        [MinLength(2)]
        [Display(Name="Wedder Two")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "Please select the start date of the wedding.")]
        [Display(Name="Date")]
        [CurrentDate(ErrorMessage = "The scheduled wedding must be on or after today's date.")]
        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Where will it happen?")]
        [MinLength(2)]        
        [Display(Name="Address")]
        public string WeddingAddress { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<RSVP> Guests { get; set; }

        public Wedding()
        {
            this.CreatedAt = DateTime.Now;
            this.Guests = new List<RSVP>();
        }
    }
}
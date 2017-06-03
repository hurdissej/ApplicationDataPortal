using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDataPortal.Core.Models
{
    public class DisplayTypes
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }


    }
}
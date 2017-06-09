using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDataPortal.Core.Models
{
    public class DisplayTypes
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Range(1,5)]
        public int GlobalDisplayTypeRef { get; set; }


    }
}
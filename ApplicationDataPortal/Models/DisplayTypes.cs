using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationDataPortal.Models
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
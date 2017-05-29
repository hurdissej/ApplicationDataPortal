using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationDataPortal.Dtos
{
    public class DisplayTypeDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public CustomersDto Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
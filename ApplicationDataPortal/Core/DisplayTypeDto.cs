using System;

namespace ApplicationDataPortal.Core
{
    public class DisplayTypeDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public CustomersDto Customer { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
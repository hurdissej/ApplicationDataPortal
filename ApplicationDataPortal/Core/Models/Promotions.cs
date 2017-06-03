using System;

namespace ApplicationDataPortal.Core.Models
{
    public class Promotions
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DisplayTypes DisplayTypes { get; set; }
        public int DisplayTypesId { get; set; }
       
    }
}
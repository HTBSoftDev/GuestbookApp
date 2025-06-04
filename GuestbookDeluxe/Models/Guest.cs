using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestbookDeluxe.Models
{
    public class Guest
    {

        public string Name { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime Timeregistered { get; set; } = DateTime.Now;
        public string? Comment { get; set; }
    }
}

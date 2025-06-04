using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestbookDeluxe.Models;

namespace GuestbookDeluxe.Services
{
    public class GuestBook
    {

        private List<Guest> guests = new();

        public void AddGuest(Guest guest)
        {
            guests.Add(guest);
        }


        public void ShowAllGuests()
        {
            if (guests.Count == 0)
            {
                Console.WriteLine("Ingen gæster er registreret endnu.");
                return;
            }

            Console.Clear();    
            Console.WriteLine("Liste over gæster:");
            foreach (Guest guest in guests)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{guest.Name} ({guest.NumberOfGuests} personer) - {guest.Timeregistered:g}");
                Console.ResetColor();
                if (!string.IsNullOrWhiteSpace(guest.Comment))
                {
                    Console.WriteLine($"  Kommentar: {guest.Comment}");
                }
            }
        }
    }
}

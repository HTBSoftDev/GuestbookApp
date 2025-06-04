using GuestbookDeluxe.Models;
using GuestbookDeluxe.Services;

namespace GuestbookDeluxe
{
    internal class Program
    {
        static int ReadIntFromUser(string prompt)
        {
            int result;
            Console.Write(prompt);
            string? input = Console.ReadLine();

            while (!int.TryParse(input, out result))
            {
                Console.Write($"Ugyldigt tal. Prøv igen: ");
                input = Console.ReadLine();
            }
            return result;
        }
        static void Main(string[] args)
        {

            GuestBook guestBook = new();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\n--- Gæstebog Deluxe ---");
                Console.WriteLine("1. Tilføj gæst");
                Console.WriteLine("2. Vis alle gæster");
                Console.WriteLine("3. Afslut");
                Console.Write("Vælg en mulighed: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        Console.Write("Navn på gæst: ");
                        string? name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Navn må ikke være tomt.");
                            Console.ResetColor();
                            continue;
                        }
                        int numberOfGuests = ReadIntFromUser("Antal personer: ");

                        Console.Write("Evt. kommentar: ");
                        string? comment = Console.ReadLine();

                        var guest = new Guest()
                        {
                            Name = name,
                            NumberOfGuests = numberOfGuests,
                            Comment = comment
                        };

                        guestBook.AddGuest(guest);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Gæst tilføjet!...");
                        Console.ResetColor();

                        Thread.Sleep(2000);

                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine();
                        guestBook.ShowAllGuests();
                        break;

                    case "3":
                        Console.WriteLine();
                        keepRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ResetColor();

                        break;
                }
            }
            Console.ReadLine();
        }
    }
}

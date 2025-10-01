using System;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();

        while (true)
        {
            Console.WriteLine("\n--- 📚 Välkommen till Biblioteket ---");
            Console.WriteLine("1. Logga in som Bibliotekarie");
            Console.WriteLine("2. Logga in som Låntagare");
            Console.WriteLine("3. Avsluta");
            Console.Write("Välj: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int role))
            {
                Console.WriteLine("Ogiltigt val.");
                continue;
            }

            User currentUser = null;
            switch (role)
            {
                case 1:
                    Console.Write("Ange ditt namn: ");
                    string libName = Console.ReadLine();
                    currentUser = new Librarian(libName);
                    break;
                case 2:
                    Console.Write("Ange ditt namn: ");
                    string borName = Console.ReadLine();
                    currentUser = new Borrower(borName);
                    break;
                case 3:
                    Console.WriteLine("Hej då!");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    continue;
            }

            currentUser.ShowMenu(library);
        }
    }
}
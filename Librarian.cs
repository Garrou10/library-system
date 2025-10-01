public class Librarian : User
{
    public Librarian(string name) : base(name) { }

    public override void ShowMenu(Library library)
    {
        while (true)
        {
            Console.WriteLine("\n---  Bibliotekarie Meny ---");
            Console.WriteLine("1. Lägg till bok");
            Console.WriteLine("2. Lista alla böcker");
            Console.WriteLine("3. Logga ut");
            Console.Write("Välj: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Ogiltigt val.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Titel: ");
                    string title = Console.ReadLine();
                    Console.Write("Författare: ");
                    string author = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    library.AddBook(title, author, isbn);
                    break;
                case 2:
                    library.ListAllBooks();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }
    }
}

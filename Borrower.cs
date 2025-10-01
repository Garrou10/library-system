public class Borrower : User, ISearchable
{
    public Borrower(string name) : base(name) { }

    public override void ShowMenu(Library library)
    {
        while (true)
        {
            Console.WriteLine("\n--- 📖 Låntagare Meny ---");
            Console.WriteLine("1. Sök bok");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Logga ut");
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
                    Console.Write("Sök efter titel eller författare: ");
                    string keyword = Console.ReadLine();
                    Search(keyword, library);
                    break;
                case 2:
                    Console.Write("Ange ISBN för boken du vill låna: ");
                    string borrowIsbn = Console.ReadLine();
                    library.BorrowBook(borrowIsbn);
                    break;
                case 3:
                    Console.Write("Ange ISBN för boken du vill lämna tillbaka: ");
                    string returnIsbn = Console.ReadLine();
                    library.ReturnBook(returnIsbn);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }
    }

    // Genererad med Copilot
    public void Search(string keyword, Library library)
    {
        bool found = false;
        foreach (var book in library.Books)
        {
            if (book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Titel: {book.Title}, Författare: {book.Author}, ISBN: {book.ISBN}, Utlånad: {book.IsBorrowed}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Inga böcker hittades.");
        }
    }
}
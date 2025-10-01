using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Library
{
    public List<Book> Books { get; private set; }
    private const string FilePath = "books.json";

    public Library()
    {
        Books = LoadBooksFromFile();
    }

    public void AddBook(string title, string author, string isbn)
    {
        if (Books.Exists(b => b.ISBN == isbn))
        {
            Console.WriteLine("Fel: ISBN finns redan.");
            return;
        }
        Books.Add(new Book(title, author, isbn));
        SaveBooksToFile();
        Console.WriteLine("Bok tillagd!");
    }

    public void ListAllBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("Inga böcker i systemet.");
            return;
        }
        foreach (var book in Books)
        {
            Console.WriteLine($"Titel: {book.Title}, Författare: {book.Author}, ISBN: {book.ISBN}, Utlånad: {book.IsBorrowed}");
        }
    }

    // Genererad med Copilot
    public void BorrowBook(string isbn)
    {
        var book = Books.Find(b => b.ISBN == isbn);
        if (book == null)
        {
            Console.WriteLine("Boken finns inte.");
        }
        else if (book.IsBorrowed)
        {
            Console.WriteLine("Boken är redan utlånad.");
        }
        else
        {
            book.IsBorrowed = true;
            SaveBooksToFile();
            Console.WriteLine("Du har lånat boken!");
        }
    }

    public void ReturnBook(string isbn)
    {
        var book = Books.Find(b => b.ISBN == isbn);
        if (book == null)
        {
            Console.WriteLine("Boken finns inte i systemet.");
        }
        else if (!book.IsBorrowed)
        {
            Console.WriteLine("Boken är inte utlånad.");
        }
        else
        {
            book.IsBorrowed = false;
            SaveBooksToFile();
            Console.WriteLine("Boken har lämnats tillbaka!");
        }
    }

    private List<Book> LoadBooksFromFile()
    {
        if (!File.Exists(FilePath))
            return new List<Book>();

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    private void SaveBooksToFile()
    {
        string json = JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
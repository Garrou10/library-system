public abstract class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }

    public abstract void ShowMenu(Library library);
}
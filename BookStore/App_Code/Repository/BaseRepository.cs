using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BaseRepository : IRepository
{
    private Random _rnd = new Random();
    private Category[] _categories = new Category[]
    {
        new Category() { ID = 1, Name = "Спорт" },
        new Category() { ID = 2, Name = "Наука" },
        new Category() { ID = 3, Name = "Фантастика" },
        new Category() { ID = 4, Name = "Периодические" },
    };

    public static BaseRepository Instance
    {
        get;
    } = new BaseRepository();

    public IEnumerable<Book> Books
    {
        get;
        private set;
    } = new List<Book>();


    private BaseRepository()
    {
        GenerateBooks();
    }

    private void GenerateBooks()
    {
        for (int i = 0; i < _rnd.Next(100, 200); i++) GenerateBook(i);
    }

    private void GenerateBook(int i)
    {
        var book = new Book()
        {
            ID = i + 1,
            Category = _categories[_rnd.Next(0, _categories.Length)],
            Title = GenerateString(15, 30),
            Author = GenerateString(10, 20),
            Description = GenerateString(30, 50),
            Price = (float)(_rnd.NextDouble() * 5000)
        };
        ((List<Book>)Books).Add(book);
    }

    private string GenerateString(int min, int max)
    {
        var letters = new char[_rnd.Next(min, max)];
        for (int i = 0; i < letters.Length; i++) letters[i] = GenerateLetter();
        return new string(letters);
    }

    private char GenerateLetter()
    {
        var letters = "qwertyuiopasdfghjklzxcvbnm";
        var letter = letters[_rnd.Next(0, letters.Length)];
        if (_rnd.Next(0, 3) == 0) letter = char.ToUpper(letter);
        return letter;
    }
}
namespace Books.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Annotation { get; set; }

    public override string ToString()
    {
        return $"{Title}, {Author}";
    }
}
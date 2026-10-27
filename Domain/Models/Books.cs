namespace Domain.Models;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }=null!;
    public int Publishedyear { get; set; }
    public int Totalcopies {get; set; }
    public int authorId { get; set; }
    public int genreId { get; set; }
}

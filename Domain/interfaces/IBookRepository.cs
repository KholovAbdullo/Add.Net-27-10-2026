using Domain.Models;

namespace Domain.interfaces;

public interface IBookRepository
{
    void AddBook(Books book);
    void UpdateBook(Books book);
    void DeleteBook(int id);
    Books GetBook(int id);
    List<Books> GetBooks();
    List<Books> GetBooksByAuthor(string authorName);
    List<Books> GetBooksByGenre(string genreName);
}

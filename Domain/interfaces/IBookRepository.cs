using Domain.Models;

namespace Domain.interfaces;

public interface IBookRepository
{
    Task AddBook(Books book);
    Task UpdateBook(Books book);
    Task DeleteBook(int id);
    Task<Books> GetBook(int id);
    Task<List<Books>> GetBooks();
    Task<List<Books>> GetBooksByAuthor(string authorName);
    Task<List<Books>> GetBooksByGenre(string genreName);
    Task<int> GetBookAmount();
    Task<int> GetAmountByPublishedYear(int year);
    Task<int> GetAmountByGenre(int genreId);

}

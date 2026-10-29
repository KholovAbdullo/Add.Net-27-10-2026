using Domain.Models;

namespace Domain.interfaces;

public interface IAuthorRepository
{
    Task AddAuthor(Author author);
    Task UpdateAuthor(Author author);
    Task DeleteAuthor(int id);
    Task<Author> GetAuthor(int id);
    Task<List<Author>> GetAuthors();
    Task<int> GetAuthorsAmount();
    Task<int> GetMinPublishedYearByAuthor(int authorId);
    Task<int> GetMaxPublishedYearByAuthor(int authorId);
}

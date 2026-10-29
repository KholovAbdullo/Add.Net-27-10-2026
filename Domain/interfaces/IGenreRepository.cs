using Domain.Models;

namespace Domain.interfaces;

public interface IGenreRepository
{
    Task AddGenre(Genre genre);
    Task UpdateGenre(Genre genre);
    Task DeleteGenre(int id);
    Task<Genre> GetGenre(int id);
    Task<List<Genre>> GetGenres();
    Task<int> GetGenresAmount();
    Task<int> GetMinPublishedYearByGenre(int genreId);
    Task<int> GetMaxPublishedYearByGenre(int genreId);
}

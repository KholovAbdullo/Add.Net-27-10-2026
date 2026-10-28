using Domain.Models;

namespace Domain.interfaces;

public interface IGenreRepository
{
    void AddGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void DeleteGenre(int id);
    Genre GetGenre(int id);
    List<Genre> GetGenres();
    int GetGenresAmount();
    int GetMinPublishedYearByGenre(int genreId);
    int GetMaxPublishedYearByGenre(int genreId);
}

using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository : IGenreRepository
{
    public async Task AddGenre(Genre genre)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Genres(name) values(@name)";
        await conn.ExecuteAsync(query,new{genre.Name});
    }

    public async Task DeleteGenre(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Genres where id=@id";
        await conn.ExecuteAsync(query,new{id});
    }

    public async Task<Genre> GetGenre(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Genres where id=@id";
        var genre=await conn.QuerySingleAsync<Genre>(query,new{id});
        return genre;
    }

    public async Task<List<Genre>> GetGenres()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Genre>("select * from Genres");
        return query.ToList();
    }

    public async Task<int> GetGenresAmount()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Genres";
        var amount=await conn.ExecuteScalarAsync<int>(query);
        return amount;
    }

    public async Task<int> GetMaxPublishedYearByGenre(int genreId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select max(publishedyear) from Books where genre_id=@genreId";
        var max=await conn.ExecuteScalarAsync<int>(query,new{genreId});
        return max;
    }

    public async Task<int> GetMinPublishedYearByGenre(int genreId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select min(publishedyear) from Books where genre_id=@genreId";
        var min=await conn.ExecuteScalarAsync<int>(query,new{genreId});
        return min;
    }


    public async Task UpdateGenre(Genre genre)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Genres set name=@name where id=@id";
        await conn.ExecuteAsync(query,genre);
    }

}

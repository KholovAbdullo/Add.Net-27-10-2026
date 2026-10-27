using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository : IGenreRepository
{
    public void AddGenre(Genre genre)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Genres(name) values(@name)";
        conn.Execute(query,new{genre.Name});
    }

    public void DeleteGenre(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Genres where id=@id";
        conn.Execute(query,new{id});
    }

    public Genre GetGenre(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Genres where id=@id";
        var genre=conn.QuerySingle<Genre>(query,new{id});
        return genre;
    }

    public List<Genre> GetGenres()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=conn.Query<Genre>("select * from Genres");
        return query.ToList();
    }

    public void UpdateGenre(Genre genre)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Genres set name=@name where id=@id";
        conn.Execute(query,genre);
    }

}

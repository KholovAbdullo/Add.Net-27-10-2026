using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AuthorRepository : IAuthorRepository
{
    public void AddAuthor(Author author)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Author(fullname,country,birthyear) values(@fullname,@country,@birthyear)";
        conn.Execute(query,new{author.Fullname,author.Country,author.Birthyear});
    }

    public void DeleteAuthor(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Author where id=@id";
        conn.Execute(query,new{id});
    }

    public Author GetAuthor(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Author where id=@id";
        var author=conn.QuerySingle<Author>(query,new{id});
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=conn.Query<Author>("select * from Author");
        return query.ToList();
    }

    public void UpdateAuthor(Author author)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Author set fullname=@fullname,country=@country,birthyear=@birthyear where id=@id";
        conn.Execute(query,author);
    }

}

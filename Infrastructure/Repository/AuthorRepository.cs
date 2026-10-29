using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AuthorRepository : IAuthorRepository
{
    public async Task AddAuthor(Author author)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Author(fullname,country,birthyear) values(@fullname,@country,@birthyear)";
        await conn.ExecuteAsync(query,new{author.Fullname,author.Country,author.Birthyear});
    }

    public async Task DeleteAuthor(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Author where id=@id";
        await conn.ExecuteAsync(query,new{id});
    }

    public async Task<Author> GetAuthor(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Author where id=@id";
        var author=await conn.QuerySingleAsync<Author>(query,new{id});
        return author;
    }

    public async Task<List<Author>> GetAuthors()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Author>("select * from Author");
        return query.ToList();
    }

    public async Task<int> GetAuthorsAmount()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Author";
        var amount=await conn.ExecuteScalarAsync<int>(query);
        return amount;
    }

    public async Task<int> GetMaxPublishedYearByAuthor(int authorId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select max(publishedyear) from Books where auhtor_id=@authorId";
        var max=await conn.ExecuteScalarAsync<int>(query,new{authorId});
        return max;
    }

    public async Task<int> GetMinPublishedYearByAuthor(int authorId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select min(publishedyear) from Books where auhtor_id=@authorId";
        var min=await conn.ExecuteScalarAsync<int>(query,new{authorId});
        return min;
    }


    public async Task UpdateAuthor(Author author)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Author set fullname=@fullname,country=@country,birthyear=@birthyear where id=@id";
        await conn.ExecuteAsync(query,author);
    }

}

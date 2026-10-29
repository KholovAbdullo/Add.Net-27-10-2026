using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class BooksRepository:IBookRepository
{
    public async Task AddBook(Books book)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query = @"insert into Books(title, publishedyear, totalcopies, author_id, genre_id) values(@Title, @Publishedyear, @Totalcopies, @authorId, @genreId)";
        await Connection.ExecuteAsync(query, new{book.Title,book.Publishedyear,book.Totalcopies,book.authorId,book.genreId});
    }

    public async Task DeleteBook(int id)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query="delete from Books where id=@id";
        await Connection.ExecuteAsync(query,new{id});
    }

    public async Task<int> GetAmountByGenre(int genreId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Books where genre_id=@genreId";
        var amount=await conn.ExecuteScalarAsync<int>(query,new{genreId});
        return amount;

    }

    public async Task<int> GetAmountByPublishedYear(int year)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Books where publishedyear=@year";
        var yeare=await conn.ExecuteScalarAsync<int>(query,new{year});
        return yeare;
    }


    public async Task<Books> GetBook(int id)
    {
       using var Connection=Database.Connection();
       Connection.Open();
       var query="select * from Books where id=@id";
       var book=await Connection.QuerySingleAsync<Books>(query,new{id});
       return book;
    }

    public async Task<int> GetBookAmount()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Books";
        var amount=await conn.ExecuteScalarAsync<int>(query);
        return amount;
    }


    public async Task<List<Books>> GetBooks()
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query=await Connection.QueryAsync<Books>("select * from Books");
        return query.ToList();
    }

public async Task<List<Books>> GetBooksByAuthor(string authorName)
{
    using var conn = Database.Connection();
    conn.Open();
    var query = @"select * from Books b join Author a on b.author_id = a.id where a.fullname = @authorName";
    var books = await conn.QueryAsync<Books>(query, new { authorName });
    return books.ToList();
}

    public async Task<List<Books>> GetBooksByGenre(string genreName)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Books b join Genres g on b.genre_id=g.id where g.name=@genreName";
        var book=await conn.QueryAsync<Books>(query,new{genreName});
        return book.ToList();
    }


    public async Task UpdateBook(Books book)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query="update Books set title=@title, publishedyear=@publishedyear,totalcopies=@totalcopies,author_id=@author_id,genre_id=@genre_id where id=@id";
        await Connection.ExecuteAsync(query,book);
    }
}

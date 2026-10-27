using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class BooksRepository:IBookRepository
{
    public void AddBook(Books book)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query = @"INSERT INTO Books
            (title, publishedyear, totalcopies, author_id, genre_id) values(@Title, @Publishedyear, @Totalcopies, @authorId, @genreId)";
        Connection.Execute(query, new{book.Title,book.Publishedyear,book.Totalcopies,book.authorId,book.genreId});
    }

    public void DeleteBook(int id)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query="delete from Books where id=@id";
        Connection.Execute(query,new{id});
    }

    public Books GetBook(int id)
    {
       using var Connection=Database.Connection();
       Connection.Open();
       var query="select * from Books where id=@id";
       var book=Connection.QuerySingle<Books>(query,new{id});
       return book;
    }

    public List<Books> GetBooks()
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query=Connection.Query<Books>("select * from Books");
        return query.ToList();
    }

public List<Books> GetBooksByAuthor(string authorName)
{
    using var conn = Database.Connection();
    conn.Open();
    var query = @"select * from Books b join Author a on b.author_id = a.id where a.fullname = @authorName";
    var books = conn.Query<Books>(query, new { authorName });
    return books.ToList();
}

    public List<Books> GetBooksByGenre(string genreName)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Books b join Genres g on b.genre_id=g.id where g.name=@genreName";
        var book=conn.Query<Books>(query,new{genreName});
        return book.ToList();
    }


    public void UpdateBook(Books book)
    {
        using var Connection=Database.Connection();
        Connection.Open();
        var query="update Books set title=@title, publishedyear=@publishedyear,totalcopies=@totalcopies,author_id=@author_id,genre_id=@genre_id where id=@id";
        Connection.Execute(query,book);
    }
}

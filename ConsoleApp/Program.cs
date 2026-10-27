
using Domain.Models;
using Infrastructure.Repository;

var re = new BooksRepository();
var au = new AuthorRepository();
var ge = new GenreRepository();

while (true)
{
    Console.WriteLine("======================================");
    Console.WriteLine(@"
    Table Books!
    1. Show all books.
    2. Show book by id.
    3. Add new book.
    4. Update book.
    5. Delete book.
    6. Get books by author.
    7. Get books by genre.

    Table Authors!
    8. Show all authors.
    9. Show author by id.
    10. Add new author.
    11. Update author.
    12. Delete author.

    Table Genres!
    13. Show all genres.
    14. Show genre by id.
    15. Add new genre.
    16. Update genre.
    17. Delete genre.
    0. Exit.");
    var a = Console.ReadLine();
    Console.WriteLine("======================================");

    switch (a)
    {
        case "1":
            var books = re.GetBooks();
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Id} | {item.Title} | {item.Publishedyear} | {item.Totalcopies} | {item.authorId} | {item.genreId}");
            }
            break;

        case "2":
            Console.Write("Enter id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var book = re.GetBook(id);
            Console.WriteLine($"{book.Id} | {book.Title} | {book.Publishedyear} | {book.Totalcopies}");
        break;

        case "3":
            Console.Write("Enter title: ");
            var title = Console.ReadLine()!;
            Console.Write("Enter published year: ");
            var year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter total copies: ");
            var copies = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter author id: ");
            var authorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter genre id: ");
            var genreId = Convert.ToInt32(Console.ReadLine());
            var books1 = new Books()
            {
                Title = title,
                Publishedyear = year,
                Totalcopies = copies,
                authorId = authorId,
                genreId = genreId
            };
            re.AddBook(books1);
            break;

        case "4":
            Console.Write("Enter book id: ");
            var idd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter title: ");
            var titlee = Console.ReadLine()!;
            Console.Write("Enter published year: ");
            var yeare = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter total copies: ");
            var copiess = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter author id: ");
            var authorIds = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter genre id: ");
            var genreIds = Convert.ToInt32(Console.ReadLine());
            var books2 = new Books()
            {
                Id = idd,
                Title = titlee,
                Publishedyear = yeare,
                Totalcopies = copiess,
                authorId = authorIds,
                genreId = genreIds
            };

            re.UpdateBook(books2);
            break;

        case "5":
            Console.Write("Enter book id: ");
            var i = Convert.ToInt32(Console.ReadLine());
            re.DeleteBook(i);
            break;

        case "6":
            Console.Write("Enter author name: ");
            var authorName = Console.ReadLine()!;
            var books3 = re.GetBooksByAuthor(authorName);
            foreach (var item in books3)
            {
                Console.WriteLine($"{item.Id} | {item.Title} | {item.Publishedyear}");
            }
            break;

        case "7":
            Console.Write("Enter genre name: ");
            var genreName = Console.ReadLine()!;
            var books4 = re.GetBooksByGenre(genreName);
            foreach (var item in books4)
            {
                Console.WriteLine($"{item.Id} | {item.Title}");
            }
            break;

        case "8":
            var authors = au.GetAuthors();
            foreach (var item in authors)
            {
                Console.WriteLine($"{item.Id} | {item.Fullname} | {item.Country} | {item.Birthyear}");
            }
            break;

        case "9":
            Console.Write("Enter author id: ");
            var idi = Convert.ToInt32(Console.ReadLine());
            var author = au.GetAuthor(idi);
            Console.WriteLine($"{author.Id} | {author.Fullname} | {author.Country} | {author.Birthyear}");
            break;

        case "10":
            Console.Write("Enter fullname: ");
            var fullname = Console.ReadLine()!;
            Console.Write("Enter country: ");
            var country = Console.ReadLine()!;
            Console.Write("Enter birth year: ");
            var birthyear = Convert.ToInt32(Console.ReadLine());
            var authorr = new Author()
            {
                Fullname = fullname,
                Country = country,
                Birthyear = birthyear
            };
            au.AddAuthor(authorr);
            break;

        case "11":
            Console.Write("Enter author id: ");
            var idid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter fullname: ");
            var fullnam = Console.ReadLine()!;
            Console.Write("Enter country: ");
            var countr= Console.ReadLine()!;
            Console.Write("Enter birth year: ");
            var birthyea = Convert.ToInt32(Console.ReadLine());
            var authors1 = new Author()
            {
                Id = idid,
                Fullname = fullnam,
                Country = countr,
                Birthyear = birthyea
            };
            au.UpdateAuthor(authors1);
            break;

        case "12":
            Console.Write("Enter author id: ");
            var iddd = Convert.ToInt32(Console.ReadLine());
            au.DeleteAuthor(iddd);
            break;

        case "13":
            var genres = ge.GetGenres();
            foreach (var item in genres)
            {
                Console.WriteLine($"{item.Id} | {item.Name}");
            }
            break;

        case "14":
            Console.Write("Enter genre id: ");
            var idii = Convert.ToInt32(Console.ReadLine());
            var genre = ge.GetGenre(idii);
            Console.WriteLine($"{genre.Id} | {genre.Name}");
            break;

        case "15":
            Console.Write("Enter genre name: ");
            var name = Console.ReadLine()!;
            var genres1 = new Genre()
            {
                Name = name
            };
            ge.AddGenre(genres1);
            break;

        case "16":
            Console.Write("Enter genre id: ");
            var idiii = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter genre name: ");
            var names = Console.ReadLine()!;
            var genr = new Genre()
            {
                Id = idiii,
                Name = names
            };
            ge.UpdateGenre(genr);
            break;

        case "17":
            Console.Write("Enter genre id: ");
            var iid = Convert.ToInt32(Console.ReadLine());
            ge.DeleteGenre(iid);
            break;

        case "0":
            Console.WriteLine("Exit...");
            return;
    }
}
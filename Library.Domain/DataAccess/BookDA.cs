using Library.Helpers.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Library.Domain.DataAccess
{
    public class BookDA
    {
        public List<Book> GetAll(QueryOptions queryOptions)
        {
            List<Book> result =  null;
            using (var r = new Repository<Book>())
            {
                result = r.Get().OrderBy(queryOptions.Sort).ToList();
            }
            return result;
        }

        public List<Book> GetAllWithAuthor()
        {
            List<Book> result = null;
            using (var r = new Repository<Book>())
            {
                result = ( from b in r.Get().Include(x => x.Author != null) select new Book {
                                    Id = b.Id,
                                    AuthorId = b.AuthorId,
                                    Description = b.Description,
                                    ImageUrl = b.ImageUrl,
                                    Isbn = b.Isbn,
                                    Synopsis = b.Synopsis,
                                    Title = b.Title                                                    
                                } ).ToList();
              
            }
            return result;
        }

        public void Inicialize()
        {
            
            using (var r = new Repository<Book>())
            {
                var author = new Author
                {
                    Biography = "...",
                    FirstName = "Jamie",
                    LastName = "Munro"
                };
                var books = new List<Book>
                {
                    new Book {
                        Author = author,
                        Description = "...",
                        ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                        Isbn = "1491914319",
                        Synopsis = "...",
                        Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                    },
                    new Book {
                        Author = author,
                        Description = "...",
                        ImageUrl = "http://ecx.images-amazon.com/images/I/51AkFkNeUxL._AA160_.jpg",
                        Isbn = "1449319548",
                        Synopsis = "...",
                        Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development"
                    },
                    new Book {
                        Author = author,
                        Description = "...",
                        ImageUrl = "http://ecx.images-amazon.com/images/I/51LpqnDq8-L._AA160_.jpg",
                        Isbn = "1449309860",
                        Synopsis = "...",
                        Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                    },
                    new Book {
                        Author = author,
                        Description = "...",
                        ImageUrl = "http://ecx.images-amazon.com/images/I/41JC54HEroL._AA160_.jpg",
                        Isbn = "1460954394",
                        Synopsis = "...",
                        Title = "Rapid Application Development With CakePHP"
                    }
                };

                r.AddRange(books);
            }
        }
    }
}

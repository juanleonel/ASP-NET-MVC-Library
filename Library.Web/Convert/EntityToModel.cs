using AutoMapper;
using Library.Domain;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Convert
{
    public static class EntityToModel
    {
        /// <summary>
        /// Convierte una entidad a un modelo
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static AuthorModelView AuthorToModel(Author Author)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorModelView>());

            var mapper = config.CreateMapper();

            AuthorModelView model = mapper.Map<AuthorModelView>(Author);

            return model;
            /*
            return new AuthorModelView
            {
                Id = Author.Id,
                FirstName = Author.FirstName,
                Book = Author.Book != null ? BooksToModel(Author.Book.ToList()) : null,
                LastName = Author.LastName,
                Biography = Author.Biography
            };*/
        }


        /// <summary>
        /// Convierte una lista de entidades a una lista de modelos
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<AuthorModelView> AuthorsToModel(List<Author> Authors)
        {
            List<AuthorModelView> model =
             Authors.Select(p => new AuthorModelView()
             {
                 Id = p.Id,
                 FirstName = p.FirstName,
                 LastName = p.LastName,
                 Biography = p.Biography,
                 Book =  p.Book != null ? BooksToModel(p.Book.ToList()) : null,
             }).ToList();

            return model;
        }

        /// <summary>
        /// Convierte una entidad a un modelo
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static BookModelView BookToModel(Book Book)
        {
            return new BookModelView
            {
                Id = Book.Id,
                AuthorId = Book.AuthorId,
                Author = Book.Author!= null ? AuthorToModel(Book.Author): null,
                Title = Book.Title,
                Isbn = Book.Isbn,
                Synopsis = Book.Synopsis,
                Description = Book.Description,
                ImageUrl = Book.ImageUrl

            };
        }

        /// <summary>
        /// Convierte una lista de entidades a una lista de modelos
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<BookModelView> BooksToModel(List<Book> books)
        {
            List<BookModelView> model =
              books.Select(p => new BookModelView()
              {
                  Id = p.Id,
                  AuthorId = p.AuthorId,
                  Author = p.Author != null ? AuthorToModel(p.Author) : null,
                  Title = p.Title,
                  Isbn = p.Isbn,
                  Synopsis = p.Synopsis,
                  Description = p.Description,
                  ImageUrl = p.ImageUrl                  
              }).ToList();

            return model;
        }


    }
}
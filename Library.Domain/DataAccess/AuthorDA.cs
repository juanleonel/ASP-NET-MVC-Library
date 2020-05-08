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
    public class AuthorDA
    {
        public List<Author> GetAll(QueryOptions queryOptions, int start)
        {
            List<Author> result = null;
            using (var r = new Repository<Author>())
            {

                result = r.Get()
                            .OrderBy(queryOptions.Sort)
                            .Skip(start)
                            .Take(queryOptions.PageSize)
                            .Where(x => x.Enable == false).ToList();

            }
            return result;
        }

        public int Count()
        {
            int total = 0;
            using (var r = new Repository<Author>())
            {
                total =  r.Get().Count();
            }
            return total;
        }

        public int CountPaging(QueryOptions queryOptions)
        {

            return  (int) Math.Ceiling( (double) Count() / queryOptions.PageSize ); 

        }

        public List<Author> GetAllWithBooks()
        {
            List<Author> result = null;
            using (var r = new Repository<Author>())
            {
                var query = (r.Get().Include(x => x.Book)).ToList();

                result = query;
            }
            return result;
        }

        public void Create(Author author)
        {
            using (var r = new Repository<Author>())
            {
                r.Add(author);
            }
        }

        public void Update(Author author)
        {
            using (var r = new Repository<Author>())
            {
                r.Update(author);
            }
        }
           
        public Author FindById(int? id)
        {
            Author result = null;

            using (var r = new Repository<Author>())
            {
                result = r.GetForId(x => x.Id == id);
            }

            return result;
        }

        public void Delete(Author author)
        {
            using (var r = new Repository<Author>())
            {
                r.Update(author);
            }
        }
    }
}

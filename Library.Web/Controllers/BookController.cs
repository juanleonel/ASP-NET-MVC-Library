using Library.Domain.DataAccess;
using Library.Web.Convert;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class BookController : Controller
    {
        #region Dependencias

        private BookDA _bookDA;
        private BookDA BookDA
        {
            get { return _bookDA ?? (_bookDA = new BookDA()); }
        }

        #endregion  

        // GET: Book
        public ActionResult Index([System.Web.ModelBinding.Form] Helpers.Query.QueryOptions queryOptions)
        {
            var books = BookDA.GetAll(queryOptions);

            List<BookModelView> model = new List<BookModelView>();

            model = EntityToModel.BooksToModel(books);

            ViewBag.QueryOptions = queryOptions;

            return View(model);
        }
    }
}
using Library.Domain.DataAccess;
using Library.Web.Convert;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ModelBinding;
using System.Net;

namespace Library.Web.Controllers
{
    public class AuthorController : Controller
    {
        #region Dependencias

        private AuthorDA _authorDA;
        private AuthorDA AuthorDA
        {
            get { return _authorDA ?? (_authorDA = new AuthorDA()); }
        }

        #endregion  

        // GET: Author
        public ActionResult Index([Form] Library.Helpers.Query.QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;

            var authors = AuthorDA.GetAll(queryOptions, start);

            queryOptions.TotalPages = AuthorDA.CountPaging(queryOptions);

            List<AuthorModelView> model = new List<AuthorModelView>();

            model = EntityToModel.AuthorsToModel(authors);

            ViewBag.QueryOptions = queryOptions;

            return View(model);
        }

        public ActionResult Create()
        {
            return View("Form", new AuthorModelView());
        }

        // POST: Entrada/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Biography")] AuthorModelView model)
        {           
             
            if (ModelState.IsValid)
            {
               
                var entity = ModelToEntity.ModelToAuthor(model);

                AuthorDA.Create(entity);

                return RedirectToAction("Index");
                              
            }

            return View(model);
              
          
            
        }


        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Domain.Author author = AuthorDA.FindById(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            AuthorModelView model = new AuthorModelView();

            model = EntityToModel.AuthorToModel(author);
            
            return View("Form", model);
        }

        [HttpPost]
        public ActionResult Edit(int? id, AuthorModelView model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Domain.Author author = AuthorDA.FindById(model.Id);

            if (author == null)
            {
                return HttpNotFound();
            }

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.Biography = model.Biography;

            AuthorDA.Update(author);

            return RedirectToAction("Index");                        
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Domain.Author author = AuthorDA.FindById(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            AuthorModelView model = new AuthorModelView();

            model = EntityToModel.AuthorToModel(author);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Domain.Author author = AuthorDA.FindById(id);
            author.Enable = true;

            AuthorDA.Delete(author);

            return RedirectToAction("Index");
        }

    }
 
   
}
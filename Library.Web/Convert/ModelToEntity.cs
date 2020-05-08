using AutoMapper;
using Library.Domain;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Convert
{
    public class ModelToEntity
    {
        public static Author ModelToAuthor(AuthorModelView Author)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorModelView, Author>());

            var mapper = config.CreateMapper();

            Author entity = mapper.Map<Author>(Author);

            return entity;
        }



       
    }

    public class Mappeo
    {
         

    }
}
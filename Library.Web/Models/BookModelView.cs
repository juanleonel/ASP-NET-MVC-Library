﻿namespace Library.Web.Models
{
    public class BookModelView
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Enable { get; set; }

        public AuthorModelView Author { get; set; }
    }
}
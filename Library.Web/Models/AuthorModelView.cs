using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class AuthorModelView
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "biography")]
        public string Biography { get; set; }

        public bool Enable { get; set; }

        [JsonProperty(PropertyName = "books")]
        public List<BookModelView> Book { get; set; }


    }
}
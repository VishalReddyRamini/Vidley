using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [DisplayName("Released Date")]
        public DateTime? RealeaseDate { get; set; }
        [DisplayName("Date Added")]
        public DateTime? DateAdded { get; set; }
        [DisplayName("Number in Stock")]
        public int NumberInStock { get; set; }
    }
}
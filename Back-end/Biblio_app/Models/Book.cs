using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio_app.Models
{
    public class Book
    {
        public Book()
        {
            
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int PublicationYear { get; set; }
    }
    
}

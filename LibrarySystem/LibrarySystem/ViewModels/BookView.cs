using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Application.ViewModels
{
    public class BookView
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "The books name is mandatory")]
        public string Name { get; set; }
        public string Edition { get; set; }
        public string WriterName { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
using LibrarySystem.Domain.Entities.Base;
using System;

namespace LibrarySystem.Domain.Entities
{
    public class Book : BaseModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string WriterName  { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

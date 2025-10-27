﻿
namespace BookCatalog.Domain.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; } // Foreign Key
    public int PublicationYear { get; set; }
    }

}

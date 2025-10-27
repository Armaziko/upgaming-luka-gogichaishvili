
using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure
{
    public static class Data
    {

        private static List<Author> _authors = new List<Author>
        {
            new Author { ID = 1, Name = "Robert C. Martin" },
            new Author { ID = 2, Name = "Jeffrey Richter" }
        };
        
        private static List<Book> _books = new List<Book>
        {
            new Book { ID = 1, Title = "Clean Code", AuthorID = 1, PublicationYear = 2008
            },
            new Book { ID = 2, Title = "CLR via C#", AuthorID = 2, PublicationYear = 2012
            },
            new Book { ID = 3, Title = "The Clean Coder", AuthorID = 1, PublicationYear =
            2011 }
        };

        public static List<Author> Authors
        {
            get
            {
                return _authors;
            }

        }

        public static List<Book> Books 
        {
            get 
            {
                return _books;
            }
        
        }

    }
}

using System.Collections;
using System.Collections.Generic;

namespace BookApp.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}

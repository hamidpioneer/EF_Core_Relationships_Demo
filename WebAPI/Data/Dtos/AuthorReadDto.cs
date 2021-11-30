using System.Collections.Generic;
using WebAPI.Data.Models;

namespace WebAPI.Data.Dtos
{
    public class AuthorReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //public ICollection<Book_Author> Book_Authors { get; set; }
        public ICollection<string> BookTitles { get; set; }
    }
}

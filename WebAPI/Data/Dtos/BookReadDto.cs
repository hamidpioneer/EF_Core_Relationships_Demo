using System;
using System.Collections.Generic;
using WebAPI.Data.Models;

namespace WebAPI.Data.Dtos
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        //public string Author { get; set; }
        public string CoverUrl { get; set; }

        public string PublisherName { get; set; }
        public IList<string> AuthorNames { get; set; }

        public string ThanksNote { get; set; } = "Thanks!";

    }
}

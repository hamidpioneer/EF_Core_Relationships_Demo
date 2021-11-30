﻿using System;

namespace WebAPI.Data.Dtos
{
    public class BookCreatDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
    }
}

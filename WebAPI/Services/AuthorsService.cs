using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Data.Dtos;
using WebAPI.Data.Models;

namespace WebAPI.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<AuthorReadDto> GetAll()
        {
            //var allAuthors = _context.Authors.AsNoTracking().ToList();
            var datas = _context.Authors.Select(a => new AuthorReadDto
            {
                Id = a.Id,
                FullName = a.FullName,
                BookTitles = a.Book_Authors.Select(ba=>ba.Book.Title).ToList()
            }).ToList();

            return datas;
        }
        
        public AuthorReadDto GetById(int id)
        {
            var datas = _context.Authors.Where(a => a.Id == id).Select(b => new AuthorReadDto()
            {
                Id = id,
                FullName = b.FullName,
                BookTitles = b.Book_Authors.Select(ba => ba.Book.Title).ToList()
            }).FirstOrDefault();

            return datas;
        }

        public Author Add(AuthorCreateDto newAuthorDto)
        {
            Author newAuthor = new Author()
            {
                FullName = newAuthorDto.FullName
            };

            _context.Authors.Add(newAuthor);
            _context.SaveChanges();

            return newAuthor;
        }
    }
}

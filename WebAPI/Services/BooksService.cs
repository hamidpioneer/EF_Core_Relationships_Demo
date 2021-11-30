using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Data.Dtos;
using WebAPI.Data.Models;

namespace WebAPI.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(BookCreatDto newBookDto)
        {
            Book newBook = new Book()
            {
                Title = newBookDto.Title,
                Description = newBookDto.Description,
                isRead = newBookDto.isRead,
                DateRead = newBookDto.isRead ? newBookDto.DateRead : null,
                Rate = newBookDto.isRead ? newBookDto.Rate.Value : null,
                Genre = newBookDto.Genre,
                Author = newBookDto.Author,
                CoverUrl = newBookDto.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public IList<BookReadDto> GetAll()
        {
            IList<BookReadDto> allBooks = _context.Books.Select(book => new BookReadDto {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.DateAdded,
                Rate = book.Rate.Value,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                ThanksNote = "Thanks for Retriving All"
            }).ToList();

            return allBooks;
        }

        public BookReadDto GetById(int bookId)
        {
            BookReadDto bookFromDb = _context.Books
                .Where(b=>b.Id==bookId)
                .Select(book=>new BookReadDto {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    isRead = book.isRead,
                    DateRead = book.DateAdded,
                    Rate = book.Rate.Value,
                    Genre = book.Genre,
                    Author = book.Author,
                    CoverUrl = book.CoverUrl,
                    ThanksNote = "Thanks for Retriving"
                })
                .FirstOrDefault();

            return bookFromDb;
        }
        
        public BookReadDto UpdateById(int bookId, BookCreatDto bookCreatDto)
        {
            var existedBook = _context.Books.FirstOrDefault(b => b.Id==bookId);
            if (existedBook != null)
            {
                existedBook.Title = bookCreatDto.Title;
                existedBook.Description = bookCreatDto.Description;
                existedBook.isRead = bookCreatDto.isRead;
                existedBook.DateRead = bookCreatDto.DateRead;
                existedBook.Rate = bookCreatDto.Rate;
                existedBook.Genre = bookCreatDto.Genre;
                existedBook.Author = bookCreatDto.Author;
                existedBook.CoverUrl = bookCreatDto.CoverUrl;

                _context.Books.Update(existedBook);
                _context.SaveChanges();

                return new BookReadDto
                {
                    Id = existedBook.Id,
                    Title = bookCreatDto.Title,
                    Description = bookCreatDto.Description,
                    isRead = bookCreatDto.isRead,
                    DateRead = bookCreatDto.isRead ? bookCreatDto.DateRead : null,
                    Rate = bookCreatDto.isRead ? bookCreatDto.Rate.Value : null,
                    Genre = bookCreatDto.Genre,
                    Author = bookCreatDto.Author,
                    CoverUrl = bookCreatDto.CoverUrl,
                    ThanksNote = "Thanks for update!"
                };
            }
            return null;
        }

        public bool DeleteById(int bookId)
        {
            var existedBook = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (existedBook != null)
            {
                _context.Books.Remove(existedBook);
                _context.SaveChanges();
                
                return true;
            }

            return false;
        }
    }
}
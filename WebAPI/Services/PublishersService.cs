using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Data.Dtos;
using WebAPI.Data.Models;

namespace WebAPI.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Publisher> GetAll()
        {
            var allPublishers = _context.Publishers.Include(p=>p.Books).AsNoTracking().ToList();

            return allPublishers;
        }

        public Publisher Add(PublisherCreateDto newPublisher)
        {
            Publisher publisher = new Publisher()
            {
                Name = newPublisher.Name
            };
            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return publisher;
        }
    }
}

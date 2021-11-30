using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebAPI.Data.Models;

namespace WebAPI.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book() {
                            Title = "1st Book Title",
                            Description = "1st Description",
                            isRead = true,
                            DateRead = DateTime.Now,
                            Rate = 4,
                            Genre = "Biography",
                            Author = "First Author",
                            CoverUrl = "http:....",
                            DateAdded = DateTime.Now
                        },
                        new Book() {
                            Title = "2nd Book Title",
                            Description = "2nd Description",
                            isRead = false,
                            Genre = "Biography",
                            Author = "First Author",
                            CoverUrl = "http:....",
                            DateAdded = DateTime.Now
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}

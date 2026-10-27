using Assignment1_EF_Core_.Data;
using Assignment1_EF_Core_.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_EF_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BookstoreDbContext();

            context.Database.EnsureCreated();
            Console.WriteLine("Database created successfully!");

            if (!context.Books.Any())
            {
                var author = new Author
                {
                    FirstName = "Naguib",
                    LastName = "Mahfouz",
                    Email = "naguib@example.com",
                    Biography = "Famous Egyptian writer",
                    DateOfBirth = new DateTime(1911, 12, 11)
                };

                var category = new Category
                {
                    Name = "Novels",
                    Description = "Literature books",
                    IsActive = true
                };

                var book = new Book
                {
                    Title = "Palace Walk",
                    ISBN = "9789770912345",
                    Price = 150.00m,
                    NumberOfPages = 500,
                    PublishedYear = 1956,
                    IsInStock = true,
                    Author = author,
                    Category = category
                };

                context.Books.Add(book);
                context.SaveChanges();
                Console.WriteLine("Data inserted successfully!");
            }

            var savedBook = context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefault();

            if (savedBook != null)
            {
                Console.WriteLine($"\nBook Saved: {savedBook.Title}");
                Console.WriteLine($"Author: {savedBook.Author.FirstName} {savedBook.Author.LastName}");
                Console.WriteLine($"Category: {savedBook.Category.Name}");
            }
        }
    }
}
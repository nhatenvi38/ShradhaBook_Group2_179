using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShradhaBook.Models;

namespace ShradhaBook.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
     new Category { Id = 1, Name = "Romance", DisplayOrder = 1 },
     new Category { Id = 2, Name = "Self-Help", DisplayOrder = 2 },
     new Category { Id = 3, Name = "Fantasy", DisplayOrder = 3 },
     new Category { Id = 4, Name = "Mystery", DisplayOrder = 4 },
     new Category { Id = 5, Name = "Science Fiction", DisplayOrder = 5 }
 );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Penguin Random House",
                    StreetAddress = "375 Hudson St",
                    City = "New York",
                    PostalCode = "10014",
                    State = "NY",
                    PhoneNumber = "212-366-2000"
                },
                new Company
                {
                    Id = 2,
                    Name = "HarperCollins Publishers",
                    StreetAddress = "195 Broadway",
                    City = "New York",
                    PostalCode = "10007",
                    State = "NY",
                    PhoneNumber = "212-207-7000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Simon & Schuster",
                    StreetAddress = "1230 Avenue of the Americas",
                    City = "New York",
                    PostalCode = "10020",
                    State = "NY",
                    PhoneNumber = "212-698-7000"
                },
                new Company
                {
                    Id = 4,
                    Name = "Macmillan Publishers",
                    StreetAddress = "120 Broadway",
                    City = "New York",
                    PostalCode = "10271",
                    State = "NY",
                    PhoneNumber = "212-226-7521"
                },
                new Company
                {
                    Id = 5,
                    Name = "Hachette Book Group",
                    StreetAddress = "1290 Avenue of the Americas",
                    City = "New York",
                    PostalCode = "10104",
                    State = "NY",
                    PhoneNumber = "212-364-1100"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Description = "Pride and Prejudice is a romantic novel by Jane Austen...",
                    ISBN = "978-0141439518",
                    ListPrice = 12.99,
                    Price = 10.99,
                    Price50 = 9.99,
                    Price100 = 8.99,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "The Subtle Art of Not Giving a F*ck",
                    Author = "Mark Manson",
                    Description = "The Subtle Art of Not Giving a F*ck: A Counterintuitive Approach to Living a Good Life is a self-help book by Mark Manson...",
                    ISBN = "978-0062457714",
                    ListPrice = 18.99,
                    Price = 15.99,
                    Price50 = 14.99,
                    Price100 = 13.99,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Author = "J.K. Rowling",
                    Description = "Harry Potter and the Sorcerer's Stone is a fantasy novel written by British author J.K. Rowling...",
                    ISBN = "978-0590353427",
                    ListPrice = 24.99,
                    Price = 21.99,
                    Price50 = 19.99,
                    Price100 = 17.99,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    Title = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    Description = "The Girl with the Dragon Tattoo is a psychological thriller novel by Swedish author Stieg Larsson...",
                    ISBN = "978-0307949486",
                    ListPrice = 16.99,
                    Price = 14.99,
                    Price50 = 13.99,
                    Price100 = 12.99,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 5,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Description = "Dune is a science fiction novel by American author Frank Herbert...",
                    ISBN = "978-0441172719",
                    ListPrice = 21.99,
                    Price = 18.99,
                    Price50 = 17.99,
                    Price100 = 15.99,
                    CategoryId = 5
                }
           

                );
        }
    }
}
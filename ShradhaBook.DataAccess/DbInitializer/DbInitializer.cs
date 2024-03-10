using ShradhaBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShradhaBook.DataAcess.Data;
using ShradhaBook.Utility;

namespace ShradhaBook.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        // Constructor for DbInitializer class
        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        // Method to initialize the database
        public void Initialize()
        {

            // Apply pending migrations if any
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during migration
                // For example, log the exception
            }

            // Create roles if they do not exist
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                // Create roles for Customer, Employee, Admin, and Company
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                // Create admin user if it does not exist
                if (_db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com") == null)
                {
                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        Name = "ApTech",
                        PhoneNumber = "0123456789",
                        StreetAddress = "test 123 Aptech",
                        State = "DN",
                        PostalCode = "12345",
                        City = "DaNang"
                    }, "Admin123*").GetAwaiter().GetResult();

                    // Assign admin role to the admin user
                    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }
            }

            return;
        }
    }
}

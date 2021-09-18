using Microsoft.EntityFrameworkCore;
using System;

namespace Contacts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new Contact
            {
                Id = 1,
                FullName = "Test User 1",
                Email = "test@mail.com",
                Gender = "Male",
                Status = "Active"
            };
            modelBuilder.Entity<Contact>().HasData(user);
        }
    }
}
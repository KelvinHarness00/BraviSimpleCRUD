using BraviSimpleCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BraviSimpleCRUD.Data
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}

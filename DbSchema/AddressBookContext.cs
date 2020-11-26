using Microsoft.EntityFrameworkCore;
using System;

namespace DbSchema
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}

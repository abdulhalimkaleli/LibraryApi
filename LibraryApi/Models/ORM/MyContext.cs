using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.ORM
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=LibraryDB;trusted_connection=true;");
        }

        public DbSet<Book> Books {  get; set; }
        public DbSet<Writer > Writers { get; set; }
    }
}

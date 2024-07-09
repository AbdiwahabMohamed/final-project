using Microsoft.EntityFrameworkCore;

namespace projectuniversity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Action", Email = "Abdiwahab@gmail.com", Password = "1234", IsAdmin = false, },
                new User { Id = 2, Name = "sefi", Email = "AbdiwahabAbdi@gmail.com", Password = "1234", IsAdmin = false, },
                new User { Id = 3, Name = "History", Email = "AbdiwahabAli@gmail.com", Password = "1234", IsAdmin = false, }

                );
        }
    }
}
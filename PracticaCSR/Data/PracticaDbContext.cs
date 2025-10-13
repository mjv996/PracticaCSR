using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using PracticaCSR.Entities;

namespace PracticaCSR.Data
{
    public class PracticaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public PracticaDbContext(DbContextOptions<PracticaDbContext> options) 
            : base(options)
        {
            //base.OnModelCreating(new ModelBuilder());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User luis = new User()
            {
                Id = 1,
                FirstName = "Luis",
                Email = "luis@gmail.com",
                Password = "lamismadesiempre",
                LastName = "luismiguel@gmail.com",
                State = UserState.Active
            };

            modelBuilder.Entity<User>().HasData(luis);

            base.OnModelCreating(modelBuilder);
        }
    }
}

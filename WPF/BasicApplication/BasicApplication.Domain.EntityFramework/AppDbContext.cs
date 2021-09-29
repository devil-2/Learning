using BasicApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicApplication.Domain.EntityFramework
{
    public class AppDbContext:DbContext
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = INBLRWIT1PZXDB3\\SQL2014; DataBase = BasicApp;Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Menu>().OwnsOne(x => x.Rights);
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}

using Entities.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext, IRepositoryContext
    {
        public DbSet<Bike> Bikes { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().HasData(
                new Bike
                {
                    Id = 1,
                    Title = "Giant Contend AR 2 2020",
                    Type = Models.Enums.Type.Road,
                    Price = 20.99m,
                    Status = Models.Enums.Status.Free
                },
                new Bike
                {
                    Id = 2,
                    Title = "Cyclone MMXX 29 2020",
                    Type = Models.Enums.Type.Mountain,
                    Price = 18.99m,
                    Status = Models.Enums.Status.Free
                },
                new Bike
                {
                    Id = 3,
                    Title = "Trek Domane AL 3 2019",
                    Type = Models.Enums.Type.Road,
                    Price = 15.99m,
                    Status = Models.Enums.Status.Free
                }
            );
        }*/
    }
}
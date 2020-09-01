using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities.Interfaces
{
    public interface IRepositoryContext
    {
        DbSet<Bike> Bikes { get; set; }

        int SaveChanges();
    }
}
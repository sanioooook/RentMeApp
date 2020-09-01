using Entities.Interfaces;
using Entities.Models;
using Entities.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly IRepositoryContext _repositoryContext;

        public BikeRepository(IRepositoryContext repositoryContext) => _repositoryContext = repositoryContext;

        public List<Bike> GetBikes()
        {
            return _repositoryContext.Bikes.ToList();
        }

        public List<Bike> GetBikesByStatus(Status status)
        {
            return _repositoryContext.Bikes.Where(m => m.Status == status).ToList();
        } 

        public Bike GetBikeById(int id)
        {
            return _repositoryContext.Bikes.FirstOrDefault(m => m.Id == id);
        }

        public Bike CreateBike(Bike bike)
        {
            _repositoryContext.Bikes.Add(bike);
            _repositoryContext.SaveChanges();
            return _repositoryContext.Bikes.Where(m => m.Id == bike.Id).FirstOrDefault();
        }

        public void DeleteBike(Bike bike)
        {
            _repositoryContext.Bikes.Remove(bike);
            _repositoryContext.SaveChanges();
        }

        public void UpdateBike(Bike bike)
        {
            _repositoryContext.Bikes.Update(bike);
            _repositoryContext.SaveChanges();
        }
    }
}
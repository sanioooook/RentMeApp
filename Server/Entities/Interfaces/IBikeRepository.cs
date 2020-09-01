using Entities.Models;
using Entities.Models.Enums;
using System.Collections.Generic;

namespace Entities.Interfaces
{
    public interface IBikeRepository
    {
        List<Bike> GetBikes();
        List<Bike> GetBikesByStatus(Status status);
        Bike GetBikeById(int id);
        Bike CreateBike(Bike bike);
        void DeleteBike(Bike bike);
        void UpdateBike(Bike bike);
    }
}
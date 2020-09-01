using System.Collections.Generic;
using Entities.Models;
using Entities.Models.Enums;
using WebAPI.DTO;

namespace WebAPI.Interfaces
{
    public interface IBikeService
    {
        BikeForFront GetBikeById(int id);
        List<Bike> GetBikes();
        List<BikeForFront> GetFrontBikes();
        List<BikeForFront> GetBikesByStatus(Status status);
        //List<Bike> GetAvailableBikes();
        Bike CreateBike(BikeForFront bikeForFront);
        void Update(int id);
        void Delete(int id);
    }
}
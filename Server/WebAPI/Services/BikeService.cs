using System.Collections.Generic;
using WebAPI.Interfaces;
using Entities.Interfaces;
using Entities.Models;
using Entities.Models.Enums;
using WebAPI.DTO;
using System.Linq;

namespace WebAPI.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository) => this._bikeRepository = bikeRepository;

        public BikeForFront GetBikeById(int id)
        {
            Bike bike = _bikeRepository.GetBikeById(id);
            return new BikeForFront { Id = bike.Id, Title = bike.Title, Type = bike.Type, Price = bike.Price };
        }

        public List<BikeForFront> GetBikesByStatus(Status status)
        {
            List<Bike> bikes = _bikeRepository.GetBikesByStatus(status);
            return SameOperations(bikes);
        }

        public List<Bike> GetBikes()
        {
            List<Bike> bikes = _bikeRepository.GetBikes();
            return bikes;
        }

        /*public List<Bike> GetAvailableBikes()
        {
            List<Bike> bikes = _bikeRepository.GetAvailableBikes();
            return bikes;
        }*/

        public List<BikeForFront> SameOperations(List<Bike> bikes)
        {
            var bikesForFront = new List<BikeForFront>();
            bikes.ForEach(bike => bikesForFront.Add(new BikeForFront { Id = bike.Id, Price = bike.Price, Title = bike.Title, Type = bike.Type }));
            return bikesForFront;
        }

        public List<BikeForFront> GetFrontBikes()
        {
            List<Bike> bikes = _bikeRepository.GetBikes();
            return SameOperations(bikes);
        }

        public Bike CreateBike(BikeForFront bikeForFront)
        {
            return new Bike 
            { Id = _bikeRepository.CreateBike( new Bike 
            {
                Title = bikeForFront.Title, 
                Type = bikeForFront.Type, 
                Price = bikeForFront.Price, 
                Status = Status.Free}).Id };
        }
        
        public void Update(int id)
        {
            Bike fullBike = GetBikes().Where(bike => bike.Id == id).FirstOrDefault();
            switch (fullBike.Status)
            {
                case Status.Free:
                    fullBike.Status = Status.Rented;
                    break;
                case Status.Rented:
                    fullBike.Status = Status.Free;
                    break;
            }
            _bikeRepository.UpdateBike(fullBike);
        }

        public void Delete(int id)
        {
            _bikeRepository.DeleteBike(_bikeRepository.GetBikeById(id));
        }
    }
}
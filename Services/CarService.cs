using Locadora.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Services
{
    public class CarService
    {
        private readonly IMongoCollection<Car> _cars;

        public CarService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Locadora"));
            IMongoDatabase database = client.GetDatabase("Locadora");
            _cars = database.GetCollection<Car>("Cars");
        }

        public List<Car> Get()
        {
            return _cars.Find(car => true).ToList();
        }

        public Car Get(string id)
        {
            return _cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public Car Create(Car car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn)
        {
            _cars.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(Car carIn)
        {
            _cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            _cars.DeleteOne(car => car.Id == id);
        }
    }
}

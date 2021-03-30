using Locadora.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;

        public ClientService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Locadora"));
            IMongoDatabase database = client.GetDatabase("Locadora");
            _client = database.GetCollection<Client>("Client");
        }

        public List<Client> Get()
        {
            return _client.Find(car => true).ToList();
        }

        public Client Get(string id)
        {
            return _client.Find(client => client.Id == id).FirstOrDefault();
        }

        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }

        public void Update(string id, Client clientIn)
        {
            _client.ReplaceOne(client => client.Id == id, clientIn);
        }

        public void Remove(Client clientIn)
        {
            _client.DeleteOne(client => client.Id == clientIn.Id);
        }

        public void Remove(string id)
        {
            _client.DeleteOne(client => client.Id == id);
        }
    }
}


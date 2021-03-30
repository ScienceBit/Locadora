using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string FirstName { get; set; }

        [BsonElement("SobreNome")]
        public string LastName { get; set; }

        [BsonElement("EstadoCivil")]
        public string CivilStatus { get; set; }

        [BsonElement("Endereço")]
        public string Endereco { get; set; }

        [BsonElement("CPF")]
        public string Cpf { get; set; }

        [BsonElement("CNH")]
        public string Cnh { get; set; }

        [BsonElement("Login")]
        public string Login { get; set; }

        [BsonElement("Senha")]
        public string password { get; set; }

    }
}

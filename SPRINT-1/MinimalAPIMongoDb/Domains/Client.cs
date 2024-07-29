using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalAPIMongoDB.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //pegar o id do User
        [BsonElement("userid")]
        public string? UserId { get; set; }

        [BsonElement("cpf")]
        public string? CPF { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Client()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}

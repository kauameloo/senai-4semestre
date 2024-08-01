using MinimalAPIMongoDB.Domains;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MinimalAPIMongoDB.ViewModels
{
    public class OrderViewModel
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateOnly? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("productId")]
        public List<string>? ProductId { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public List<Product>? Products { get; set; }

        [BsonElement("clientId")]
        public string? ClientId { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Client? Client { get; set; }
    }
}
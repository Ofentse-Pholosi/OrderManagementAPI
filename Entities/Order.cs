using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderManagementAPI.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerPhone { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; } = null;
    }
}

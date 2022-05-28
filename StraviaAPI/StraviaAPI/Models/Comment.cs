using MongoDB.Bson.Serialization.Attributes;

namespace StraviaAPI.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String? Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Data { get; set; } = String.Empty;
    }
}

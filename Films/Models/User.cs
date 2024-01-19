using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Films.Models
{
    public class User
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public User() { }
        public User(string? id, string? name, string? password, string? role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
        }
    }
}

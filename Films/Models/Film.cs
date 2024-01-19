using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Films.Models
{
    public class Film
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? Category { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }
        public Film()
        { }
        public Film(string? id, string? name, int year, string? category, string? director, string? description)
        {
            Id = id;
            Name = name;
            Year = year;
            Category = category;
            Director = director;
            Description = description;
        }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesLibrary.Components.Models
{
    public class MoviesModel
    {
         
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Rating { get; set; }
        public int Year { get; set; }
        public int Budget { get; set; }
        public string Comments { get; set; } = "";


    }
}


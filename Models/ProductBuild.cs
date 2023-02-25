using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace ProductsCategoryAPI.Models
{
    public class ProductBuild
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductPhoto { get; set; }
        public string ProductDescripton { get; set; }
        public double ProductPrice { get; set; }
        public Categories CategoryName { get; set; }
    }
}

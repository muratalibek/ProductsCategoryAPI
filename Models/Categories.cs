using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsCategoryAPI.Models
{
    public class Categories
    {
        [BsonId] // Service Id to define primary key for Mongo Db
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Required]// to make non-nulable string property
        public string Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string GategoryDescriptoin { get; set; } = string.Empty;
        public Dictionary<string, string> ExtraFields { get; set; }
    }
}

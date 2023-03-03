using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsCategoryAPI.Models
{  
    /// <summary>
        /// Страница категории товара. На странице категорий товара должен выводится список категорий, 
        /// с возможностью добавлять новую или удалить существующую категорию. При добавлении категории нужно 
        /// добавить возможность добавлять дополнительные поля для товара этой категории, например, цвет, вес, 
        /// размер и т.д.
    /// </summary>
    public class Categories//
    {
        [BsonId] // Service Id to define primary key for Mongo Db
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Required]// to make non-nulable string property
        public string Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string GategoryDescriptoin { get; set; } = string.Empty;
        public Dictionary<string, string> ExtraFields { get; set; }//возможность добавлять дополнительные поля для товара этой категории
    }
}

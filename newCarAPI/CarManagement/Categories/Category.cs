using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManagement.Categories
{
    public class Category
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int CategoryId { get; set; }
        [BsonIgnore]
        public string CategoryLabel { get; set; }
        [BsonIgnore]
        public string CategoryDesc { get; set; }
        [BsonIgnore]
        public decimal? Price { get; set; }
    }
}
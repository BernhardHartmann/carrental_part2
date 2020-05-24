using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement
{
    public class Category
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int CategoryId { get; set; }       
        public string CategoryLabel { get; set; }        
        public string CategoryDesc { get; set; }        
        public decimal? Price { get; set; }
    }
}

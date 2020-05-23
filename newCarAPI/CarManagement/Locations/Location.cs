using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManagement.Locations
{
    public class Location
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int LocationId { get; set; }
        
        public string Streetname { get; set; }
        
        public string Streetno { get; set; }
        
        public string City { get; set; }
        
        public string Zipcode { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string Longitude { get; set; }
        
        public string Latitude { get; set; }
        
        public DateTime? Timestamp { get; set; }
        
        public string BranchName { get; set; }

        public Location()
        { }
    }
}
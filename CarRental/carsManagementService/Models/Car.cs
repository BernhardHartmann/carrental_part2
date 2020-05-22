using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carsManagementService.Models
{
    public class Car
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("_id")]
        public int CarID
        {
            get;
            set;
        }
        public int CatID
        {
            get;
            set;
        }

        public int LocID
        {
            get;
            set;
        }

        public string LocAddress
        {
            get;
            set;
        }

        public Car()
        {

        }
        public Car(Car car)
        {
            CatID = car.CatID;
            LocID = car.LocID;
        }
    }
}
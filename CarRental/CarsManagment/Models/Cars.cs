using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsManagment.Models
{
    public class Cars
    {
        [BsonElement("_id")]
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
    }
}
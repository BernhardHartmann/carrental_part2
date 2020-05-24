using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRequest
{
    public class Category
    {
        public ObjectId _id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryLabel { get; set; }
        public string CategoryDesc { get; set; }
        public decimal? Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarManagement
{
    public class Car
    {
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public int CarId { get; set; }
		public int CategoryId { get; set; }
		public int LocationId { get; set; }
		public string CarDesc { get; set; }
		public string Color { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string EngineNumber { get; set; }
		public DateTime? PurchaseDate { get; set; }
		public int? Kilometer { get; set; }
		public string Petrol { get; set; }
		public int IsAvailable { get; set; }

	}
}

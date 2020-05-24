using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarManagement
{
    public class CarsFullData
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
		//
		public string CategoryLabel { get; set; }
		public string CategoryDesc { get; set; }
		public decimal? Price { get; set; }
		//
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

		public CarsFullData(Car car, Category category, Location location)
		{

		}
	}
}

namespace CarManagement.Car
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using CarManagement.Categories;
    using CarManagement.Locations;
    using MongoDB.Bson;
	using MongoDB.Bson.Serialization.Attributes;

	public class Car
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public int CarId { get; set; }
		public Category Category { get; set; }
		public Location Location { get; set; }
		public string CarDesc { get; set; }
		public string Color { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string EngineNumber { get; set; }
		public DateTime? PurchaseDate { get; set; }
		public int? Kilometer { get; set; }
		public string Petrol { get; set; }
		public int IsAvailable { get; set; }

		public Car()
		{
		}

		public Car(Car car, string type = "post")
		{
			// check type
			CarId = car.CarId;
			Category = car.Category;
			Location = car.Location;
			CarDesc = car.CarDesc;
			Color = car.Color;
			Brand = car.Brand;
			Model = car.Model;
			EngineNumber = car.EngineNumber;
			PurchaseDate = car.PurchaseDate;
			Kilometer = car.Kilometer;
			Petrol = car.Petrol;
			IsAvailable = car.IsAvailable;
		}
		//public Car(Car car)
		//{
		//	CarID = car.CarID;
		//	CategoryID = car.CategoryID;
		//	CarType = car.CarType;
		//	registerationDate = car.registerationDate;
		//	LocationID = car.LocationID;
		//	LocationAtitue = car.LocationAtitue;
		//	LocationLAtitue = car.LocationLAtitue;
		//	Description = car.Description;
		//	Telefon = car.Telefon;
		//	Address_Country = car.Address_Country;
		//	Address_city = car.Address_city;
		//	Address_street = car.Address_street;
		//	Address_zipCode = car.Address_zipCode;
		//}
	}
}
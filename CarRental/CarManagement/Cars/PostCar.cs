using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarManagement.Car
{
	public class PostCar
	{
		public string Description { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		[BsonIgnore]
		public DateTime registerationDate { get; set; }

		public string Telefon { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
	}
}
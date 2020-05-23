namespace UserManagement.Users
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using MongoDB.Bson;
	using MongoDB.Bson.Serialization.Attributes;

	public class User
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		//[BsonRepresentation(BsonType.DateTime)]
		public DateTime registerationDate { get; set; }

		public string Telefon { get; set; }
		[BsonIgnore]
		public string Description { get; set; }

	
		public string Address { get; set; }

		public User()
		{
		}

		public User(User postUser)
		{
			Description = postUser.Description;
			FirstName = postUser.FirstName;
			LastName = postUser.LastName;
			Email = postUser.Email;
			registerationDate = postUser.registerationDate;
			Telefon = postUser.Telefon;
			Password = postUser.Password;
			Address = (postUser.Address ?? string.Empty);
		}
		
	}
}
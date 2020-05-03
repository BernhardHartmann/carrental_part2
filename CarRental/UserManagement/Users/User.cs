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

		public string Telefon { get; set; }

		public string Description { get; set; }

	
		public List<string> Address = new List<string>();

		[BsonRepresentation(BsonType.Double)]
		
		public string ImageId { get; set; }

	
		public User()
		{
		}

		public User(PostUser postUser)
		{
			Description = postUser.Description;
			FirstName = postUser.FirstName;
			LastName = postUser.LastName;
			Email = postUser.Email;
			Telefon = postUser.Telefon;
			Password = postUser.Password;
			Address = (postUser.Address ?? string.Empty).Split('\n').ToList();
		}
		public User(EditUser postUser)
		{
			Description = postUser.Description;
			FirstName = postUser.FirstName;
			LastName = postUser.LastName;
			Email = postUser.Email;
			Telefon = postUser.Telefon;
			Password = postUser.Password;
			Address = (postUser.Address ?? string.Empty).Split('\n').ToList();
		}
	
		public bool HasImage()
		{
			return !String.IsNullOrWhiteSpace(ImageId);
		}
	}
}
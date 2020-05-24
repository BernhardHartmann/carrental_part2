using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers
{
    public class Customer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string Mobile { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

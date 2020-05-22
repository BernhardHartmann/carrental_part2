using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payments.Models
{
    public class User
    {
		public string Id		 { get; set; }
		public string FirstName	 { get; set; }
		public string LastName	 { get; set; }
		public string Password	 { get; set; }
		public string Email		 { get; set; }
		public DateTime registerationDate { get; set; }
		public string Telefon	 { get; set; }
		public string Description { get; set; }
		//public List<string> Address = new List<string>();
	}
}
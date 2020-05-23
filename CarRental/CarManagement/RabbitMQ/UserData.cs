using System;
using System.Collections.Generic;

namespace PurchaseOrderConsumer.RabbitMQ
{
    public class UserData
    {        
		public string Id; 
		public string FirstName ;
		public string LastName ;
		public string Password ;
		public string Email ;
		public DateTime registerationDate ;
		public string Telefon ;
		public string Description ;
		public List<string> Address = new List<string>();

	}
}

namespace UserManagement.Users
{
    public class EditUser
    {
		public string Id { get; set; }

		public string Description { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Telefon { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }

		//public EditUser(User user)
		//{
		//	Description = user.Description;
		//	FirstName = user.FirstName;
		//	LastName = user.LastName;
		//	Email = user.Email;
		//	Password = user.Password;
		//	//Address = user.Address;

		//}
	}
}
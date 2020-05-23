namespace UserManagement.Users
{
	using System.Collections.Generic;

	public class UsersList
	{
		public IEnumerable<User> Users { get; set; }
		public UsersFilter Filters { get; set; }
	}
}
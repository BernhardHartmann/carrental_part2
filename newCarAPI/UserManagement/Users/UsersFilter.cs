namespace UserManagement.Users
{
	public class UsersFilter
	{
		public decimal? PriceLimit { get; set; }
		public int? MinimumRooms { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
	}
}
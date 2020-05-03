namespace UserManagement.App_Start
{
	using MongoDB.Driver;
	using UserManagement.Properties;
	using Users;

	public class UserManagementContext
	{
		public MongoDatabase Database;

		public UserManagementContext()
		{
			var client = new MongoClient(Settings.Default.ConnectionString);
			//var client = new MongoClient("mongodb+srv://test:test@cluster0-shard-00-01-bj19b.azure.mongodb.net/userManagement");
			var server = client.GetServer();
			Database = server.GetDatabase(Settings.Default.DatabaseName);
		}

		public MongoCollection<User> Users
		{
			get
			{
				return Database.GetCollection<User>("users");
			}
		}
	}
}








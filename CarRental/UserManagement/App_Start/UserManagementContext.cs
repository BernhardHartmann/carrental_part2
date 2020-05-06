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
			//string con = "mongodb://test:test@Cluster0-shard-0/cluster0-shard-00-00-bj19b.azure.mongodb.net:27017";
			//var client1 = new MongoClient(con);
			//var client2 = new MongoClient("mongodb://uc3neklrclokxhfeb1ra:mpKDX4ecVxJchT2qTH6E@ba6nrxnx4ynf068-mongodb.services.clever-cloud.com:27017/ba6nrxnx4ynf068");
			//var client3 = new MongoClient("mongodb" +"+" +"srv://test:test@cluster0-bj19b.azure.mongodb.net/test");
			//var server3 = client.GetServer(); 
			//var database3 = server3.GetDatabase("test");

			var server = client.GetServer();
			//Database = server.GetDatabase("userManagement");
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








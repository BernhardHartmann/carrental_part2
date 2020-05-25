using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Data
{                                           
    
    public class ConnectionClass
    {
        private string UName;
        private string PWD;
        private string HName;

        public ConnectionClass()
        {
            UName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_User"];
            PWD = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_Password"];
            HName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_Host"];
        }

        public ConnectionFactory getConnectionFactored()
        {
           return new ConnectionFactory()
            {
                UserName = UName,
                Password = PWD,
                HostName = HName
            };
        }

        public IModel getModel()
        {
            var connection = getConnectionFactored().CreateConnection();
            return connection.CreateModel();

        }

        public IBasicProperties getProperties()
        {
            return getModel().CreateBasicProperties();
        }

    }
}

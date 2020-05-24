using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationConsumer.Data
{                                           
    
    class ConnectionClass
    {
        private string UName;
        private string PWD;
        private string HName;

        public ConnectionClass()
        {
            UName = "guest";
            PWD = "guest";
            HName = "localhost";
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

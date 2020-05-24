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
            UName = "user";
            PWD = "password";
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

        public RabbitMQ.Client.QueueDeclareOk createQueue(string queueName)
        {
            var model = getModel();
            var queue = model.QueueDeclare(queueName, true, false, false, null);

            return queue;
        }

    }
}

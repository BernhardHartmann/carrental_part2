using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;

namespace CarRentalAPIGateway.RabbitMQCommunication
{
    public class RabbitMqCommunication : IRabbitMQCommunication
    {
        private IConfiguration Configuration { get; set; }
        private ConnectionFactory Factory { get; set; }
        private IConnection Connection { get; set; }
        private IModel Channel { get; set; }

        public RabbitMqCommunication(IConfiguration configuration)
        {
            Configuration = configuration;
            Factory = new ConnectionFactory()
            {
                HostName = Configuration.GetValue<string>("RabbitMQ:BrokerHostName"),
                UserName = Configuration.GetValue<string>("RabbitMQ:UserName"),
                Password = Configuration.GetValue<string>("RabbitMQ:Password")
            };
        }

        public string ReceiveMessage(string queueName)
        {
            try
            {
                string message = string.Empty;
                using (var connection = Factory.CreateConnection())
                {
                    using (var channel = Connection.CreateModel())
                    {
                        var queue = Channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                        var consumer = new EventingBasicConsumer(Channel);
                        consumer.Received += (sender, e) => 
                        {
                            var body = e.Body;
                            message = JsonConvert.SerializeObject(Encoding.UTF8.GetString(body.ToArray()));
                        };

                        Channel.BasicConsume(queueName, true, consumer);
                    }

                    return message;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool SendMessage(string message, string queueName, string exchange, string routingKey)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
                using (Connection = factory.CreateConnection())
                {
                    using (Channel = Connection.CreateModel())
                    {
                        Channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                        var json = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(json);

                        Channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: body);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
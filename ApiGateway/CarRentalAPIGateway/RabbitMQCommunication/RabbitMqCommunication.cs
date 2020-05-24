using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
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
                Password = Configuration.GetValue<string>("RabbitMQ:Password"),
                Port = Configuration.GetValue<int>("RabbitMQ:Port")
            };
        }

        public string ReceiveMessage(string queueName)
        {
            try
            {
                string message = string.Empty;
                using (Connection = Factory.CreateConnection())
                {
                    using (Channel = Connection.CreateModel())
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool SendMessage(string message, string queueName)
        {
            try
            {
                using (Connection = Factory.CreateConnection())
                {
                    using (Channel = Connection.CreateModel())
                    {
                        Channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                        var json = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(json);

                        Channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

                        return true;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
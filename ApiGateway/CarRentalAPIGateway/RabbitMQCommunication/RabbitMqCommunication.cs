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

        public RabbitMqCommunication(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConnection _connection;
        private IModel _channel;
        private string _replyQueueName;
        private QueueingBasicConsumer _consumer;

        public void CreateConnection()
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();

            //_replyQueueName = _channel.QueueDeclare("rpc_reply", true, false, false, null);

            //_consumer = new QueueingBasicConsumer(_channel);
            //_channel.BasicConsume(_replyQueueName, true, _consumer);
        }

        public string ReceiveMessage(string queueName)
        {
            try
            {
                string message = string.Empty;
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "user", Password = "password" };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.BasicQos(0, 1, false);

                        var queue = channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (sender, e) =>
                        {
                            var body = e.Body;
                            message = JsonConvert.SerializeObject(Encoding.UTF8.GetString(body.ToArray()));
                        };

                        channel.BasicConsume(queueName, false, consumer);
                    }
                }

                return message;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool SendMessage(string message, string queueName, string exchange, string routingKey)
        {
            //var props= _channel.CreateBasicProperties(); ;
            try
            {
                //var corrId = Guid.NewGuid().ToString();
                ////props = _channel.CreateBasicProperties();
                //props.ReplyTo = _replyQueueName;
                //props.CorrelationId = corrId;

                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "user", Password = "password" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: body);
                        return true;


                        //_channel.BasicPublish("", "rpc_queue", props, body);

                        //while (true)
                        //{
                        //    var ea = _consumer.Queue.Dequeue();

                        //    if (ea.BasicProperties.CorrelationId != corrId) continue;

                        //    var authCode = Encoding.UTF8.GetString(ea.Body);
                        //    return true;
                        //}
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
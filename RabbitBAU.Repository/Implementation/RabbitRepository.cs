using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitBAU.Repository
{
    public class RabbitRepository
    {
        public RabbitRepository()
        {

        }

        private IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.Uri = new Uri("amqp://bau:bau@localhost:5672/bau");
            return factory.CreateConnection();
        }


        public void PublishToQueue(string queueName, string itemToSend)
        {
            using (IConnection connection = GetConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    //Önemli! Bu satır mutlaka olmalı. Henüz oluşturulmamış bir kuyruğa publish yapmaya çalışmak hataya sebep olur. 
                    //Kuyruk zaten varsa alt satırdaki kodun çalışmasının herhangi bir zararı yoktur.
                    channel.QueueDeclare(queueName, false, false, false, null);

                    //Json objeleri byte dizisine dönüştürerek kuyruğa yollarız.
                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(itemToSend));
                }
            }
        }

        public string ReadFromQueue(string queueName)
        {
            using (IConnection connection = GetConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    //Önemli! Bu satır mutlaka olmalı. Henüz oluşturulmamış bir kuyruğa publish yapmaya çalışmak hataya sebep olur. 
                    //Kuyruk zaten varsa alt satırdaki kodun çalışmasının herhangi bir zararı yoktur.
                    channel.QueueDeclare(queueName, false, false, false, null);

                    //Json objeleri byte dizisine dönüştürerek kuyruğa yollarız.
                    var result = channel.BasicGet(queueName, true);

                    return Encoding.UTF8.GetString(result.Body);
                }
            }
        }

        public void CreateConsumer(string queueName)
        {
            IConnection connection = GetConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (obj, a) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(a.Body));

            };


            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.Write(Encoding.UTF8.GetString(e.Body));
        }
    }
}

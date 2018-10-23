using RabbitBAU.Repository;
using System;

namespace RabbitBAU.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //EventHandler<BasicDeliverEventArgs> handler = (obj){ };
            RabbitRepository repository = new RabbitRepository();

            //repository.PublishToQueue("test", "selam");

            //Console.Write(repository.ReadFromQueue("test"));

            repository.CreateConsumer("test");

            Console.ReadLine();
        }
        
    }
}

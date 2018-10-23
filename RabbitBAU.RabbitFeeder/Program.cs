using RabbitBAU.Repository;
using System;

namespace RabbitBAU.RabbitFeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitRepository repository = new RabbitRepository();

            do
            {
                Console.Write("Mesajınızı giriniz:");
                string mesaj = Console.ReadLine();
                repository.PublishToQueue("test", mesaj);
                Console.WriteLine();

            } while (true);
        }
    }
}

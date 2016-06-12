using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RdKafka;
using System.Text;

namespace DC_ServiceInjection
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var brokerList = "127.0.0.1:9092"; 
            string topicName="test";
            using (Producer producer = new Producer(brokerList))
            using (Topic topic = producer.Topic(topicName))
            {
                Console.WriteLine($"{producer.Name} producing on {topic.Name}. q to exit.");

                string text;    
                while ((text = Console.ReadLine()) != "q")
                {
                    byte[] data = Encoding.UTF8.GetBytes(text);
                    Task<DeliveryReport> deliveryReport = topic.Produce(data);
                    var unused = deliveryReport.ContinueWith(task =>
                    {
                        Console.WriteLine($"Partition: {task.Result.Partition}, Offset: {task.Result.Offset}");
                    });
                }
            }


            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}

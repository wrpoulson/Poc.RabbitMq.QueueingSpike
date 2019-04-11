using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class WorkQueues : SubscribeBase, ISubscribe
  {
    public WorkQueues()
    {
      ExchangeName = string.Empty;
      QueueName = "task_queue_durable";
      RoutingKey = string.Empty;
    }

    public void Start(string[] args)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.QueueDeclare(queue: QueueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
          var body = ea.Body;
          var message = Encoding.UTF8.GetString(body);
          Console.WriteLine($" [x] Received {message}");

          int dots = message.Split('.').Length - 2;
          Thread.Sleep(dots * 1000);

          Console.WriteLine($" [x] Done processing '{message}' in {dots} seconds.");
        };

        channel.BasicConsume(queue: QueueName,
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
      }
    }
  }
}

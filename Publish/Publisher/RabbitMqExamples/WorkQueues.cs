
using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher.RabbitMqExamples
{
  public class WorkQueues : PublishBase, IPublish
  {
    public WorkQueues()
    {
      ExchangeName = string.Empty;
      QueueName = "task_queue_durable";
      RoutingKey = "task_queue_durable";
    }

    public override void SendMessage(string message)
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

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: ExchangeName,
                             routingKey: RoutingKey,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
      }
    }
  }
}

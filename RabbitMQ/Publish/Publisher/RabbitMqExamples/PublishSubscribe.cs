using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher.RabbitMqExamples
{
  public class PublishSubscribe : PublishBase, IPublish
  {
    public PublishSubscribe()
    {
      ExchangeName = "logs";
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }

    public override void SendMessage(string message)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.ExchangeDeclare(ExchangeName, "fanout");

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

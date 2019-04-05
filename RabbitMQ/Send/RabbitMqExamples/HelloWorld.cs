using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Send.RabbitMqExamples
{
  public class HelloWorld : ISend
  {
    public void Start(string[] args)
    {
      var queueName = "hello";
      SendMessage(queueName, "Start up default message.");
      while (true)
      {
        Console.WriteLine(" Enter a new message to queue or simply press enter to [exit].");
        var userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
          SendMessage(queueName, userInput);
        }
        else
        {
          break;
        }
      }
    }

    private static void SendMessage(string queue, string message)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.QueueDeclare(queue: queue,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                             routingKey: queue,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
      }
    }
  }
}

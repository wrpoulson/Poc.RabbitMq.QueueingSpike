using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Send.RabbitMqExamples
{
  public class WorkQueues : ISend
  {
    public void Start(string[] args)
    {
      var queueName = "task_queue";
      SendMessage(queueName, GetMessage(args));
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

    private static string GetMessage(string[] args)
    {
      var testArgs = new string[] { "Start up default message." };
      return string.Join(" ", args.Length > 0 ? args : testArgs);
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

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: queue,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
      }
    }
  }
}

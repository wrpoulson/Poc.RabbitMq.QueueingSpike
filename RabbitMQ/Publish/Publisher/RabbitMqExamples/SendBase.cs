using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace Publisher.RabbitMqExamples
{
  public abstract class SendBase
  {
    private int messageCount = 0;

    public void DispatchInitialMessages(string queueName, string[] args, List<string> messages)
    {
      if (messages == null || !messages.Any())
      {
        var messageFromArgs = GetMessageFromArguments(args);
        SendMessage(queueName, messageFromArgs);
      }
      else
      {
        messages.ForEach(delegate (string message)
        {
          SendMessage(queueName, $"Msg #{++messageCount} - {message}");
        });
      }
    }

    public void SendMessage(string queue, string message)
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

    public string GetMessageFromArguments(string[] args)
    {
      var testArgs = new string[] { "Start up default message." };
      return string.Join(" ", args.Length > 0 ? args : testArgs);
    }
  }
}

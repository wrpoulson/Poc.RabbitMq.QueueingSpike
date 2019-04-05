using System;
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public class HelloWorld : SendBase, ISend
  {
    public void Start(string[] args, List<string> messages)
    {
      var queueName = "hello";

      DispatchInitialMessages(queueName, args, messages);

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
  }
}

using System;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Charlie
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Charlie";
      new SharedSubscriber().Start(args);
    }
  }
}

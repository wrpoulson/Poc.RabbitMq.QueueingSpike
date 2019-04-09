using System;
using System.Threading;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Charlie
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Charlie";
      bool delayStart = true;
      ISubscribe subscriber;

      //subscriber = new HelloWorld();
      //subscriber = new WorkQueues();
      //subscriber = new PublishSubscribe();
      subscriber = new Routing(); args = new string[] { "critical" };
      //subscriber = new Topics();
      //subscriber = new Rpc();

      if (delayStart) Thread.Sleep(500);
      subscriber.Start(args);
    }
  }
}

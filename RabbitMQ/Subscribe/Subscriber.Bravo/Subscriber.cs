using System;
using Receive.Shared.RabbitMqExamples;

namespace Subscriber.Bravo
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Bravo";

      IReceive receiver;

      //receiver = new HelloWorld();
      receiver = new WorkQueues();
      //receiver = new PublishSubscribe();
      //receiver = new Routing();
      //receiver = new Topics();
      //receiver = new Rpc();

      receiver.Start(args);
    }
  }
}

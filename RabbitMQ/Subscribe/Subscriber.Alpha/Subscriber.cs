using System;
using Receive.Shared.RabbitMqExamples;

namespace Subscriber.Alpha
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Alpha";

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

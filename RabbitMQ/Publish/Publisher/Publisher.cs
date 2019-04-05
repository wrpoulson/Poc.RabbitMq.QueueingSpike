using System;
using Publisher.RabbitMqExamples;
using RabbitMqExamples.Data;

namespace Publisher
{
  class Publisher
  {
    static void Main(string[] args)
    {
      Console.Title = "Publisher";

      ISend sender;

      //sender = new HelloWorld();
      sender = new WorkQueues();
      //sender = new PublishSubscribe();
      //sender = new Routing();
      //sender = new Topics();
      //sender = new Rpc();

      sender.Start(args, new Messages().RandomDefaultStartMessages());
    }
  }
}

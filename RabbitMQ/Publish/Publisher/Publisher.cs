using System;
using System.Threading;
using Publisher.RabbitMqExamples;
using RabbitMqExamples.Data;

namespace Publisher
{
  class Publisher
  {
    static void Main(string[] args)
    {
      Console.Title = "Publisher";
      IPublish publisher;
      bool delayStart = true;

      //publisher = new HelloWorld();
      //publisher = new WorkQueues();
      //publisher = new PublishSubscribe();
      publisher = new Routing();
      //publisher = new Topics();
      //publisher = new Rpc();

      if (delayStart) Thread.Sleep(500);
      publisher.Start(args, new Messages().RandomDefaultStartMessages());
    }
  }
}

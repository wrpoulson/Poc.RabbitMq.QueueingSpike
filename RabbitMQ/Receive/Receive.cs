using Receive.Shared.RabbitMqExamples;

namespace Receive
{
  class Program
  {
    static void Main(string[] args)
    {
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

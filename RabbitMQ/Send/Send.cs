using Send.RabbitMqExamples;

namespace Send
{
  class Send
  {
    static void Main(string[] args)
    {
      ISend sender;

      //sender = new HelloWorld();
      sender = new WorkQueues();
      //sender = new PublishSubscribe();
      //sender = new Routing();
      //sender = new Topics();
      //sender = new Rpc();

      sender.Start(args);
    }
  }
}

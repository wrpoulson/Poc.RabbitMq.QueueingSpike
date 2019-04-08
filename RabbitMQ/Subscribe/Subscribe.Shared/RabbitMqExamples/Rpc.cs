using System;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class Rpc : SubscribeBase, ISubscribe
  {
    public Rpc()
    {
      ExchangeName = string.Empty;
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }

    public void Start(string[] args)
    {
      throw new NotImplementedException();
    }
  }
}

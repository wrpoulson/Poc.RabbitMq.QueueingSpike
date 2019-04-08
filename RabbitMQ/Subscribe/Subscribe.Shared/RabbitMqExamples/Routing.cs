using System;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class Routing : SubscribeBase, ISubscribe
  {
    public Routing()
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

using System;
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public class Rpc : PublishBase, IPublish
  {
    public Rpc()
    {
      ExchangeName = string.Empty;
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }
  }
}

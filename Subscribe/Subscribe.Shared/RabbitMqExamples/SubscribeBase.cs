
namespace Subscribe.Shared.RabbitMqExamples
{
  public abstract class SubscribeBase
  {
    public string ExchangeName { get; set; }

    public string QueueName { get; set; }

    public string RoutingKey { get; set; }
  }
}


namespace Publisher.RabbitMqExamples
{
  public class HelloWorld : PublishBase, IPublish
  {
    public HelloWorld()
    {
      ExchangeName = string.Empty;
      QueueName = "hello";
      RoutingKey = "hello";
    }
  }
}

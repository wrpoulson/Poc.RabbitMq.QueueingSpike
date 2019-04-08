
namespace Publisher.RabbitMqExamples
{
  public class WorkQueues : PublishBase, IPublish
  {
    public WorkQueues()
    {
      ExchangeName = string.Empty;
      QueueName = "task_queue";
      RoutingKey = "task_queue";
    }
  }
}

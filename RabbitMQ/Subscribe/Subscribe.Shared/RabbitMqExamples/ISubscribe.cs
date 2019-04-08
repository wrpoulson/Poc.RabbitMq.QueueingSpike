
namespace Subscribe.Shared.RabbitMqExamples
{
  public interface ISubscribe
  {
    string QueueName { get; }

    void Start(string[] args);
  }
}

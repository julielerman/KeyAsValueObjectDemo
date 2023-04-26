
namespace KeyAsValueObjectDemo.SharedKernel
{
  /// <summary>
  /// Base types for all Entities which track state using a given Id.
  /// </summary>
  public abstract class BaseEntity
  {
    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
  }


    public abstract class BaseDomainEvent : MediatR.INotification
    {
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}

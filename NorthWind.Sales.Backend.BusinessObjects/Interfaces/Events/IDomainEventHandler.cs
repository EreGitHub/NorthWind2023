namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Events;

public interface IDomainEventHandler<EventType> where EventType : IDomainEvent
{
    ValueTask Handle(EventType eventTypeInstance);
}

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Events;
//estamos restringiendo el tipo de evento que puede manejar este manejador de eventos
public interface IDomainEventHandler<EventType> where EventType : IDomainEvent
{
    ValueTask Handle(EventType eventTypeInstance);
}

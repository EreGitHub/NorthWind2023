namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Events;
//eso es para lanzar y notificar a los manejadores de eventos
public interface IDomainEventHub<EventType> where EventType : IDomainEvent
{
    ValueTask Raise(EventType eventTypeInstance);
}

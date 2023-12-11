namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class DomainEventHub<EventType> : IDomainEventHub<EventType> where EventType : IDomainEvent
{
    readonly IEnumerable<IDomainEventHandler<EventType>> EventHandlers;

    public DomainEventHub(IEnumerable<IDomainEventHandler<EventType>> eventHandlers) => EventHandlers = eventHandlers;

    public async ValueTask Raise(EventType eventTypeInstance)
    {
        foreach (var Handler in EventHandlers)
            await Handler.Handle(eventTypeInstance);
    }
}

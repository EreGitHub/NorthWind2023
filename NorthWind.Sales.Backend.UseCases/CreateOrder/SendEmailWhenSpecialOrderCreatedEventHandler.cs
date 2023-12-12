namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class SendEmailWhenSpecialOrderCreatedEventHandler(IMailService mailService)
    : IDomainEventHandler<SpecialOrderCreatedEvent>
{
    public ValueTask Handle(SpecialOrderCreatedEvent eventTypeInstance) =>
        mailService.SendEmailToAdministrator(CreateOrderMessages.SendEmailSubject,
            string.Format(
                CreateOrderMessages.SendEmailBodyTemplate,
                eventTypeInstance.OrderId,
                eventTypeInstance.ProductsCount));
}

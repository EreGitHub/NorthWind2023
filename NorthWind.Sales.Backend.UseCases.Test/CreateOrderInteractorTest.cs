namespace NorthWind.Sales.Backend.UseCases.Test;

public class CreateOrderInteractorTest
{
    [Fact]
    public async void CreateOrder_ReturnsIdGreatherThanZero()
    {
        //Arrange
        var StupRepository = new RepositoryFake();
        var MockPresenter = new PresenterFake();
        var Order = new CreateOrderDto
        (
            customerId: "ALFKI",
            shipAddress: "3 oriente",
            shipCity: "Tarija",
            shipCountry: "Bolivia",
            shipPostalCode: "72000",
            orderDetails: new List<CreateOrderDetailDto> {
                new CreateOrderDetailDto
                (
                    productId : 1,
                    quantity : 15,
                    unitPrice : 17
                )
            }
        );
        CreateOrderInteractor Interactor = new CreateOrderInteractor(MockPresenter, StupRepository);

        //Act
        await Interactor.Handle(Order);

        //Assert
        Assert.True(MockPresenter.OrderId > 0);
        Assert.True(MockPresenter.Order.ShippingType == BusinessObjects.Enums.ShippingType.Road);
    }
}
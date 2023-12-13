namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway : ICreateOrderGateway
{
    readonly HttpClient Client;

    public CreateOrderGateway(HttpClient client) => Client = client;

    public async Task<int> CreateOrderAsync(CreateOrderDto order)
    {
        var Response = await Client.PostAsJsonAsync(Endpoints.CreateOrder, order);

        return await Response.Content.ReadFromJsonAsync<int>();
    }
}

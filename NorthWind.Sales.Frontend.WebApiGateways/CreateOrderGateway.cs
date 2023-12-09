namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway : ICreateOrderGateway
{
    readonly HttpClient Client;

    public CreateOrderGateway(HttpClient client) => Client = client;

    public async Task<int> CreateOrderAsync(CreateOrderDto order)
    {
        int OrderId = 0;
        var response = await Client.PostAsJsonAsync(Endpoints.CreateOrder, order);

        if (response.IsSuccessStatusCode)
        {
            OrderId = await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
        return OrderId;
    }
}

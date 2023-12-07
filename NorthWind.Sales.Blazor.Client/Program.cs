var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddNorthWindSalesServices(httpClient => {
    httpClient.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
});

await builder.Build().RunAsync();

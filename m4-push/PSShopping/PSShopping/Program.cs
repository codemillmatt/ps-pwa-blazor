using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PSShopping;
using PSShopping.Services;

//string shoppingAPIBaseAddress = "https://pwashoppingapi.azurewebsites.net";
string shoppingAPIBaseAddress = "https://localhost:7294";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton(ps => new ProductService(new HttpClient() { 
    BaseAddress = new Uri(shoppingAPIBaseAddress)
}));

builder.Services.AddSingleton(cs => new CouponService(new HttpClient()
{
    BaseAddress = new Uri(shoppingAPIBaseAddress)
}));

await builder.Build().RunAsync();

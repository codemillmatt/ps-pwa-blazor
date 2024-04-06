using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PSShopping;
using PSShopping.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ProductService>(ps => new ProductService(new HttpClient() { 
    //BaseAddress = new Uri("https://localhost:7294") 
    
    // enter the address of the server that has the API installed on it
    //BaseAddress = new Uri("https://EXTERNAL_SERVER_ADDRESS")
}));

await builder.Build().RunAsync();

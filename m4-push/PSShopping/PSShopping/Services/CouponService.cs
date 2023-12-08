using PSShopping.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace PSShopping.Services
{
    public class CouponService
    {
        HttpClient client;

        public CouponService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await client.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}

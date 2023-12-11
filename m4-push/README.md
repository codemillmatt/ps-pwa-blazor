# Push Notifications

In this module we add push support for our PWA application.

## Solution Structure

The overall solution is composed of 3 projects:

* PSShopping => the Blazor project
* PSShopping.API => a minimal web API that returns hardcoded values. You can pretend it's a more fully functioning API.
* PSShopping.Shared => a project that contains classes that are used in both of the projects above.

## Takeaways

Make sure you generate the keys from vapid at https://tools.reactpwa.com/vapid

We also get to use some JavaScript interopt in this module. Checkout **PSShopping/Pages/Coupon.razor** for an example of setting it up.

**PSShopping/wwwroot/pushNotifications.js** is where the subscriptions take place.

**PSShopping/wwwroot/service-worker.published.js** is where the listener is to receive the push and handle any click events from it.

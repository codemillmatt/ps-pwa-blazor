# Service Workers and Offline Support

In this module we add offline support to the Blazor PWA app including how to specify assets to cache and which to never cache.

## Solution Structure

The overall solution is composed of 3 projects:

* PSShopping => the Blazor project
* PSShopping.API => a minimal web API that returns hardcoded values. You can pretend it's a more fully functioning API.
* PSShopping.Shared => a project that contains classes that are used in both of the projects above.

## Takeaways

The application itself remains unchanged. We're only updating the `service-worker-published.js` in this module.

See line 43 in `service-worker-published.js` for an example of how to specify that a route always get rendered and not cached.

## Notes

* The `service-worker-assets.js` file only gets created in the **bin** directory after a publish.
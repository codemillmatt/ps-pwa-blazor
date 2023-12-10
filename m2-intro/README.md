# Introduction to Developing PWAs with Blazor

The project in this module shows a small Blazor application and how it can be made into a Progressive Web App.

## Solution Structure

The overall solution is composed of 3 projects:

* PSShopping => the Blazor project
* PSShopping.API => a minimal web API that returns hardcoded values. You can pretend it's a more fully functioning API.
* PSShopping.Shared => a project that contains classes that are used in both of the projects above.

## Takeaways

This module was all about showing how a "normal" Blazor application can become a PWA with minimal code changes. The project structure of the Blazor application is the same as any other Blazor app you've dealt with before. Blazor functionality - razor files, etc - work the same as they did before.

To "PWA-ify" it, check out `./PSShopping/PSShopping/wwwroot/manifest.json`

## Notes

If you're going to run the solution, make sure **PSShopping.API** starts on port 7294. It should, but if it doesn't check the **./PSShopping.API/Properties/launchSettings.json**.
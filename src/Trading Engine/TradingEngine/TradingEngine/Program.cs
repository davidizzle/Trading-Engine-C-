using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TradingEngineServer.Core;

// You can only have one Program.cs (main) in C#, which is an OOP oriented language.
// using "using" because I want to dispose of this engine when the program terminates!
// using in the context of an I disposable object, what is it? 
// Gets rid of managed resources so that there is no leak in resources
using var engine = TradingEngineServerHostBuilder.BuildTradingEngineServer();

// This engine is now a host, it is no longer of type TradingEngineService 
// we have registered it as a service we would like to host
// Therefore when we call it we are now getting back our server
// but an object of type IHost
// We will store this service provider in this globally accessible static class called
// TradingEngineServerServiceProvider
TradingEngineServerServiceProvider.ServiceProvider = engine.Services;

{
    using var scope = TradingEngineServerServiceProvider.ServiceProvider.CreateScope();

    // A cancellation token will allow you to cancel a main thread, a backrun thread, etc. etc.
    // ConfigureAwait because we don't care about returning after this await 
    await engine.RunAsync().ConfigureAwait(false);
}



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    // Sealed means nobody can override the contents of the method of this class
    public sealed class TradingEngineServerHostBuilder
    {
        // Instead of writing Microsoft.Extensions.Hosting.IHost, we just write using that namespace
        // This static method needs to return the host
        public static IHost BuildTradingEngineServer()
            => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Inject dependencies that we need to from the actual appsettings.json
                // We will use the context object, which will allow us to index configuration
                // Start with configuration, include the using Microsoft.Extensions.DependencyInjection
                services.AddOptions();
                // Configure service to recognize TradingEngineConfiguration object exists
                // context.Configuration is a representation of the apps settings.json file
                // We need to map the values from appsettings.json into TradingEngineServerConfiguration object
                services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

                // Now we add the singleton, presumably an exclusive mutual association between an interface and a class.
                // By way of background:
                // Apparenty, if we rewrite another singleton associating an interface to another class, whatever gets run last prevails.
                services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

                // Add hosted service. Literally instantiate this service running indefinitely with Microsoft library.
                services.AddHostedService<TradingEngineServer>();
            }).Build();
        // Whenever when we create a service we take in the context in which the service will be built
        // which will include various configuration objects. We will call/set appsettings objects
        // in our service here.
        // We will also want to add several services, such as a Singleton service, or Options, or Hosted Service.

    }
}
 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;


namespace TradingEngineServer.Core
{
    sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ILogger<TradingEngineServer> _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfig;

        // Constructor 
        public TradingEngineServer(ILogger<TradingEngineServer> logger,
            IOptions<TradingEngineServerConfiguration> config)
        {
            // We include a logger, and a server configuration. This is called name coalescing
            // If true assign it otherwise throw Exception
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tradingEngineServerConfig = config.Value ?? throw new ArgumentNullException(nameof(config));
        }

        // We do not actually need to have this method. BackgroundService will call this for us
        // It is helpful to have it for completion, in case we want to explicitly call it ourselves
        // as opposed to having Microsoft Hosting calling it for us!
        public Task Run(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Starting {nameof(TradingEngineServer)}");
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            _logger.LogInformation($"Stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}

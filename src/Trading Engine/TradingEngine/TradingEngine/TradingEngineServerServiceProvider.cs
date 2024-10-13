using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Core
{
    // A static class will be instantiated at the beginning of the program or whenever it's called
    // or when the program thinks it needs to be determinated
    // It is not deterministic 
    public static class TradingEngineServerServiceProvider
    {
        // method
        public static IServiceProvider ServiceProvider { get; set; }
    }
}

 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TradingEngineServer.Logging
{
    public interface ILogger
    {
        // module represents where in the code was this called, what class
        // No need to implement them, forward them to the protected method in the abstrat class
        // => is forward
        void Debug(string module, string message);
        void Debug(string module, Exception exception); 

        void Information(string module, string message);
        void Information(string module, Exception exception);

        void Warning(string module, string message);
        void Warning(string module, Exception exception);
        void Error(string module, string message);
        void Error(string module, Exception exception);

    }
}

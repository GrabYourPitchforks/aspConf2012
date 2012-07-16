using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace StockTicker
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new ExternalTickerService().Subscribe(new MyTickerObserver());
        }

        private sealed class MyTickerObserver : IObserver<decimal>
        {
            public void OnCompleted()
            {
                TickerWebSocketHandler.BroadcastToAll("Completed.");
            }

            public void OnError(Exception error)
            {
                TickerWebSocketHandler.BroadcastToAll("Error.");
            }

            public void OnNext(decimal value)
            {
                TickerWebSocketHandler.BroadcastToAll(value.ToString());
            }
        }
    }
}

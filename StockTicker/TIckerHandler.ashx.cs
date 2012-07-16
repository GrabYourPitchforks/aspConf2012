using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace StockTicker
{
    public class TIckerHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.AcceptWebSocketRequest(new TickerWebSocketHandler());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
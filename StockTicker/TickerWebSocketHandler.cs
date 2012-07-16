using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTicker
{
    public class TickerWebSocketHandler : WebSocketHandler
    {
        private static readonly WebSocketCollection _allSubscribers = new WebSocketCollection();

        public static void BroadcastToAll(string message)
        {
            _allSubscribers.Broadcast(message);
        }

        public override void OnOpen()
        {
            _allSubscribers.Add(this);
        }
    }
}

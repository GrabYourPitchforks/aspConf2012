using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketsDemo
{
    public class EchoWebSocketHandler : WebSocketHandler
    {
        private int _msgNum;

        public override void OnMessage(string message)
        {
            // prepend the current message number and time, then echo the message
            Send(String.Format("Message {0} at {1}: {2}", ++_msgNum, DateTime.Now, message));
        }
    }
}

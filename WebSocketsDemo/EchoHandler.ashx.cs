using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketsDemo
{
    public class EchoHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.AcceptWebSocketRequest(new EchoWebSocketHandler());
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

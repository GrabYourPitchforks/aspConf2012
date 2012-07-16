using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace BuildFromScratch
{
    /// <summary>
    /// Summary description for EchoHandler
    /// </summary>
    public class EchoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.AcceptWebSocketRequest(WebSocketProcessRequest);
        }

        private static async Task WebSocketProcessRequest(AspNetWebSocketContext context)
        {
            byte[] bytes = new byte[4096];

            while (true)
            {
                var result = context.WebSocket.ReceiveAsync(new ArraySegment<byte>(bytes), CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    return;
                }

                context.WebSocket.SendAsync(new ArraySegment<byte>(bytes, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None).Wait();
            }
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
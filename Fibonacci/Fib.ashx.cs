using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Fibonacci
{
    // This simple handler inefficiently calculates the nth Fibonacci number.
    // Actually, there's an integer overflow for large 'n', so the result isn't correct, but we'll ignore that for now. :)
    public class Fib : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            ulong n = UInt64.Parse(context.Request.QueryString["n"]);
            ulong retVal = CalculateFibonnaciNumber(n);

            context.Response.ContentType = "text/plain";
            context.Response.Write(retVal);
        }

        private static ulong CalculateFibonnaciNumber(ulong n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            ulong x = 1; // this will be F(n-2)
            ulong y = 1; // this will be F(n-1)

            for (uint i = 2; i < n; i++)
            {
                ulong z = x + y;
                x = y;
                y = z;
            }

            return x + y; // F(n) = F(n-1) + F(n-2)
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

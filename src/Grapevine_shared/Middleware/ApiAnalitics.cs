using Grapevine.Interfaces.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapevine.Middleware
{
    static class ApiAnalitics
    {
        private static int startTimestamp;
        private static volatile int requestCountTotal = 0;
        private static volatile int requestCountActive = 0;

        public static void Init()
        {
            startTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static int GerCountActiveRequest()
        {
            return requestCountActive;
        }

        public static int GerAvgRequestPerSecond()
        {
            int timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return requestCountTotal / (timestamp - startTimestamp);
        }

        internal static void BeginBefore(IHttpContext context)
        {
            requestCountActive++;
        }

        internal static void BeginAfter(IHttpContext context)
        {
            requestCountTotal++;
            requestCountActive--;
        }

    }
}

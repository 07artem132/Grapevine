using Grapevine.Interfaces.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapevine.Middleware
{
    static class ApiAuth
    {
        internal static void Begin(IHttpContext context)
        {
            //todo какая-то проверка клиента
            //например, ограничение числа запросов
        }

    }
}

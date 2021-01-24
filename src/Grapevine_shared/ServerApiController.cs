using CustomLogger_shared;
using Grapevine.Middleware;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grapevine
{
    class ServerApiController
    {
        RestServer server;
        IServerSettings serverSettings;

        public ServerApiController(string Host= "0.0.0.0", string port = "55000")
        {
            serverSettings = new ServerSettings
            {
                Host = "0.0.0.0",
                Port = port,
                Logger = new Grapevine.CustomLogger.GrapevineLogger(LogConfig.LogLevel),
                EnableThrowingExceptions = false
            };

            ApiAnalitics.Init();
        }

        public void Start()
        {
            server = new RestServer(serverSettings);

            server.Router.SendExceptionMessages = false;

            server.Router.BeforeRouting += new RoutingEventHandler(ApiAuth.Begin);
            server.Router.BeforeRouting += new RoutingEventHandler(ApiAnalitics.BeginBefore);
            server.Router.AfterRouting += new RoutingEventHandler(ApiAnalitics.BeginAfter);
            try
            {
                server.Start();
            }
            catch (Exception e)
            {
                server.Logger.Fatal($"Не удалось запустить сервер,->netsh http add urlacl url=http://+:{serverSettings.Port}/ user=ПОЛЬЗОВАТЕЛЬ", e);
            }
        }

        public void Stop()
        {
            server.Stop();
            server.Dispose();
        }
    }
}

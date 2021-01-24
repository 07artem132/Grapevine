using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLevel = Grapevine.Interfaces.Shared.LogLevel;
using Grapevine;
using Grapevine.Interfaces.Shared;

namespace Grapevine.CustomLogger
{
    public class GrapevineLogger : IGrapevineLogger
    {
        public LogLevel Level { get; set; }
        private static Logger logger = LogManager.GetLogger("core.API");

        public string DateFormat => @"M/d/yyyy hh:mm:ss tt";

        public DateTime RightNow => DateTime.Now;

        public GrapevineLogger(NLog.LogLevel logLevel)
        {
            switch (logLevel.Ordinal)
            {
                case 0:
                    Level = LogLevel.Trace;
                    break;
                case 1:
                    Level = LogLevel.Debug;

                    break;
                case 2:
                    Level = LogLevel.Info;

                    break;
                case 3:
                    Level = LogLevel.Warn;

                    break;
                case 4:
                    Level = LogLevel.Error;

                    break;
                case 5:
                    Level = LogLevel.Fatal;
                    break;
                default:
                    Level = LogLevel.Info;
                    break;
            }
        }

        public GrapevineLogger(LogLevel level)
        {
            Level = level;
        }

        public void Log(LogEvent evt)
        {
            if (evt.Level > Level) return;
            logger.Log(LogEventInfo.Create(LogLevelConvert(evt.Level), "core.API", CreateMessage(evt)));
        }

        public static NLog.LogLevel LogLevelConvert(LogLevel logEvent)
        {
            switch (logEvent)
            {
                case LogLevel.Fatal:
                    return NLog.LogLevel.Fatal;
                case LogLevel.Error:
                    return NLog.LogLevel.Error;
                case LogLevel.Warn:
                    return NLog.LogLevel.Warn;
                case LogLevel.Info:
                    return NLog.LogLevel.Info;
                case LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case LogLevel.Trace:
                    return NLog.LogLevel.Trace;
                default:
                    return NLog.LogLevel.Info;
            }
        }

        public void Trace(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Trace, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Trace(string message)
        {
            Log(new LogEvent { Level = LogLevel.Trace, DateTime = RightNow, Message = message });
        }

        public void Trace(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Trace, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        public void Debug(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Debug, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Debug(string message)
        {
            Log(new LogEvent { Level = LogLevel.Debug, DateTime = RightNow, Message = message });
        }

        public void Debug(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Debug, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        public void Info(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Info, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Info(string message)
        {
            Log(new LogEvent { Level = LogLevel.Info, DateTime = RightNow, Message = message });
        }

        public void Info(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Info, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        public void Warn(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Warn, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Warn(string message)
        {
            Log(new LogEvent { Level = LogLevel.Warn, DateTime = RightNow, Message = message });
        }

        public void Warn(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Warn, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        public void Error(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Error, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Error(string message)
        {
            Log(new LogEvent { Level = LogLevel.Error, DateTime = RightNow, Message = message });
        }

        public void Error(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Error, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        public void Fatal(object obj)
        {
            Log(new LogEvent { Level = LogLevel.Fatal, DateTime = RightNow, Message = obj.ToString() });
        }

        public void Fatal(string message)
        {
            Log(new LogEvent { Level = LogLevel.Fatal, DateTime = RightNow, Message = message });
        }

        public void Fatal(string message, Exception ex)
        {
            Log(new LogEvent { Level = LogLevel.Fatal, DateTime = RightNow, Message = ExceptionToString(message, ex) });
        }

        private string CreateMessage(LogEvent evt)
        {
            if (evt.Exception == null)
                return $"{RightNow.ToString(DateFormat)}\t{evt.Level}\t{evt.Message}";
            else
                return $"{RightNow.ToString(DateFormat)}\t{evt.Level}\t{evt.Message}\r\n{evt.Exception.StackTrace}";
        }

        private static string ExceptionToString(string message, Exception ex)
        {
            return $"{message}:{ex.Message}\r\n{ex.StackTrace}";
        }


    }
}

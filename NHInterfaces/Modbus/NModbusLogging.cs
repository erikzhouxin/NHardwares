using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace System.Data.NModbus
{
    public class ConsoleModbusLogger : ModbusLogger
    {
        private const int LevelColumnSize = 15;
        private static readonly string BlankHeader = Environment.NewLine + new string(' ', LevelColumnSize);

        public ConsoleModbusLogger(LoggingLevel minimumLoggingLevel = LoggingLevel.Debug)
            : base(minimumLoggingLevel)
        {
        }

        protected override void LogCore(LoggingLevel level, string message)
        {
            message = message?.Replace(Environment.NewLine, BlankHeader);

            Console.WriteLine($"[{level}]".PadRight(LevelColumnSize) + message);
        }
    }
    /// <summary>
    /// Writes using Debug.WriteLine().
    /// </summary>
    public class DebugModbusLogger : ModbusLogger
    {
        private const int LevelColumnSize = 15;
        private static readonly string BlankHeader = Environment.NewLine + new string(' ', LevelColumnSize);

        public DebugModbusLogger(LoggingLevel minimumLoggingLevel = LoggingLevel.Debug)
            : base(minimumLoggingLevel)
        {
        }

        protected override void LogCore(LoggingLevel level, string message)
        {
            message = message?.Replace(Environment.NewLine, BlankHeader);

            Debug.WriteLine($"[{level}]".PadRight(LevelColumnSize) + message);
        }
    }
    public static class LoggingExtensions
    {
        #region Standard level-based logging

        public static void Trace(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Trace, message);
        }

        public static void Debug(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Debug, message);
        }

        public static void Information(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Information, message);
        }

        public static void Warning(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Warning, message);
        }

        public static void Error(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Error, message);
        }

        public static void Critical(this IModbusLogger logger, string message)
        {
            logger.Log(LoggingLevel.Critical, message);
        }

        #endregion

        #region Func Logging
        public static void Log(this IModbusLogger logger, LoggingLevel level, Func<string> messageFactory)
        {
            if (logger.ShouldLog(level))
            {
                string message = messageFactory();

                logger.Log(level, message);
            }
        }

        public static void Trace(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Trace, messageFactory);
        }

        public static void Debug(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Debug, messageFactory);
        }

        public static void Information(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Information, messageFactory);
        }

        public static void Warning(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Warning, messageFactory);
        }

        public static void Error(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Error, messageFactory);
        }

        public static void Critical(this IModbusLogger logger, Func<string> messageFactory)
        {
            logger.Log(LoggingLevel.Critical, messageFactory);
        }

        #endregion

        #region Frame logging

        private static void LogFrame(this IModbusLogger logger, string validPrefix, string invalidPrefix, byte[] frame)
        {
            if (logger.ShouldLog(LoggingLevel.Trace))
            {
                if (logger.ShouldLog(LoggingLevel.Trace))
                {
                    string prefix = frame.DoesCrcMatch() ? validPrefix : invalidPrefix;

                    logger.Trace($"{prefix}: {string.Join(" ", frame.Select(b => b.ToString("X2")))}");
                }
            }
        }

        internal static void LogFrameTx(this IModbusLogger logger, byte[] frame)
        {
            logger.LogFrame("TX", "tx", frame);
        }

        internal static void LogFrameRx(this IModbusLogger logger, byte[] frame)
        {
            logger.LogFrame("RX", "rx", frame);
        }

        internal static void LogFrameIgnoreRx(this IModbusLogger logger, byte[] frame)
        {
            logger.LogFrame("IR", "ir", frame);
        }

        #endregion  
    }
    /// <summary>
    /// Base class for Modbus loggers.
    /// </summary>
    public abstract class ModbusLogger : IModbusLogger
    {
        protected ModbusLogger(LoggingLevel minimumLoggingLevel)
        {
            MinimumLoggingLevel = minimumLoggingLevel;
        }

        protected LoggingLevel MinimumLoggingLevel { get; }

        /// <summary>
        /// Returns true if the level should be loggged, false otherwise.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ShouldLog(LoggingLevel level)
        {
            return level >= MinimumLoggingLevel;
        }

        /// <summary>
        /// Log the specified message at the specified level.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LoggingLevel level, string message)
        {
            if (ShouldLog(level))
            {
                LogCore(level, message);
            }
        }

        /// <summary>
        /// Override this method to implement logging behavior. This function will only be called if ShouldLog(level) is true.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        protected abstract void LogCore(LoggingLevel level, string message);
    }
    /// <summary>
    /// Empty logger.
    /// </summary>
    public class NullModbusLogger : IModbusLogger
    {
        /// <summary>
        /// Singleton.
        /// </summary>
        public static NullModbusLogger Instance = new NullModbusLogger();

        private NullModbusLogger()
        {
        }

        /// <summary>
        /// This won't do anything.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LoggingLevel level, string message)
        {
        }

        /// <summary>
        /// Always returnsa false
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ShouldLog(LoggingLevel level)
        {
            return false;
        }
    }
    public class TraceModbusLogger : ModbusLogger
    {
        private const int LevelColumnSize = 15;
        private static readonly string BlankHeader = Environment.NewLine + new string(' ', LevelColumnSize);

        public TraceModbusLogger(LoggingLevel minimumLoggingLevel = LoggingLevel.Debug)
            : base(minimumLoggingLevel)
        {
        }

        protected override void LogCore(LoggingLevel level, string message)
        {
            message = message?.Replace(Environment.NewLine, BlankHeader);

            Trace.WriteLine($"[{level}]".PadRight(LevelColumnSize) + message);
        }
    }
}

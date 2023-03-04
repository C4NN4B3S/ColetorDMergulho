using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

namespace Common
{
    // Token: 0x02000010 RID: 16
    public static class SNLogger
    {
        // Token: 0x0600004F RID: 79 RVA: 0x00002FA0 File Offset: 0x000011A0
        private static void WriteLog(SNLogType logType, string message)
        {
            Console.WriteLine(string.Concat(new string[]
            {
                "[",
                Assembly.GetCallingAssembly().GetName().Name,
                "/",
                SNLogger.logTypeCache[logType],
                "] ",
                message
            }));
        }

        // Token: 0x06000050 RID: 80 RVA: 0x00002FF9 File Offset: 0x000011F9
        public static void UnityLog(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00003001 File Offset: 0x00001201
        public static void Log(string message)
        {
            SNLogger.WriteLog(SNLogType.LOG, message);
        }

        // Token: 0x06000052 RID: 82 RVA: 0x0000300A File Offset: 0x0000120A
        public static void Log(string format, params object[] args)
        {
            SNLogger.WriteLog(SNLogType.LOG, string.Format(format, args));
        }

        // Token: 0x06000053 RID: 83 RVA: 0x00003019 File Offset: 0x00001219
        public static void Warn(string moduleName, string message)
        {
            SNLogger.WriteLog(SNLogType.WARNING, message);
        }

        // Token: 0x06000054 RID: 84 RVA: 0x00003022 File Offset: 0x00001222
        public static void Warn(string format, params object[] args)
        {
            SNLogger.WriteLog(SNLogType.WARNING, string.Format(format, args));
        }

        // Token: 0x06000055 RID: 85 RVA: 0x00003031 File Offset: 0x00001231
        public static void Error(string message)
        {
            SNLogger.WriteLog(SNLogType.ERROR, message);
        }

        // Token: 0x06000056 RID: 86 RVA: 0x0000303A File Offset: 0x0000123A
        public static void Error(string format, params object[] args)
        {
            SNLogger.WriteLog(SNLogType.ERROR, string.Format(format, args));
        }

        // Token: 0x06000057 RID: 87 RVA: 0x00003049 File Offset: 0x00001249
        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
            SNLogger.WriteLog(SNLogType.DEBUG, message);
        }

        // Token: 0x06000058 RID: 88 RVA: 0x00003052 File Offset: 0x00001252
        [Conditional("DEBUG")]
        public static void Debug(string format, params object[] args)
        {
            SNLogger.WriteLog(SNLogType.DEBUG, string.Format(format, args));
        }

        // Token: 0x06000059 RID: 89 RVA: 0x00003061 File Offset: 0x00001261
        [Conditional("TRACE")]
        public static void Trace(string message)
        {
            SNLogger.WriteLog(SNLogType.TRACE, message);
        }

        // Token: 0x0600005A RID: 90 RVA: 0x0000306A File Offset: 0x0000126A
        [Conditional("TRACE")]
        public static void Trace(string format, params object[] args)
        {
            SNLogger.WriteLog(SNLogType.TRACE, string.Format(format, args));
        }

        // Token: 0x04000057 RID: 87
        public static readonly Dictionary<SNLogType, string> logTypeCache = new Dictionary<SNLogType, string>(4)
        {
            {
                SNLogType.LOG,
                "LOG"
            },
            {
                SNLogType.WARNING,
                "WARNING"
            },
            {
                SNLogType.ERROR,
                "ERROR"
            },
            {
                SNLogType.DEBUG,
                "DEBUG"
            },
            {
                SNLogType.TRACE,
                "TRACE"
            }
        };
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Utilities.ExtensionMethods
{
    public static class HttpExtensions
    {
        public static string GetRequestIP(this HttpContext httpContext, bool tryUseXForwardHeader = true)
        {
            string ip = null;

            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>(httpContext, "X-Forwarded-For").SplitCsv().FirstOrDefault();

            if (ip.IsNullOrWhitespace() && httpContext.Connection?.RemoteIpAddress != null)
                ip = httpContext.Connection.RemoteIpAddress.ToString();

            if (ip.IsNullOrWhitespace())
                ip = GetHeaderValueAs<string>(httpContext, "REMOTE_ADDR");

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            return ip;
        }

        public static T GetHeaderValueAs<T>(this HttpContext httpContext, string headerName)
        {
            StringValues values;

            if (httpContext.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!rawValues.IsNullOrWhitespace())
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }

        private static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }

        private static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}

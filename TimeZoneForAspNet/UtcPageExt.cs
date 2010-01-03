using System;
using System.Web;
using System.Web.UI;

namespace Cprieto.Utils
{
    public static class UtcPageExt
    {
        private const string CookieName = "TimeZoneOffset";

        public static DateTime LocalTimeFromTimeOffset(this Page page, DateTime utcTime) {
            var request = page.Request;
            if (IsCookieDefined(request)) {
                var offset = GetUtcOffset(request);
                return utcTime.AddMinutes(offset);
            }
            return utcTime;
        }

        public static int UtcOffset(this Page page)
        {
            var request = page.Request;
            if (IsCookieDefined(request)) {
                var minOffset = GetUtcOffset(request);
                return minOffset/60; // return offset in hours, not minutes
            }
            return 0;
        }

        private static bool IsCookieDefined(HttpRequest request) {
            return request.Cookies[CookieName] != null;
        }

        private static int GetUtcOffset(HttpRequest request) {
            var cookie = request.Cookies[CookieName];
            var offset = (cookie == null) ? 0 : int.Parse(cookie.Value);
            return offset*-1;
        }
    }
}
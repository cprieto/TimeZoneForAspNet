using System;
using System.IO;
using System.Web;

namespace Cprieto.Utils {
    public class UtcInfoModule : IHttpModule {
        private HttpApplication _httpApplication;
        private const string CookieName = "TimeZoneOffset";

        #region IHttpModule Members

        public void Dispose() { }

        public void Init(HttpApplication context) {
            _httpApplication = context;
            _httpApplication.BeginRequest += Application_BeginRequest;
        }

        #endregion

        protected void Application_BeginRequest(object sender, EventArgs args) {
            if (IsAspxPage() && IsCookieNotDefined()) {
                InsertTimeOffsetCookie();
            }
        }

        private void InsertTimeOffsetCookie() {
            var assembly = GetType().Assembly;
            var fileName = assembly.GetManifestResourceNames()[0]; // First embedded file in assembly
            var dummyHtml = assembly.GetManifestResourceStream(fileName);
            
            using (var reader = new StreamReader(dummyHtml)) {
                var html = reader.ReadToEnd();
                OutputDummyHtml(html);
            }
        }

        private void OutputDummyHtml(string html) {
            var response = _httpApplication.Response;
            response.ContentType = "text/html";
            response.Write(html);
            response.End();
        }

        private bool IsAspxPage() {
            var request = _httpApplication.Request;
            var filePath = request.FilePath.ToLower();

            return filePath.EndsWith(".aspx");
        }

        private bool IsCookieNotDefined() {
            var request = _httpApplication.Request;
            var cookie = request.Cookies[CookieName];
            return cookie == null;
        }
    }
}

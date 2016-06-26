using System;
using Advisor.Utils;

namespace Advisor.Log
{
    public class HttpLog
    {
        public HttpLog(string userName, string httpMethod, Uri uri, string body)
        {
            userName.RequireNotNullOrWhiteSpace(nameof(userName));
            httpMethod.RequireNotNullOrWhiteSpace(nameof(httpMethod));

            UserName = userName;
            HttpMethod = httpMethod;
            Uri = uri;
            Body = body;
        }

        public string UserName { get; private set; }
        public string HttpMethod { get; private set; }
        public Uri Uri { get; private set; }
        public string Body { get; private set; }
    }
}

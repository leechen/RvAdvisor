using System;
using Microsoft.Diagnostics.Tracing;

namespace Advisor.Log
{
    [EventSource(Name = "RV-Api")]
    public sealed class ApiEventSource : EventSource
    {
        public static ApiEventSource Log = new ApiEventSource();

        private const int exceptionEventId = 1;

        private const int getBeginEventId = 2;
        private const int getEndEventId = 3;

        private const int postBeginEventId = 4;
        private const int postEndEventId = 5;

        private const int putBeginEventId = 6;
        private const int putEndEventId = 7;

        private const int deleteBeginEventId = 8;
        private const int deleteEndEventId = 9;

        internal ApiEventSource() { }

        [Event(exceptionEventId, Message = "Exception thrown: {0}", Level = EventLevel.Error, Channel = EventChannel.Operational)]
        public void Exception(string message)
        {
            WriteEvent(exceptionEventId, message);
        }

        [Event(getBeginEventId, Message = "{0} began GET at {1}", Level = EventLevel.Verbose, Channel = EventChannel.Operational)]
        public void GetBegin(string userName, string url)
        {
            WriteEvent(getBeginEventId, userName, url);
        }

        [Event(getEndEventId, Message = "{0} ended GET at {1}", Level = EventLevel.Verbose, Channel = EventChannel.Operational)]
        public void GetEnd(string userName, string url)
        {
            WriteEvent(getEndEventId, userName, url);
        }

        [Event(postBeginEventId, Message = "{0} began POST at {1}", Level = EventLevel.Informational, Channel = EventChannel.Operational)]
        public void PostBegin(string userName, string url, string jsonData)
        {
            WriteEvent(postBeginEventId, userName, url, jsonData);
        }

        [Event(postEndEventId, Message = "{0} ended POST at {1}", Level = EventLevel.Informational, Channel = EventChannel.Operational)]
        public void PostEnd(string userName, string url, string jsonData)
        {
            WriteEvent(postEndEventId, userName, url, jsonData);
        }

        [Event(putBeginEventId, Message = "{0} began PUT at {1}", Level = EventLevel.Informational, Channel = EventChannel.Operational)]
        public void PutBegin(string userName, string url, string jsonData)
        {
            WriteEvent(putBeginEventId, userName, url, jsonData);
        }

        [Event(putEndEventId, Message = "{0} ended PUT at {1}", Level = EventLevel.Informational, Channel = EventChannel.Operational)]
        public void PutEnd(string userName, string url, string jsonData)
        {
            WriteEvent(putEndEventId, userName, url, jsonData);
        }

        [Event(deleteBeginEventId, Message = "{0} began DELETE at {1}", Level = EventLevel.Verbose, Channel = EventChannel.Operational)]
        public void DeleteBegin(string userName, string url)
        {
            WriteEvent(deleteBeginEventId, userName, url);
        }

        [Event(deleteEndEventId, Message = "{0} ended DELETE at {1}", Level = EventLevel.Verbose, Channel = EventChannel.Operational)]
        public void DeleteEnd(string userName, string url)
        {
            WriteEvent(deleteEndEventId, userName, url);
        }
    }
}

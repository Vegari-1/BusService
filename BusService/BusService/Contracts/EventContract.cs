namespace BusService.Contracts
{
	public class EventContract
    {
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string RequestType { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeText { get; set; }

        public EventContract(DateTime timestamp, string source, string requestType, string message, int statusCode, string statusCodeText)
        {
            Timestamp = timestamp;
            Source = source;
            RequestType = requestType;
            Message = message;
            StatusCode = statusCode;
            StatusCodeText = statusCodeText;
        }
    }
}


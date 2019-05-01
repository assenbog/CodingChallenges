namespace RoadStatus
{
    using Newtonsoft.Json;

    public class RoadData
    {
        public RoadData()
        {
            // Assume everything's Ok to begin with
            HttpStatusCode = (int)System.Net.HttpStatusCode.OK;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("statusSeverity")]
        public string StatusSeverity { get; set; }

        [JsonProperty("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [JsonProperty("timestampUtc")]
        public string TimeStamp { get; set; }

        [JsonProperty("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonProperty("httpStatusCode")]
        public int HttpStatusCode { get; set; }

        [JsonProperty("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("relativeUrl")]
        public string RelativeUrl { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

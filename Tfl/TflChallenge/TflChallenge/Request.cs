namespace RoadStatus
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Request
    {
        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    LastOperationStatus = response.StatusCode;

                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                var tflException = CreateRoadDataException(uri, ex.Message);
                return await Task.FromResult(tflException.ToJson());
            }
        }

        public HttpStatusCode LastOperationStatus { get; private set; }

        private RoadData CreateRoadDataException(string uri, string errorMessage)
        {
            var urlParserRegEx = new Regex(@"^.*/Road/(.*)\?.*$");

            var errorMessageRegEx = new Regex(@"^.*\((.*)\).*$");

            var road = urlParserRegEx.Match(uri).Groups[1].Value;

            var errorCodeString = errorMessageRegEx.Match(errorMessage).Groups[1].Value;

            var success = int.TryParse(errorCodeString, out var errorCodeNumber);

            if(success)
            {
                LastOperationStatus = (HttpStatusCode)errorCodeNumber;
            }

            return new RoadData
            {
                Id = road,
                DisplayName = road.ToUpper(),
                ExceptionType = "EntityNotFoundException",
                HttpStatus = ((HttpStatusCode)errorCodeNumber).ToString(),
                HttpStatusCode = errorCodeNumber,
                TimeStamp = DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff'Z'"),
                Message = $"The following road id is not recognised: {road}",
                Url = $"/Road/{road}",
                RelativeUrl = $"/Road/{road}"
            };
        }
    }
}

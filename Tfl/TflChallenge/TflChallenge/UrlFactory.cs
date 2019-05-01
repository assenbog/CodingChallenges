namespace RoadStatus
{
    using System.Configuration;
    using System.Text;

    public static class UrlFactory
    {
        private static string BaseUrl = @"https://api.tfl.gov.uk";

        public static string CreateRoadStatusUrl(string relativeUrl)
        {
            const string appIdName = "AppId";
            const string developerKeyName = "DeveloperKey";

            const string app_id = "app_id=";
            const string app_key = "app_key=";

            const string more = "&";

            var sb = new StringBuilder(BaseUrl);
            sb.Append(relativeUrl);

            var appId = ConfigurationManager.AppSettings[appIdName];
            var developerKey = ConfigurationManager.AppSettings[developerKeyName];

            sb.Append("?");
            sb.Append(app_id);
            sb.Append(appId);

            sb.Append(more);
            sb.Append(app_key);
            sb.Append(developerKey);

            return sb.ToString();
        }
    }
}

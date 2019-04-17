namespace BNPTest.Utilities
{
    using System.Text;
    using Model;

    public static class DataValidator
    {
        public static bool IsValid(Tenor tenor, string portfolioId, string value, out string errorMessage)
        {
            var sb = new StringBuilder();

            if (tenor.Years.HasValue)
            {
                var years = tenor.Years.Value;
                if (years < 1 || years > 99)
                {
                    sb.AppendLine("Years must be between 1 and 99");
                }
            }

            if (tenor.Months.HasValue)
            {
                var months = tenor.Months.Value;
                if (months < 1 || months > 12)
                {
                    sb.AppendLine("Months must be between 1 and 12");
                }
            }

            if (tenor.Weeks.HasValue)
            {
                var weeks = tenor.Weeks.Value;
                if (weeks < 1 || weeks > 4)
                {
                    sb.AppendLine("Weeks must be between 1 and 4");
                }
            }

            if (tenor.Days.HasValue)
            {
                var days = tenor.Days.Value;
                if (days < 1 || days > 31)
                {
                    sb.AppendLine("Days must be between 1 and 31");
                }
            }

            if (!int.TryParse(portfolioId, out int portfolioIdIntValue))
            {
                sb.Append($"Unable to parse \"{portfolioId}\" as an integer value");
            }

            if (!int.TryParse(value, out int intValue))
            {
                sb.Append($"Unable to parse \"{value}\" as an integer value");
            }

            errorMessage = sb.ToString();

            return string.IsNullOrEmpty(errorMessage);
        }
    }
}

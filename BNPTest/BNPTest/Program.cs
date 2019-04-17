namespace BNPTest
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Model;
    using Utilities;

    class Program
    {
        static void Main(string[] args)
        {
            var errors = new List<string>();

            // Note: This will in all likelyhood be provided as a command line parameter to this utility
            var inputFileName = @"..\..\Data\data.txt";

            var directoryName = Path.GetDirectoryName(Path.GetFullPath(inputFileName));

            // Load data.txt
            var rawInputData = Io.LoadData(inputFileName);

            var portfolioData = new List<PortfolioData>();

            foreach (var rowData in rawInputData)
            {
                var rowItems = rowData.Split(',');
                if (rowItems.Length != 3)
                {
                    // Skip incomplete rows, as advised
                    continue;
                }

                Tenor tenor = rowItems[0].ToTenor();
                string portfolioId = rowItems[1];
                string value = rowItems[2];

                // Validate the tenor, portfolioid and value for each row
                // The validation would ensure that portfolioid and value can be cast to int and for the tenor, when provided, years are in [1,99], months - [1-12], weeks - [1-4] and days - [1-31] 
                if (DataValidator.IsValid(tenor, portfolioId, value, out var errorMessage))
                {
                    portfolioData.Add(new PortfolioData { Duration = tenor, PortfolioId = int.Parse(portfolioId), Value = int.Parse(value) });
                }
                else
                {
                    // Aggregate any errors into a list to be save at the end of the process
                    errors.Add(errorMessage);
                }
            }

            if (portfolioData.Count > 0)
            {
                var sortedByTenorAndPortfolioIdList = portfolioData.OrderBy(p => p.Duration).ThenBy(p => p.PortfolioId).ToList();
                var sortedByTenorAndPortfolioIdFileName = Path.Combine(directoryName, "3.txt");
                if (File.Exists(sortedByTenorAndPortfolioIdFileName))
                {
                    File.Delete(sortedByTenorAndPortfolioIdFileName);
                }
                Io.WritePortfolioData(sortedByTenorAndPortfolioIdFileName, sortedByTenorAndPortfolioIdList);

                var sortedByPortfolioIdAndTenorList = portfolioData.OrderBy(p => p.PortfolioId).ThenBy(p => p.Duration).ToList();
                var sortedByPortfolioIdAndTenorFileName = Path.Combine(directoryName, "4.txt");
                if (File.Exists(sortedByPortfolioIdAndTenorFileName))
                {
                    File.Delete(sortedByPortfolioIdAndTenorFileName);
                }
                Io.WritePortfolioData(sortedByPortfolioIdAndTenorFileName, sortedByPortfolioIdAndTenorList);
            }

            if (errors.Count > 0)
            {
                var errorsLogFileName = Path.Combine(directoryName, "errors.log");
                if (File.Exists(errorsLogFileName))
                {
                    File.Delete(errorsLogFileName);
                }
                Io.LogErrors(errorsLogFileName, errors);
            }
        }
    }
}

namespace BNPTest.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Model;

    public static class Io
    {
        public static List<string> LoadData(string path)
        {
            var returnValue = new List<string>();

            try
            {
                using (var sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("tenor", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // Skip the headers line
                            continue;
                        }

                        returnValue.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                returnValue = null; // To indicate there's been an exception
            }

            return returnValue;
        }

        public static bool WritePortfolioData(string outputFileName, List<PortfolioData> portfolioData)
        {
            const string columnNames = "tenor,portfolioid,value";

            bool returnValue = true;

            try
            {
                using (var sw = new StreamWriter(outputFileName))
                {
                    sw.WriteLine(columnNames);
                    portfolioData.ForEach(p => sw.WriteLine(p.ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                returnValue = false;
            }

            return returnValue;
        }

        public static bool LogErrors(string outputFileName, List<string> errors)
        {
            bool returnValue = true;

            try
            {
                using (var sw = new StreamWriter(outputFileName))
                {
                    errors.ForEach(p => sw.WriteLine(p));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                returnValue = false;
            }

            return returnValue;
        }
    }
}

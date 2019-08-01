using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{

    class Solution
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Use Console.ReadLine() and Console.WriteLine() to read from STDIN and write to STDOUT. */
            var portfolios = new List<Portfolio>();
            int numberOfBadAssets = int.Parse(Console.ReadLine());
            var badAssetsIds = new List<string>();
            for (var i = 0; i < numberOfBadAssets; i++)
            {
                badAssetsIds.Add(Console.ReadLine());
            }
            int numberOfPortfolios = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfPortfolios; i++)
            {
                var portfolioAssetNumber = int.Parse(Console.ReadLine());
                var portfolio = new Portfolio();
                for (var j = 0; j < portfolioAssetNumber; j++)
                {
                    var assetData = Console.ReadLine();
                    var assetDataArray = assetData.Split(' ');
                    var isBadAsset = badAssetsIds.Contains(assetDataArray[0]);
                    portfolio.Assets.Add(new Asset { IsBad = isBadAsset, Id = assetDataArray[0], Value = double.Parse(assetDataArray[1]) });
                }
                portfolios.Add(portfolio);
            }
            foreach (var portfolio in portfolios)
            {
                Console.WriteLine($"{portfolio.GetBadAssetExposure():0#}%");
            }
        }
    }
    public class Asset
    {
        public bool IsBad { get; set; }
        public string Id { get; set; }
        public double Value { get; set; }
    }

    public class Portfolio
    {
        public List<Asset> Assets { get; set; }
        public Portfolio()
        {
            Assets = new List<Asset>();
        }
        public double GetBadAssetExposure()
        {
            var portfolioBadAssetSum = Assets.Where(p => p.IsBad).Select(p => p.Value).Sum();
            var portfolioSum = Assets.Select(p => p.Value).Sum();
            return portfolioBadAssetSum / portfolioSum * 100;
        }
    }

}

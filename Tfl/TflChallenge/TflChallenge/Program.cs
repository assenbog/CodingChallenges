namespace RoadStatus
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("\nMissing RoadName\n\n");
                Console.WriteLine("\nUsage: RoadStatus RoadName, e.g. RoadStatus A2\n");
                return -1;
            }

            var roadName = args[0];

            var url = UrlFactory.CreateRoadStatusUrl($"/Road/{roadName}");

            var request = new Request();

            var roadDataJson = Task.Run(async () => await request.GetAsync(url)).Result;

            var roadData = roadDataJson.ToRoadData();

            if (roadData.HttpStatusCode == (int)HttpStatusCode.OK)
            {
                Console.WriteLine($"The status of the {roadName.ToUpper()} is as follows");
                Console.WriteLine($"\tRoad Status is {roadData.StatusSeverity}");
                Console.WriteLine($"\tRoad Status Description is {roadData.StatusSeverityDescription}");
                return 0;
            }
            else
            {
                Console.WriteLine($"{roadName.ToUpper()} is not a valid road");
                return 1;
            }
        }
    }
}

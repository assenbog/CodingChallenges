namespace RoadStatus
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static string ToJson(this RoadData roadData)
        {
            return JsonConvert.SerializeObject(roadData, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
        }

        public static RoadData ToRoadData(this string roadData)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<RoadData>>(roadData).FirstOrDefault();
            }
            catch (System.Exception)
            {
                return JsonConvert.DeserializeObject<RoadData>(roadData);
            }
        }
    }
}

namespace MostCommonValue
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Analyser
    {
        public static Tuple<T,int> GetMostCommon<T>(IEnumerable<T> items)
        {
            var itemGroupCount = from item in items
                                 orderby item
                                 group item by item into itemGroups
                                 select new Tuple<T, int>(itemGroups.Key, itemGroups.Count());

            return itemGroupCount.OrderByDescending(p => p.Item2).First();
        }
    }
}

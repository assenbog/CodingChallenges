namespace BNPTest.Model
{
    using System;
    using System.Text;

    public class Tenor : IComparable
    {
        public Tenor(int? years, int? months, int? weeks, int? days)
        {
            Years = years;
            Months = months;
            Weeks = weeks;
            Days = days;
        }
        public int? Years { get; }

        public int? Months { get; }

        public int? Weeks { get; }

        public int? Days { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Years.HasValue)
            {
                sb.Append($"{Years.Value}y");
            }
            if (Months.HasValue)
            {
                sb.Append($"{Months.Value}m");
            }
            if (Weeks.HasValue)
            {
                sb.Append($"{Weeks.Value}w");
            }
            if (Days.HasValue)
            {
                sb.Append($"{Days.Value}d");
            }

            return sb.ToString();
        }

        public int CompareTo(object obj)
        {
            var tenor = obj as Tenor;

            if (tenor == null)
            {
                return -1;
            }

            if (tenor.Years.HasValue && !Years.HasValue || Years < tenor.Years)
            {
                return -1;
            }

            if (Years.HasValue && !tenor.Years.HasValue || Years > tenor.Years)
            {
                return 1;
            }

            if (Years == tenor.Years)
            {
                // Check the months
                if (tenor.Months.HasValue && !Months.HasValue || Months < tenor.Months)
                {
                    return -1;
                }

                if (Months.HasValue && !tenor.Months.HasValue || Months > tenor.Months)
                {
                    return 1;
                }

                if (Months == tenor.Months)
                {
                    // Check the weeks
                    if (tenor.Weeks.HasValue && !Weeks.HasValue || Weeks < tenor.Weeks)
                    {
                        return -1;
                    }

                    if (Weeks.HasValue && !tenor.Weeks.HasValue || Weeks > tenor.Weeks)
                    {
                        return 1;
                    }

                    if (Weeks == tenor.Weeks)
                    {
                        // Check the days
                        if (tenor.Days.HasValue && !Days.HasValue || Days < tenor.Days)
                        {
                            return -1;
                        }

                        if (Days.HasValue && !tenor.Days.HasValue || Days > tenor.Days)
                        {
                            return 1;
                        }
                    }
                }
            }

            return 0;
        }
    }
}

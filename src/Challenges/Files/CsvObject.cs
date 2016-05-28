using System;

namespace Files
{
    public class CsvObject
    {
        public string Name { get; set; }
        public int? Ozone { get; set; }
        public int? SolarR { get; set; }
        public double Wind { get; set; }
        public int Temp { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            var ozoneValue = Ozone?.ToString() ?? "null";
            var solarRValue = SolarR?.ToString() ?? "null";

            return String.Concat($"{ nameof(Name) } : { Name }; ",
                                 $"{ nameof(Ozone) } : { ozoneValue }; ",
                                 $"{ nameof(SolarR) } : { solarRValue }; ",
                                 $"{ nameof(Wind) } : { Wind }; ",
                                 $"{ nameof(Temp) } : { Temp }; ",
                                 $"{ nameof(Month) } : { Month }; ",
                                 $"{ nameof(Day) } : { Day }; ");
        }
    }
}
using System;

namespace XFSurfaceDuoSample2020.Models
{
    public class TimeTableItem
    {
        public string StationID { get; set; }
        public string ID { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string Description { get; set; }

        public TimeTableItem(
            string id = "", string stationID = "",
            int hour = 0, int minute = 0
            )
        {
            ID = id;
            StationID = stationID;
            Hour = hour;
            Minute = minute;
        }

        public override string ToString() => $"{Hour}:{Minute}";

        public static TimeTableItem Empty => new TimeTableItem();
    }
}
using System;

namespace XFSurfaceDuoSample2020.Models
{
    public class TimeTableRowItem
    {
        public string StationID { get; set; }
        public string ID { get; set; }
        public int Hour { get; set; }
        public string RowText { get; set; }

        public TimeTableRowItem(
            string id = "", string stationID = "",
            int hour = 0, string rowText = ""
            )
        {
            ID = id;
            StationID = stationID;
            Hour = hour;
            RowText = rowText;
        }

        public override string ToString() => $"{Hour}:{RowText}";

        public static TimeTableRowItem Empty => new TimeTableRowItem();
    }
}
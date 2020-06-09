using System;
using System.Collections.Generic;
using System.Text;

namespace XFSurfaceDuoSample2020.Models
{
    public class StationItem
    {
        public string LineID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }

        public StationItem(string lineID = "", string id = "", string name = "")
        {
            LineID = lineID;
            ID = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static StationItem Empty => new StationItem();
    }
}

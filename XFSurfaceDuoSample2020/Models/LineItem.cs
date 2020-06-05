using System;
using System.Collections.Generic;
using System.Text;

namespace XFSurfaceDuoSample2020.Models
{
    public class LineItem
    {

        public LineItem(string id = "", string name = "")
        {
            ID = id;
            Name = name;
        }

        public string ID { get; set; }
        public string Name { get; set; }

        public static LineItem Empty => new LineItem("", "路線を選択して下さい。");

        public override string ToString() => Name;

    }
}

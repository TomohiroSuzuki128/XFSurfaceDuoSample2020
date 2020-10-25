using System;
using System.Collections.Generic;
using System.Text;

namespace XFSurfaceDuoSample2020.Models
{
    public class LineItem
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public LineItem(string id = "", string name = "")
        {
            ID = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static LineItem Empty => new LineItem();
    }
}

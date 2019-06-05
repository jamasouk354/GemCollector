using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector
{
    public class GridBox
    {
        public int size = 40;
        public int x, y;
        public string value;
        public string appearence = "Invisible";

        public GridBox(int _x, int _y, string _value)
        {
            x = _x;
            y = _y;
            value = _value;
        }
    }
}

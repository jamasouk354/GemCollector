using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector
{
    class GridBox
    {
        public int size = 10;
        public int x, y;
        public string value;

        public GridBox(int _x, int _y, string _value)
        {
            x = _x;
            y = _y;
            value = _value;
        }
    }
}

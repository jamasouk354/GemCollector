using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector
{
    public class SavedGrid
    {
        public List<GridBox> Grid;
        public string name;

        public SavedGrid(List<GridBox> _Grid, string _name)
        {
            Grid = _Grid;
            name = _name;

            foreach(GridBox b in Grid)
            {
                b.appearence = "Invisible";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemCollector
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        int GridLength, GridWidth, GridNum, MineNum;

        List<GridBox> Grid = new List<GridBox>();
        Random randgen;

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GridNum = GridLength * GridWidth;

            int counter = 0;
            bool GridCreated = false;

            // Generate Grid
            if (GridCreated == false)
            {
                for (int i = 0; i < GridLength; i++)
                {
                    for (int j = 0; j < GridWidth; j++)
                    {
                        Grid.Add(new GridBox(i, j, "0"));
                    }
                }
                GridCreated = true;
            }

            // Insert Gems
            foreach (GridBox box in Grid)
            {
                if ((randgen.Next(1, 10) == 5) && counter < MineNum)
                {
                    box.value = "Gem";
                    counter++;
                }
            }

            // Generate numbers
            foreach (GridBox box in Grid)
            {
                if(!(box.value == "Gem"))
                {
                    counter = 0;
                    if (Grid.Contains(new GridBox(box.x++, box.y, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x++, box.y++, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x++, box.y--, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x--, box.y, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x--, box.y++, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x--, box.y--, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x, box.y++, "Gem")))
                    {
                        counter++;
                    }

                    if (Grid.Contains(new GridBox(box.x, box.y--, "Gem")))
                    {
                        counter++;
                    }

                    box.value = counter.ToString();
                }

            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            Pen linePen = new Pen(Color.Black, 2);

            // Draw Grid
            for (int i = 0; i < GridWidth; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(i * 10, 0), new Point(i * 10, GridLength * 10));
            }

            for (int i = 0; i < GridLength; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(0, i * 10), new Point(GridWidth * 10, i * 10));
            }

        }
    }
}

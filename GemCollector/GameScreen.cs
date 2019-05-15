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

        public static int GridLength, GridWidth, GridNum, MineNum;

        List<GridBox> Grid = new List<GridBox>();
        Random randgen = new Random();

        private void GameScreen_Load(object sender, EventArgs e)
        {
            // Remove this later, testing purposes
            GridLength = 10;
            GridWidth = 10;
            MineNum = 5;

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
            while(counter < MineNum)
            {
                foreach (GridBox box in Grid)
                {
                    if ((randgen.Next(1, 100) == 5) && counter < MineNum)
                    {
                        box.value = "Gem";
                        counter++;
                    }
                }
            }


            // Generate numbers
            foreach (GridBox box in Grid)
            {
                if(!(box.value == "Gem"))
                {
                    counter = 0;
                    if (Grid.Contains(new GridBox(box.x++, box.y, "0")))
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

                    box.value = Convert.ToString(counter);
                }

            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            Pen linePen = new Pen(Color.Black, 2);

            // Draw Grid
            for (int i = 0; i < GridWidth; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(i * 40, 0), new Point(i * 40, GridLength * 40));
            }

            for (int i = 0; i < GridLength; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(0, i * 40), new Point(GridWidth * 40, i * 40));
            }

            Font font = new Font("Times New Romans", 10);
            SolidBrush textBrush = new SolidBrush(Color.Brown);
            foreach (GridBox b in Grid)
            {
                e.Graphics.DrawString(b.value, font, textBrush, b.x * 40, b.y * 40);
            }
        }
    }
}

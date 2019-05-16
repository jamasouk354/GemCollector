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

        public static int GridNum;

        List<GridBox> Grid = new List<GridBox>();
        Random randgen = new Random();

        private void GameScreen_Load(object sender, EventArgs e)
        {
            // Remove this later, testing purposes
            //SelectScreen.GridLength = 10;
            //SelectScreen.GridWidth = 10;
            //SelectScreen.MineNum = 20;

            GridNum = SelectScreen.GridWidth * SelectScreen.GridHeight;

            int counter = 0;
            bool GridCreated = false;

            // Generate Grid
            if (GridCreated == false)
            {
                for (int i = 0; i < SelectScreen.GridWidth; i++)
                {
                    for (int j = 0; j < SelectScreen.GridHeight; j++)
                    {
                        Grid.Add(new GridBox(i, j, "0"));
                    }
                }
                GridCreated = true;
            }

            // Insert Gems
            while(counter < SelectScreen.GemNum)
            {
                foreach (GridBox box in Grid)
                {
                    if ((randgen.Next(1, 100) == 20) && counter < SelectScreen.GemNum)
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

                    box.value = Convert.ToString(counter);
                }

            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            Pen linePen = new Pen(Color.Black, 2);

            // Draw Grid
            for (int i = 0; i < SelectScreen.GridHeight; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(i * 30, 0), new Point(i * 30, SelectScreen.GridWidth * 30));
            }

            for (int i = 0; i < SelectScreen.GridWidth; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(0, i * 30), new Point(SelectScreen.GridWidth * 30, i * 30));
            }

            Font font = new Font("Times New Romans", 10);
            SolidBrush textBrush = new SolidBrush(Color.Brown);
            foreach (GridBox b in Grid)
            {
                e.Graphics.DrawString(b.value, font, textBrush, b.x * 30, b.y * 30);
            }
        }
    }
}

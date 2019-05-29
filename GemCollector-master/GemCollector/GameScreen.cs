﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Web;

namespace GemCollector
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        public static int GridNum;
        public static Point mouse;
        List<GridBox> Grid = new List<GridBox>();
        Random randgen = new Random();

        private void GameScreen_Load(object sender, EventArgs e)
        {
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
            while (counter < SelectScreen.GemNum)
            {
                foreach (GridBox box in Grid)
                {
                    if ((randgen.Next(1, 100) == 20) && counter < SelectScreen.GemNum)
                    {
                        if (box.y == 0)
                        {
                            box.value = "TGem";
                        }
                        else if (box.y == SelectScreen.GridHeight - 1)
                        {
                            box.value = "BGem";
                        }
                        else
                        {
                            box.value = "Gem";
                        }
                        counter++;
                    }
                }
            }


            // Generate numbers
            foreach (GridBox box in Grid)
            {
                if (!(box.value == "Gem" || box.value == "TGem" || box.value == "BGem"))
                {
                    counter = 0;
                    // Top Center
                    if (Grid.IndexOf(box) + 1 < Grid.Count())
                    {
                        if (Grid[Grid.IndexOf(box) + 1].value == "Gem" || Grid[Grid.IndexOf(box) + 1].value == "BGem")
                        {
                            counter++;
                        }
                    }
                    // Bottom Center
                    if (Grid.IndexOf(box) - 1 > 0)
                    {
                        if (Grid[Grid.IndexOf(box) - 1].value == "Gem" || Grid[Grid.IndexOf(box) - 1].value == "TGem")
                        {
                            counter++;
                        }
                    }
                    // Right
                    if (Grid.IndexOf(box) + SelectScreen.GridHeight < Grid.Count())
                    {
                        if (Grid[Grid.IndexOf(box) + SelectScreen.GridHeight].value == "Gem" || Grid[Grid.IndexOf(box) + SelectScreen.GridHeight].value == "BGem" || Grid[Grid.IndexOf(box) + SelectScreen.GridHeight].value == "TGem")
                        {
                            counter++;
                        }
                    }
                    // Left
                    if (Grid.IndexOf(box) - SelectScreen.GridHeight > 0)
                    {
                        if (Grid[Grid.IndexOf(box) - SelectScreen.GridHeight].value == "Gem" || Grid[Grid.IndexOf(box) - SelectScreen.GridHeight].value == "BGem" || Grid[Grid.IndexOf(box) - SelectScreen.GridHeight].value == "TGem")
                        {
                            counter++;
                        }
                    }
                    // Top Left
                    if (Grid.IndexOf(box) + SelectScreen.GridHeight + 1 < Grid.Count())
                    {
                        if (Grid[Grid.IndexOf(box) + SelectScreen.GridHeight + 1].value == "Gem" || Grid[Grid.IndexOf(box) + SelectScreen.GridHeight + 1].value == "BGem")
                        {
                            counter++;
                        }
                    }
                    // Bottom Right
                    if (Grid.IndexOf(box) + SelectScreen.GridHeight - 1 < Grid.Count())
                    {
                        if (Grid[Grid.IndexOf(box) + SelectScreen.GridHeight - 1].value == "Gem" || Grid[Grid.IndexOf(box) + SelectScreen.GridHeight - 1].value == "TGem")
                        {
                            counter++;
                        }
                    }
                    // Top Right
                    if (Grid.IndexOf(box) - SelectScreen.GridHeight + 1 > 0)
                    {
                        if (Grid[Grid.IndexOf(box) - SelectScreen.GridHeight + 1].value == "Gem" || Grid[Grid.IndexOf(box) - SelectScreen.GridHeight + 1].value == "BGem")
                        {
                            counter++;
                        }
                    }
                    // Bottom Left
                    if (Grid.IndexOf(box) - SelectScreen.GridHeight - 1 > 0)
                    {
                        if (Grid[Grid.IndexOf(box) - SelectScreen.GridHeight - 1].value == "Gem" || Grid[Grid.IndexOf(box) - SelectScreen.GridHeight - 1].value == "TGem")
                        {
                            counter++;
                        }
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
                e.Graphics.DrawLine(linePen, new Point(i * 40, 0), new Point(i * 40, SelectScreen.GridWidth * 40));
            }

            for (int i = 0; i < SelectScreen.GridWidth; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(0, i * 40), new Point(SelectScreen.GridHeight * 40, i * 40));
            }


            Font font = new Font("Times New Romans", 10);
            SolidBrush textBrush = new SolidBrush(Color.Brown);
            foreach (GridBox b in Grid)
            {
                if (b.appearence == "Invisible")
                {
                    e.Graphics.DrawImage(Properties.Resources.covered, (b.x) * 40, (b.y) * 40, 39, 39);
                }
                else if (b.appearence == "Marked")
                {
                    e.Graphics.DrawImage(Properties.Resources.flag, (b.x) * 40, (b.y) * 40, 39, 39);
                }
                else
                {
                    e.Graphics.DrawString(b.value, font, textBrush, b.x * 40, b.y * 40);
                }
                // Change images so it can take them from resources
            }
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            List<GridBox> zerobox = new List<GridBox>();
            switch (e.Button)
            {
                case MouseButtons.Left:
                    foreach (GridBox box in Grid)
                    {
                        Rectangle test = new Rectangle((box.x) * 40, (box.y) * 40, 39, 39);
                        Rectangle cursor = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 1, 1);
                        if (test.IntersectsWith(cursor))
                        {
                            box.appearence = "Visible";
                            zerobox.Add(box);
                            foreach(GridBox b in zerobox)
                            {
                                // Top Center
                                if ((Grid.IndexOf(b) + 1 < Grid.Count()) && !(b.y == 0))
                                {
                                    Grid[Grid.IndexOf(b) + 1].appearence = "Visible";
                                    if(Grid[Grid.IndexOf(b) + 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) + 1]);
                                    }
                                }
                                // Bottom Center
                                if ((Grid.IndexOf(b) - 1 > 0) && !(b.y == SelectScreen.GridHeight - 1))
                                {
                                    Grid[Grid.IndexOf(b) - 1].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) - 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) - 1]);
                                    }
                                }
                                // Right
                                if ((Grid.IndexOf(b) + SelectScreen.GridHeight < Grid.Count()) )
                                {
                                    Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight]);
                                    }

                                }
                                // Left
                                if ((Grid.IndexOf(b) - SelectScreen.GridHeight > 0))
                                {
                                    Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight]);
                                    }
                                }
                                // Top Left
                                if ((Grid.IndexOf(b) + SelectScreen.GridHeight + 1 < Grid.Count()) && !(b.y == 0))
                                {
                                    Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1]);
                                    }
                                }
                                // Bottom Right
                                if ((Grid.IndexOf(b) + SelectScreen.GridHeight - 1 < Grid.Count()) && !(b.y == SelectScreen.GridHeight - 1))
                                {
                                    Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1]);
                                    }
                                }
                                // Top Right
                                if ((Grid.IndexOf(b) - SelectScreen.GridHeight + 1 > 0) && !(b.y == 0))
                                {
                                    Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1]);
                                    }
                                }
                                // Bottom Left
                                if ((Grid.IndexOf(b) - SelectScreen.GridHeight - 1 > 0) && !(b.y == SelectScreen.GridHeight - 1))
                                {
                                    Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].appearence = "Visible";
                                    if (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].value == "0")
                                    {
                                        zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1]);
                                    }
                                }

                                zerobox.Remove(b);
                            }
                        }
                    }
                    // Reaveal block
                    break;
                case MouseButtons.Right:
                    mouse = new Point(Cursor.Position.X, Cursor.Position.Y);
                    foreach (GridBox b in Grid)
                    {
                        Rectangle test = new Rectangle((b.x) * 40, (b.y) * 40, 39, 39);
                        Rectangle cursor = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 1, 1);
                        if (test.IntersectsWith(cursor))
                        {
                            if(!(b.appearence == "Visible"))
                            {
                                if (b.appearence == "Invisible")
                                {
                                    b.appearence = "Marked";
                                }
                                else
                                {
                                    b.appearence = "Invisible";
                                }
                            }

                        }
                    }
                    // Mark block
                    break;
            }
            Refresh();
        }
    }
}

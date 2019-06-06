using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace GemCollector
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        public static int GridNum;
        public static bool NewGrid;
        public static Point Mouse;
        public static List<GridBox> Grid = new List<GridBox>();
        Random randgen = new Random();
        public Point tr;

        bool GameEnded = false;
        bool FlagLimitReached = false;
        public static int ClickCounter;
        public static int TimeTaken;

        private void GameScreen_Load(object sGameEndeder, EventArgs e)
        {
            tr = new Point((Screen.PrimaryScreen.Bounds.Width - (SelectScreen.GridWidth) * 40) / 2, (Screen.PrimaryScreen.Bounds.Height - (SelectScreen.GridHeight) * 40) / 2);

            GameTimer.Enabled = true;

            if (NewGrid)
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
                            if ((box.value != "Gem") || (box.value != "TGem") || (box.value != "BGem"))
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
                }
                #region Generate numbers

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
                    #endregion
                }
            }
            else
            {
                int yFinder = 0;
                int xFinder = 0;
                int GemFinder = 0;
                foreach(GridBox b in Grid)
                {
                    //Grid.RemoveRange(Grid.Count()/2, Grid.Count() - 1);
                    b.appearence = "Invisible";
                    if(xFinder < b.x)
                    {
                        xFinder = b.x;
                    }
                    if (yFinder < b.y)
                    {
                        yFinder = b.y;
                    }
                    if((b.value == "Gem")||(b.value == "TGem")||(b.value == "BGem"))
                    {
                        GemFinder++;
                    }
                }
                SelectScreen.GridWidth = xFinder + 1;
                SelectScreen.GemNum = GemFinder;
                SelectScreen.GridHeight = yFinder + 1;
            }
        }

        private void GameScreen_Paint(object sGameEndeder, PaintEventArgs e)
        {
            Font font = new Font("Times New Romans", 10);
            SolidBrush textBrush = new SolidBrush(Color.Brown);

            foreach (GridBox b in Grid)
            {
                if (b.appearence == "Invisible")
                {
                    e.Graphics.DrawImage(Properties.Resources.covered, tr.X+ (b.x) * 40, tr.Y + (b.y) * 40, 39, 39);
                }
                else if (b.appearence == "Marked")
                {
                    e.Graphics.DrawImage(Properties.Resources.flag, tr.X + (b.x) * 40, tr.Y + (b.y) * 40, 39, 39);
                }
                else
                {
                    switch (Convert.ToInt32(b.value))
                    {
                        case 0:
                            e.Graphics.DrawImage(Properties.Resources.bedrock, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 1:
                            e.Graphics.DrawImage(Properties.Resources._1, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 2:
                            e.Graphics.DrawImage(Properties.Resources._2, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 3:
                            e.Graphics.DrawImage(Properties.Resources._3, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 4:
                            e.Graphics.DrawImage(Properties.Resources._4, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 5:
                            e.Graphics.DrawImage(Properties.Resources._5, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 6:
                            e.Graphics.DrawImage(Properties.Resources._6, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 7:
                            e.Graphics.DrawImage(Properties.Resources._7, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                        case 8:
                            e.Graphics.DrawImage(Properties.Resources._8, tr.X + b.x * 40, tr.Y + b.y * 40);
                            break;
                    }
                }
                // Change images so it can take them from resources
            }

            Pen linePen = new Pen(Color.Black, 2);

            // Draw Grid
            for (int i = 0; i < SelectScreen.GridHeight + 1; i++)
            {
                e.Graphics.DrawLine(linePen, new Point((i * 40) + tr.X, tr.Y), new Point((i * 40) + tr.X, (SelectScreen.GridWidth * 40) + tr.Y));
            }

            for (int i = 0; i < SelectScreen.GridWidth + 1; i++)
            {
                e.Graphics.DrawLine(linePen, new Point(tr.X, (i * 40)+ tr.Y), new Point((SelectScreen.GridHeight * 40)+tr.X, (i * 40)+tr.Y));
            }
        }

        private void GameTimer_Tick(object sGameEndeder, EventArgs e)
        {
            TimeTaken++;
            TimeLable.Text = "Time Taken: " + TimeTaken;
            int counter = 0;
            int counter2 = 0;
            foreach(GridBox b in Grid)
            {
                if(b.appearence == "Marked")
                {
                    counter++;
                }

                if(((b.appearence == "Marked") || ((b.appearence == "Visible"))))
                {
                    counter2++;
                }
                FlagLable.Text = "Flags left: " + (SelectScreen.GemNum - counter);

                if((SelectScreen.GemNum - counter) == 0)
                {
                    FlagLimitReached = true;
                }
                else
                {
                    FlagLimitReached = false;
                }

                if(((SelectScreen.GridHeight*SelectScreen.GridWidth) - counter2) == 0)
                {
                    GameEnded = true;
                    OutputLabel.Visible = true;
                    GameTimer.Enabled = false;
                    OutputLabel.Text = "Congrats, you win, click the button and go again";
                    SelectScreen.scorelist.Add(new HighScore(SelectScreen.dificulty, TimeTaken,ClickCounter, ""));

                    ClickCounter = 0;
                    TimeTaken = 0;
                }
            }
        }

        private void BackButton_Click(object sGameEndeder, EventArgs e)
        {
            Grid.Clear();
            ClickCounter = 0;
            TimeTaken = 0;
            SaveSC();
            SelectScreen gs = new SelectScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }

        private void GameScreen_MouseClick(object sGameEndeder, MouseEventArgs e)
        {
            if (!GameEnded)
            {
                ClickCounter++;
                ClickLable.Text = "Number of Clicks: " + ClickCounter;
                List<GridBox> zerobox = new List<GridBox>();
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        foreach (GridBox box in Grid)
                        {
                            Rectangle test = new Rectangle(tr.X + (box.x) * 40, tr.Y + (box.y) * 40, 39, 39);
                            Rectangle cursor = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 1, 1);
                            if (test.IntersectsWith(cursor))
                            {
                                if(box.value == "Gem" || box.value == "TGem" || box.value == "BGem")
                                {
                                    GameEnded = true;
                                    OutputLabel.Visible = true;
                                    OutputLabel.Text = "You have died due to your incompetence";
                                    GameTimer.Enabled = false;
                                    ClickCounter = 0;
                                    TimeTaken = 0;
                                    break;
                                }

                                if(box.value == "0")
                                {
                                    zerobox.Add(box);
                                }
                                else
                                {
                                    box.appearence = "Visible";
                                }
                                #region zerobox loop
                                while(zerobox.Count() > 0)
                                {
                                    GridBox b = zerobox[0];
                                    Grid[Grid.IndexOf(b)].appearence = "Visible";
                                    // Top Center
                                    if ((Grid.IndexOf(b) + 1 < Grid.Count()) && (b.y != SelectScreen.GridHeight - 1))
                                    {
                                        if((Grid[Grid.IndexOf(b) + 1].value != "Gem") && (Grid[Grid.IndexOf(b) + 1].value != "TGem"))
                                        {
                                            if((Grid[Grid.IndexOf(b) + 1].value == "0") && (Grid[Grid.IndexOf(b) + 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) + 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) + 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Bottom Center
                                    if ((Grid.IndexOf(b) - 1 > 0) && (b.y != 0))
                                    {
                                        if ((Grid[Grid.IndexOf(b) - 1].value != "Gem") && (Grid[Grid.IndexOf(b) - 1].value != "BGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) - 1].value == "0") && (Grid[Grid.IndexOf(b) - 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) - 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) - 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Right
                                    if (Grid.IndexOf(b) + SelectScreen.GridHeight < Grid.Count())
                                    {
                                        if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].value != "Gem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].value != "BGem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].value != "TGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].value == "0") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) + SelectScreen.GridHeight].appearence = "Visible";
                                            }
                                        }

                                    }
                                    // Left
                                    if ((Grid.IndexOf(b) - SelectScreen.GridHeight > 0))
                                    {
                                        if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].value != "Gem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].value != "BGem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].value != "TGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].value == "0") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) - SelectScreen.GridHeight].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Top Left
                                    if ((Grid.IndexOf(b) + SelectScreen.GridHeight + 1 < Grid.Count()) && (b.y != SelectScreen.GridHeight - 1))
                                    {
                                        if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].value != "Gem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].value != "TGem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].value != "BGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].value == "0") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) + SelectScreen.GridHeight + 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Bottom Right
                                    if ((Grid.IndexOf(b) + SelectScreen.GridHeight - 1 < Grid.Count()) && (b.y != 0))
                                    {
                                        if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].value != "Gem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].value != "BGem") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].value != "TGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].value == "0") && (Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) + SelectScreen.GridHeight - 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Top Right
                                    if ((Grid.IndexOf(b) - SelectScreen.GridHeight + 1 > 0) && (b.y != SelectScreen.GridHeight - 1))
                                    {
                                        if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].value != "Gem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].value != "TGem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].value != "BGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].value == "0") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) - SelectScreen.GridHeight + 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    // Bottom Left
                                    if ((Grid.IndexOf(b) - SelectScreen.GridHeight - 1 > 0) && (b.y != 0))
                                    {
                                        if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].value != "Gem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].value != "BGem") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].value != "TGem"))
                                        {
                                            if ((Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].value == "0") && (Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].appearence == "Invisible"))
                                            {
                                                zerobox.Add(Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1]);
                                            }
                                            else
                                            {
                                                Grid[Grid.IndexOf(b) - SelectScreen.GridHeight - 1].appearence = "Visible";
                                            }
                                        }
                                    }
                                    zerobox.Remove(b);
                                }
                                #endregion 
                            }
                        }
                        // Reaveal block
                        break;
                    case MouseButtons.Right:
                        Mouse = new Point(Cursor.Position.X, Cursor.Position.Y);
                        foreach (GridBox b in Grid)
                        {
                            Rectangle test = new Rectangle(tr.X+(b.x) * 40, tr.Y+(b.y) * 40, 39, 39);
                            Rectangle cursor = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 1, 1);
                            if (test.IntersectsWith(cursor))
                            {
                                if(!(b.appearence == "Visible"))
                                {
                                    if ((b.appearence == "Invisible") && !FlagLimitReached)
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

        private void SaveButton_Click(object sGameEndeder, EventArgs e)
        {
            SelectScreen.SavedGrids.Add(new SavedGrid(Grid, ""));

            XmlWriter writer = XmlWriter.Create("savedGrids.xml", null);

            writer.WriteStartElement("Grids");

            foreach (SavedGrid hs in SelectScreen.SavedGrids)
            {
                writer.WriteStartElement("Grid");

                foreach(GridBox b in hs.Grid)
                {
                    writer.WriteStartElement("box");

                    writer.WriteElementString("x", (b.x).ToString());
                    writer.WriteElementString("y", (b.y).ToString());
                    writer.WriteElementString("value", (b.value).ToString());
                    writer.WriteElementString("name", (hs.name).ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
        }

        public void SaveSC()
        {
            XmlWriter writer = XmlWriter.Create("ScoreSaveFile.xml", null);

            writer.WriteStartElement("Scores");

            foreach (HighScore hs in SelectScreen.scorelist)
            {
                writer.WriteStartElement("Score");

                writer.WriteElementString("Difficulty", hs.difficulty);
                writer.WriteElementString("Clicks", (hs.clicks).ToString());
                writer.WriteElementString("Time", (hs.time).ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
        }

    }
}

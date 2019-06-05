using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace GemCollector
{
    public partial class SelectScreen : UserControl
    {
        public static int GridHeight, GridWidth, GemNum;
        public static string dificulty;
        public static SoundPlayer menuClick = new SoundPlayer(Properties.Resources.Click_menu);
        public static SoundPlayer gameClick = new SoundPlayer(Properties.Resources.Click_game);
        public static List<highScore> scorelist = new List<highScore>();
        public static List<SavedGrid> SavedGrids = new List<SavedGrid>();


        public SelectScreen()
        {
            loadSC();
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            GridHeight = GridWidth = 9;
            GemNum = 10;
            dificulty = "Easy";
            loadGame();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            GridHeight = GridWidth = 14;
            GemNum = 40;
            dificulty = "Medium";
            loadGame();
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            GridWidth = GridHeight = 19;
            GemNum = 70;
            dificulty = "Hard";
            loadGame();
        }

        private void SelectScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Difficulty", new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(400, 50));
            e.Graphics.DrawString("Clicks", new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(500, 50));
            e.Graphics.DrawString("Time", new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(600, 50));

            for (int i = 0; i < scorelist.Count(); i++)
            {
                if(scorelist[i].clicks == 0)
                {
                    scorelist.RemoveAt(i);
                }
                e.Graphics.DrawString((scorelist[i].difficulty), new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(400, 70 + 20*i));
                e.Graphics.DrawString((scorelist[i].clicks).ToString(), new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(500, 70 + 20 * i));
                e.Graphics.DrawString((scorelist[i].time).ToString(), new Font("Times New Romans", 14), new SolidBrush(Color.Black), new Point(600, 70 + 20 * i));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customButtom_Click(object sender, EventArgs e)
        {
            Thread.Sleep(180);
            menuClick.Play();
            dificulty = "Custom";
            CustomLevel cl = new CustomLevel();
            Form a = this.FindForm();
            a.Controls.Remove(this);
            a.Controls.Add(cl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectScreen.SavedGrids.Clear();
            string newX, newY, newV;
            string newName = "";
            bool start = true;
            List<GridBox> Grid = new List<GridBox>();
            XmlReader reader = XmlReader.Create("savedGrids.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    newX = reader.ReadString();

                    reader.ReadToNextSibling("y");
                    newY = reader.ReadString();

                    if ((!start) && (newX == "0") && (newY == "0"))
                    {
                        SelectScreen.SavedGrids.Add(new SavedGrid(Grid, newName));
                        Grid.Clear();
                    }
                    reader.ReadToNextSibling("value");
                    newV = reader.ReadString();

                    reader.ReadToNextSibling("name");
                    newName = reader.ReadString();

                    GridBox hs = new GridBox(Convert.ToInt32(newX), Convert.ToInt32(newY), newV);
                    Grid.Add(hs);
                    start = false;
                }
            }
            reader.Close();

            Thread.Sleep(180);
            menuClick.Play();
            dificulty = "Saved";
            GameScreen.Grid.Clear();
            GameScreen.Grid = SelectScreen.SavedGrids[0].Grid;
            GameScreen.newgrid = false;
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }

        public void loadGame()
        {
            GameScreen.newgrid = true;
            Thread.Sleep(180);
            menuClick.Play();
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }

        public void loadSC()
        {
            scorelist.Clear();
            string newD, newT, newC;
            XmlReader reader = XmlReader.Create("ScoreSaveFile.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    newD = reader.ReadString();

                    reader.ReadToNextSibling("Clicks");
                    newT = reader.ReadString();

                    reader.ReadToNextSibling("Time");
                    newC = reader.ReadString();

                    highScore hs = new highScore(newD, Convert.ToInt32(newT), Convert.ToInt32(newC), "");
                    scorelist.Add(hs);
                }

            }

            reader.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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

        public SelectScreen()
        {
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
            CustomLevel cl = new CustomLevel();
            Form a = this.FindForm();
            a.Controls.Remove(this);
            a.Controls.Add(cl);
        }

        public void loadGame()
        {
            Thread.Sleep(180);
            menuClick.Play();
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }
    }
}
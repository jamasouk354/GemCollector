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
        public static SoundPlayer menuClick = new SoundPlayer(Properties.Resources.Click_menu);
        public static SoundPlayer gameClick = new SoundPlayer(Properties.Resources.Click_game);

        public SelectScreen()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            GridHeight = GridWidth = 9;
            GemNum = 10;
            loadGame();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            GridHeight = GridWidth = 14;
            GemNum = 40;
            loadGame();
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            GridWidth = GridHeight = 24;
            GemNum = 99;
            loadGame();
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

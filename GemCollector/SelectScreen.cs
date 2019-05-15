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
    public partial class SelectScreen : UserControl
    {
        public static int GridLength, GridWidth, MineNum;

        public SelectScreen()
        {
            InitializeComponent();
        }

        private void SelectScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            GridLength = GridWidth = 9;
            MineNum = 10;
            loadGame();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            GridLength = GridWidth = 14;
            MineNum = 40;
            loadGame();

        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            GridLength = 30;
            GridWidth = 16;
            MineNum = 99;
            loadGame();
        }

        public void loadGame()
        {
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }
    }
}

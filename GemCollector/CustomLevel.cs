using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GemCollector
{
    public partial class CustomLevel : UserControl
    {
        public CustomLevel()
        {
            InitializeComponent();
        }

        private void CustomLevel_Load(object sender, EventArgs e)
        {
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int total;
            SelectScreen.GridHeight = Convert.ToInt32(heightInput.Text);
            SelectScreen.GridWidth = Convert.ToInt32(widthInput.Text);
            SelectScreen.GemNum = Convert.ToInt32(gemInput.Text);
            total = SelectScreen.GridHeight * SelectScreen.GridWidth;
            try
            {
                if (SelectScreen.GridHeight < 4 && SelectScreen.GridWidth < 4)
                {
                    outputLabel.Text = "Width and/or Height is too low";
                }
            }
            catch { }    

            Thread.Sleep(180);
            SelectScreen.menuClick.Play();
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }     
    }
}

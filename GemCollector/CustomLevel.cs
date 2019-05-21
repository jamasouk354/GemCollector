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
            if (SelectScreen.GridHeight < 4)
            {
                outputLabel.Text = "Height is too low";
            }
            SelectScreen.GridWidth = Convert.ToInt32(widthInput.Text);
            if (SelectScreen.GridWidth < 4)
            {
                outputLabel.Text = "Width is too low";
            }
            SelectScreen.GemNum = Convert.ToInt32(gemInput.Text);
            total = SelectScreen.GridHeight * SelectScreen.GridWidth;
            if (SelectScreen.GemNum > total)
            {
                outputLabel.Text = "Too much gems";
            }

            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Controls.Add(gs);
        }     
    }
}

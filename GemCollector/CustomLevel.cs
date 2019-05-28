
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
            try
            {
                SelectScreen.GridHeight = Convert.ToInt32(heightInput.Text);
                SelectScreen.GridWidth = Convert.ToInt32(widthInput.Text);
                SelectScreen.GemNum = Convert.ToInt32(gemInput.Text);
                total = SelectScreen.GridHeight * SelectScreen.GridWidth;

                if(SelectScreen.GridHeight > 20 || SelectScreen.GridWidth > 40)
                {
                    outputLabel.Text = "Grid is too Large";
                }
                else if (SelectScreen.GridHeight < 1 || SelectScreen.GridWidth < 1)
                {
                    outputLabel.Text = "Grid is too Small";
                }
                else if(SelectScreen.GemNum > total)
                {
                    outputLabel.Text = "Too many Gems";
                }
                else if (SelectScreen.GemNum < 1)
                {
                    outputLabel.Text = "Not enought Gems";
                }
                else
                {
                    Thread.Sleep(180);
                    SelectScreen.menuClick.Play();
                    GameScreen gs = new GameScreen();
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    f.Controls.Add(gs);
                }

            }
            catch
            {
                outputLabel.Text = "Must Enter Intagers";
            }
        }     
    }
}


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

        private void StartButton_Click(object sender, EventArgs e)
        {
            int total;
            try
            {
                SelectScreen.GridHeight = Convert.ToInt32(HeightInput.Text);
                SelectScreen.GridWidth = Convert.ToInt32(WidthInput.Text);
                SelectScreen.GemNum = Convert.ToInt32(GemInput.Text);
                total = SelectScreen.GridHeight * SelectScreen.GridWidth;

                if(SelectScreen.GridHeight > 20 || SelectScreen.GridWidth > 40)
                {
                    OutputLabel.Text = "Grid is too Large";
                }
                else if (SelectScreen.GridHeight < 1 || SelectScreen.GridWidth < 1)
                {
                    OutputLabel.Text = "Grid is too Small";
                }
                else if(SelectScreen.GemNum > total)
                {
                    OutputLabel.Text = "Too many Gems";
                }
                else if (SelectScreen.GemNum < 1)
                {
                    OutputLabel.Text = "Not enought Gems";
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
                OutputLabel.Text = "Must Enter Intagers";
            }
        }     
    }
}

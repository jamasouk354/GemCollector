namespace GemCollector
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ClickLable = new System.Windows.Forms.Label();
            this.TimeLable = new System.Windows.Forms.Label();
            this.FlagLable = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.BackButton = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClickLable
            // 
            this.ClickLable.AutoSize = true;
            this.ClickLable.Location = new System.Drawing.Point(1270, 53);
            this.ClickLable.Name = "ClickLable";
            this.ClickLable.Size = new System.Drawing.Size(114, 17);
            this.ClickLable.TabIndex = 0;
            this.ClickLable.Text = "Number of Clicks";
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Location = new System.Drawing.Point(1270, 91);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(83, 17);
            this.TimeLable.TabIndex = 1;
            this.TimeLable.Text = "Time Taken";
            // 
            // FlagLable
            // 
            this.FlagLable.AutoSize = true;
            this.FlagLable.Location = new System.Drawing.Point(1270, 129);
            this.FlagLable.Name = "FlagLable";
            this.FlagLable.Size = new System.Drawing.Size(70, 17);
            this.FlagLable.TabIndex = 2;
            this.FlagLable.Text = "Flags Left";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(1273, 265);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(153, 64);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back button\r\n";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.OutputLabel.Location = new System.Drawing.Point(238, 129);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(159, 58);
            this.OutputLabel.TabIndex = 4;
            this.OutputLabel.Text = "OutputLabel";
            this.OutputLabel.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1273, 365);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(153, 64);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save Grid";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FlagLable);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.ClickLable);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1623, 1056);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClickLable;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Label FlagLable;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Button SaveButton;
    }
}

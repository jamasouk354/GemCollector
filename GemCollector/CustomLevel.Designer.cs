namespace GemCollector
{
    partial class CustomLevel
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
            this.HeightInput = new System.Windows.Forms.TextBox();
            this.GemInput = new System.Windows.Forms.TextBox();
            this.WidthInput = new System.Windows.Forms.TextBox();
            this.HeightLable = new System.Windows.Forms.Label();
            this.WidthLable = new System.Windows.Forms.Label();
            this.GemsLable = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(124, 97);
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(100, 20);
            this.HeightInput.TabIndex = 0;
            // 
            // GemInput
            // 
            this.GemInput.Location = new System.Drawing.Point(124, 172);
            this.GemInput.Name = "GemInput";
            this.GemInput.Size = new System.Drawing.Size(100, 20);
            this.GemInput.TabIndex = 1;
            // 
            // WidthInput
            // 
            this.WidthInput.Location = new System.Drawing.Point(124, 133);
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(100, 20);
            this.WidthInput.TabIndex = 2;
            // 
            // HeightLable
            // 
            this.HeightLable.AutoSize = true;
            this.HeightLable.Location = new System.Drawing.Point(80, 100);
            this.HeightLable.Name = "HeightLable";
            this.HeightLable.Size = new System.Drawing.Size(38, 13);
            this.HeightLable.TabIndex = 3;
            this.HeightLable.Text = "Height";
            // 
            // WidthLable
            // 
            this.WidthLable.AutoSize = true;
            this.WidthLable.Location = new System.Drawing.Point(80, 136);
            this.WidthLable.Name = "WidthLable";
            this.WidthLable.Size = new System.Drawing.Size(35, 13);
            this.WidthLable.TabIndex = 4;
            this.WidthLable.Text = "Width";
            // 
            // GemsLable
            // 
            this.GemsLable.AutoSize = true;
            this.GemsLable.Location = new System.Drawing.Point(80, 175);
            this.GemsLable.Name = "GemsLable";
            this.GemsLable.Size = new System.Drawing.Size(34, 13);
            this.GemsLable.TabIndex = 5;
            this.GemsLable.Text = "Gems";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(241, 95);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(187, 97);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Wanna start the game now?";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(139, 64);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(0, 13);
            this.OutputLabel.TabIndex = 7;
            // 
            // CustomLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.GemsLable);
            this.Controls.Add(this.WidthLable);
            this.Controls.Add(this.HeightLable);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.GemInput);
            this.Controls.Add(this.HeightInput);
            this.Name = "CustomLevel";
            this.Size = new System.Drawing.Size(462, 291);
            this.Load += new System.EventHandler(this.CustomLevel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HeightInput;
        private System.Windows.Forms.TextBox GemInput;
        private System.Windows.Forms.TextBox WidthInput;
        private System.Windows.Forms.Label HeightLable;
        private System.Windows.Forms.Label WidthLable;
        private System.Windows.Forms.Label GemsLable;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label OutputLabel;
    }
}

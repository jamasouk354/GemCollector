namespace GemCollector
{
    partial class SelectScreen
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
            this.easyButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.customButtom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(230, 101);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(160, 50);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Can I play, Daddy?\r\n(Easy)\r\n";
            this.easyButton.UseVisualStyleBackColor = true;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalButton.Location = new System.Drawing.Point(230, 177);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(160, 50);
            this.normalButton.TabIndex = 1;
            this.normalButton.Text = "Bring \'em on!\r\n(Normal)\r\n";
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.Location = new System.Drawing.Point(230, 251);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(160, 50);
            this.hardButton.TabIndex = 2;
            this.hardButton.Text = "I am Death incarnate!\r\n(Hard)\r\n";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // customButtom
            // 
            this.customButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButtom.Location = new System.Drawing.Point(230, 321);
            this.customButtom.Name = "customButtom";
            this.customButtom.Size = new System.Drawing.Size(160, 50);
            this.customButtom.TabIndex = 3;
            this.customButtom.Text = "CustomizeYourLevel\r\n(Customise)";
            this.customButtom.UseVisualStyleBackColor = true;
            this.customButtom.Click += new System.EventHandler(this.customButtom_Click);
            // 
            // SelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customButtom);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.easyButton);
            this.Name = "SelectScreen";
            this.Size = new System.Drawing.Size(977, 730);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button customButtom;
    }
}

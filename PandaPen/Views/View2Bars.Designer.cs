namespace PandaPen
{
    partial class View2Bars
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cleanBtn = new System.Windows.Forms.Button();
            this.fBtn = new System.Windows.Forms.Button();
            this.happinessBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.oxygenBar = new System.Windows.Forms.ProgressBar();
            this.hungryBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.animalPicBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cleanBtn
            // 
            this.cleanBtn.Location = new System.Drawing.Point(163, 277);
            this.cleanBtn.Name = "cleanBtn";
            this.cleanBtn.Size = new System.Drawing.Size(75, 23);
            this.cleanBtn.TabIndex = 23;
            this.cleanBtn.Text = "Clean";
            this.cleanBtn.UseVisualStyleBackColor = true;
            this.cleanBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // fBtn
            // 
            this.fBtn.Location = new System.Drawing.Point(11, 277);
            this.fBtn.Name = "fBtn";
            this.fBtn.Size = new System.Drawing.Size(75, 23);
            this.fBtn.TabIndex = 22;
            this.fBtn.Text = "Eat";
            this.fBtn.UseVisualStyleBackColor = true;
            this.fBtn.Click += new System.EventHandler(this.fBtn_Click);
            // 
            // happinessBar
            // 
            this.happinessBar.Location = new System.Drawing.Point(11, 332);
            this.happinessBar.Name = "happinessBar";
            this.happinessBar.Size = new System.Drawing.Size(427, 23);
            this.happinessBar.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Happiness";
            // 
            // oxygenBar
            // 
            this.oxygenBar.Location = new System.Drawing.Point(305, 175);
            this.oxygenBar.Name = "oxygenBar";
            this.oxygenBar.Size = new System.Drawing.Size(136, 23);
            this.oxygenBar.TabIndex = 19;
            // 
            // hungryBar
            // 
            this.hungryBar.Location = new System.Drawing.Point(305, 100);
            this.hungryBar.Name = "hungryBar";
            this.hungryBar.Size = new System.Drawing.Size(136, 23);
            this.hungryBar.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Oxygen Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Hunger";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.animalPicBox);
            this.panel1.Location = new System.Drawing.Point(11, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 232);
            this.panel1.TabIndex = 15;
            // 
            // animalPicBox
            // 
            this.animalPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.animalPicBox.Location = new System.Drawing.Point(18, 14);
            this.animalPicBox.Name = "animalPicBox";
            this.animalPicBox.Size = new System.Drawing.Size(231, 215);
            this.animalPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animalPicBox.TabIndex = 0;
            this.animalPicBox.TabStop = false;
            // 
            // View2Bars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 372);
            this.Controls.Add(this.cleanBtn);
            this.Controls.Add(this.fBtn);
            this.Controls.Add(this.happinessBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.oxygenBar);
            this.Controls.Add(this.hungryBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "View2Bars";
            this.Text = "View2";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animalPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cleanBtn;
        public System.Windows.Forms.Button fBtn;
        public System.Windows.Forms.ProgressBar happinessBar;
        public System.Windows.Forms.PictureBox animalPicBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ProgressBar oxygenBar;
        public System.Windows.Forms.ProgressBar hungryBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
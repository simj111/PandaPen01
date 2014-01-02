namespace PandaPen
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.panel1 = new System.Windows.Forms.Panel();
            this.animalPicBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hungryBar = new System.Windows.Forms.ProgressBar();
            this.energyBar = new System.Windows.Forms.ProgressBar();
            this.fitnessBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.happinessBar = new System.Windows.Forms.ProgressBar();
            this.fBtn = new System.Windows.Forms.Button();
            this.sBtn = new System.Windows.Forms.Button();
            this.eBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.animalType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.animalPicBox);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 232);
            this.panel1.TabIndex = 0;
            // 
            // animalPicBox
            // 
            this.animalPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.animalPicBox.Image = ((System.Drawing.Image)(resources.GetObject("animalPicBox.Image")));
            this.animalPicBox.Location = new System.Drawing.Point(18, 14);
            this.animalPicBox.Name = "animalPicBox";
            this.animalPicBox.Size = new System.Drawing.Size(231, 215);
            this.animalPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animalPicBox.TabIndex = 0;
            this.animalPicBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hunger";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Energy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fitness";
            // 
            // hungryBar
            // 
            this.hungryBar.Location = new System.Drawing.Point(306, 109);
            this.hungryBar.Name = "hungryBar";
            this.hungryBar.Size = new System.Drawing.Size(136, 23);
            this.hungryBar.TabIndex = 4;
            // 
            // energyBar
            // 
            this.energyBar.Location = new System.Drawing.Point(306, 184);
            this.energyBar.Name = "energyBar";
            this.energyBar.Size = new System.Drawing.Size(136, 23);
            this.energyBar.TabIndex = 5;
            // 
            // fitnessBar
            // 
            this.fitnessBar.Location = new System.Drawing.Point(306, 258);
            this.fitnessBar.Name = "fitnessBar";
            this.fitnessBar.Size = new System.Drawing.Size(136, 23);
            this.fitnessBar.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Happiness";
            // 
            // happinessBar
            // 
            this.happinessBar.Location = new System.Drawing.Point(12, 383);
            this.happinessBar.Name = "happinessBar";
            this.happinessBar.Size = new System.Drawing.Size(427, 23);
            this.happinessBar.TabIndex = 8;
            // 
            // fBtn
            // 
            this.fBtn.Location = new System.Drawing.Point(12, 328);
            this.fBtn.Name = "fBtn";
            this.fBtn.Size = new System.Drawing.Size(75, 23);
            this.fBtn.TabIndex = 9;
            this.fBtn.Text = "Eat";
            this.fBtn.UseVisualStyleBackColor = true;
            this.fBtn.Click += new System.EventHandler(this.fBtn_Click);
            // 
            // sBtn
            // 
            this.sBtn.Location = new System.Drawing.Point(164, 328);
            this.sBtn.Name = "sBtn";
            this.sBtn.Size = new System.Drawing.Size(75, 23);
            this.sBtn.TabIndex = 10;
            this.sBtn.Text = "Sleep";
            this.sBtn.UseVisualStyleBackColor = true;
            this.sBtn.Click += new System.EventHandler(this.sBtn_Click);
            // 
            // eBtn
            // 
            this.eBtn.Location = new System.Drawing.Point(327, 328);
            this.eBtn.Name = "eBtn";
            this.eBtn.Size = new System.Drawing.Size(75, 23);
            this.eBtn.TabIndex = 11;
            this.eBtn.Text = "Exercise";
            this.eBtn.UseVisualStyleBackColor = true;
            this.eBtn.Click += new System.EventHandler(this.eBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Animal Type";
            // 
            // animalType
            // 
            this.animalType.FormattingEnabled = true;
            this.animalType.Location = new System.Drawing.Point(12, 37);
            this.animalType.Name = "animalType";
            this.animalType.Size = new System.Drawing.Size(121, 21);
            this.animalType.TabIndex = 12;
            this.animalType.Text = "Please Select Animal";
            this.animalType.SelectedIndexChanged += new System.EventHandler(this.animalType_SelectedIndexChanged);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 415);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.animalType);
            this.Controls.Add(this.eBtn);
            this.Controls.Add(this.sBtn);
            this.Controls.Add(this.fBtn);
            this.Controls.Add(this.happinessBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fitnessBar);
            this.Controls.Add(this.energyBar);
            this.Controls.Add(this.hungryBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "View";
            this.Text = "View";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animalPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void ReciveInfomation()
        {

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox animalPicBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ProgressBar hungryBar;
        public System.Windows.Forms.ProgressBar energyBar;
        public System.Windows.Forms.ProgressBar fitnessBar;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ProgressBar happinessBar;
        public System.Windows.Forms.Button fBtn;
        public System.Windows.Forms.Button sBtn;
        public System.Windows.Forms.Button eBtn;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox animalType;
    }
}


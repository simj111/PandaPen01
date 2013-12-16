using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PandaPen
{
    public partial class View : Form
    {
        public View()
        {
            System.Windows.Forms.ComboBox animalType;
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
            animalType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // animalType
            // 
            animalType.FormattingEnabled = true;
            animalType.Location = new System.Drawing.Point(12, 37);
            animalType.Name = "animalType";
            animalType.Size = new System.Drawing.Size(121, 21);
            animalType.TabIndex = 12;
            animalType.Text = "Panda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.animalPicBox);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 232);
            this.panel1.TabIndex = 0;
            // 
            // animalPicBox
            // 
            this.animalPicBox.Image = global::PandaPen.Properties.Resources.Panda;
            this.animalPicBox.Location = new System.Drawing.Point(110, 179);
            this.animalPicBox.Name = "animalPicBox";
            this.animalPicBox.Size = new System.Drawing.Size(46, 50);
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
            // 
            // sBtn
            // 
            this.sBtn.Location = new System.Drawing.Point(164, 328);
            this.sBtn.Name = "sBtn";
            this.sBtn.Size = new System.Drawing.Size(75, 23);
            this.sBtn.TabIndex = 10;
            this.sBtn.Text = "Sleep";
            this.sBtn.UseVisualStyleBackColor = true;
            // 
            // eBtn
            // 
            this.eBtn.Location = new System.Drawing.Point(327, 328);
            this.eBtn.Name = "eBtn";
            this.eBtn.Size = new System.Drawing.Size(75, 23);
            this.eBtn.TabIndex = 11;
            this.eBtn.Text = "Exercise";
            this.eBtn.UseVisualStyleBackColor = true;
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
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 415);
            this.Controls.Add(this.label5);
            this.Controls.Add(animalType);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // View
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "View";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);

        }

        private void View_Load(object sender, EventArgs e)
        {

        }


    }
}

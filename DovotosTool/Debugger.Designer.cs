﻿namespace DovotosTool
{
    partial class Debugger
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
            this.tbDissassemble = new System.Windows.Forms.TextBox();
            this.tbGoto = new System.Windows.Forms.TextBox();
            this.tbA = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbPC = new System.Windows.Forms.TextBox();
            this.tbSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbF = new System.Windows.Forms.TextBox();
            this.cbN = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbV = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbZ = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbI = new System.Windows.Forms.CheckBox();
            this.tbStack = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnOneLine = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnOneFrame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDissassemble
            // 
            this.tbDissassemble.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDissassemble.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDissassemble.Location = new System.Drawing.Point(0, 0);
            this.tbDissassemble.Multiline = true;
            this.tbDissassemble.Name = "tbDissassemble";
            this.tbDissassemble.Size = new System.Drawing.Size(927, 925);
            this.tbDissassemble.TabIndex = 0;
            // 
            // tbGoto
            // 
            this.tbGoto.Location = new System.Drawing.Point(953, 887);
            this.tbGoto.Name = "tbGoto";
            this.tbGoto.Size = new System.Drawing.Size(100, 26);
            this.tbGoto.TabIndex = 1;
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(1168, 12);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(100, 26);
            this.tbA.TabIndex = 2;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(1168, 44);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 26);
            this.tbX.TabIndex = 3;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(1168, 76);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 26);
            this.tbY.TabIndex = 4;
            // 
            // tbPC
            // 
            this.tbPC.Location = new System.Drawing.Point(986, 12);
            this.tbPC.Name = "tbPC";
            this.tbPC.Size = new System.Drawing.Size(100, 26);
            this.tbPC.TabIndex = 5;
            // 
            // tbSP
            // 
            this.tbSP.Location = new System.Drawing.Point(1168, 108);
            this.tbSP.Name = "tbSP";
            this.tbSP.Size = new System.Drawing.Size(100, 26);
            this.tbSP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1131, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1131, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1131, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1131, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(949, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "PC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1132, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "F";
            // 
            // tbF
            // 
            this.tbF.Location = new System.Drawing.Point(1169, 140);
            this.tbF.Name = "tbF";
            this.tbF.Size = new System.Drawing.Size(100, 26);
            this.tbF.TabIndex = 12;
            // 
            // cbN
            // 
            this.cbN.AutoSize = true;
            this.cbN.Location = new System.Drawing.Point(1135, 181);
            this.cbN.Name = "cbN";
            this.cbN.Size = new System.Drawing.Size(22, 21);
            this.cbN.TabIndex = 14;
            this.cbN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbN.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1132, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1160, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "V";
            // 
            // cbV
            // 
            this.cbV.AutoSize = true;
            this.cbV.Location = new System.Drawing.Point(1163, 181);
            this.cbV.Name = "cbV";
            this.cbV.Size = new System.Drawing.Size(22, 21);
            this.cbV.TabIndex = 16;
            this.cbV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbV.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1188, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "C";
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Location = new System.Drawing.Point(1191, 181);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(22, 21);
            this.cbC.TabIndex = 18;
            this.cbC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbC.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1216, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Z";
            // 
            // cbZ
            // 
            this.cbZ.AutoSize = true;
            this.cbZ.Location = new System.Drawing.Point(1219, 181);
            this.cbZ.Name = "cbZ";
            this.cbZ.Size = new System.Drawing.Size(22, 21);
            this.cbZ.TabIndex = 20;
            this.cbZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbZ.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1241, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "I";
            // 
            // cbI
            // 
            this.cbI.AutoSize = true;
            this.cbI.Location = new System.Drawing.Point(1245, 181);
            this.cbI.Name = "cbI";
            this.cbI.Size = new System.Drawing.Size(22, 21);
            this.cbI.TabIndex = 22;
            this.cbI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbI.UseVisualStyleBackColor = true;
            // 
            // tbStack
            // 
            this.tbStack.Location = new System.Drawing.Point(1169, 265);
            this.tbStack.Multiline = true;
            this.tbStack.Name = "tbStack";
            this.tbStack.Size = new System.Drawing.Size(100, 648);
            this.tbStack.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1191, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Stack";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(953, 309);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 35);
            this.btnPause.TabIndex = 27;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(953, 268);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 35);
            this.btnRun.TabIndex = 28;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(953, 350);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 35);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(953, 391);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 35);
            this.btnStep.TabIndex = 30;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.BtnStep_Click);
            // 
            // btnOneLine
            // 
            this.btnOneLine.Location = new System.Drawing.Point(953, 432);
            this.btnOneLine.Name = "btnOneLine";
            this.btnOneLine.Size = new System.Drawing.Size(133, 35);
            this.btnOneLine.TabIndex = 31;
            this.btnOneLine.Text = "One Line";
            this.btnOneLine.UseVisualStyleBackColor = true;
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(1076, 878);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 35);
            this.btnGoto.TabIndex = 32;
            this.btnGoto.Text = "Goto";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.BtnGoto_Click);
            // 
            // btnOneFrame
            // 
            this.btnOneFrame.Location = new System.Drawing.Point(953, 473);
            this.btnOneFrame.Name = "btnOneFrame";
            this.btnOneFrame.Size = new System.Drawing.Size(133, 35);
            this.btnOneFrame.TabIndex = 33;
            this.btnOneFrame.Text = "One Frame";
            this.btnOneFrame.UseVisualStyleBackColor = true;
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 925);
            this.Controls.Add(this.btnOneFrame);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnOneLine);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbStack);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbI);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbZ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSP);
            this.Controls.Add(this.tbPC);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.tbGoto);
            this.Controls.Add(this.tbDissassemble);
            this.Name = "Debugger";
            this.Text = "Debugger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDissassemble;
        private System.Windows.Forms.TextBox tbGoto;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbPC;
        private System.Windows.Forms.TextBox tbSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.CheckBox cbN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbZ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbI;
        private System.Windows.Forms.TextBox tbStack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnOneLine;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnOneFrame;
    }
}
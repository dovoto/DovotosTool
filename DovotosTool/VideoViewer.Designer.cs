namespace DovotosTool
{
    partial class VideoViewer
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
            this.pbPalette = new System.Windows.Forms.PictureBox();
            this.lblPalIndex = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbPPU = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCHR = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPPU)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCHR)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPalette
            // 
            this.pbPalette.Location = new System.Drawing.Point(518, 6);
            this.pbPalette.Name = "pbPalette";
            this.pbPalette.Size = new System.Drawing.Size(94, 32);
            this.pbPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPalette.TabIndex = 2;
            this.pbPalette.TabStop = false;
            // 
            // lblPalIndex
            // 
            this.lblPalIndex.AutoSize = true;
            this.lblPalIndex.Location = new System.Drawing.Point(618, 18);
            this.lblPalIndex.Name = "lblPalIndex";
            this.lblPalIndex.Size = new System.Drawing.Size(18, 20);
            this.lblPalIndex.TabIndex = 4;
            this.lblPalIndex.Text = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 614);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbPPU);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(685, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PPU Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbPPU
            // 
            this.pbPPU.Location = new System.Drawing.Point(6, 6);
            this.pbPPU.Name = "pbPPU";
            this.pbPPU.Size = new System.Drawing.Size(512, 512);
            this.pbPPU.TabIndex = 0;
            this.pbPPU.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblAddress);
            this.tabPage2.Controls.Add(this.lblBank);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.pbCHR);
            this.tabPage2.Controls.Add(this.lblPalIndex);
            this.tabPage2.Controls.Add(this.pbPalette);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CHR";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(618, 76);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(18, 20);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "0";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(618, 56);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(18, 20);
            this.lblBank.TabIndex = 7;
            this.lblBank.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bank";
            // 
            // pbCHR
            // 
            this.pbCHR.Location = new System.Drawing.Point(0, 6);
            this.pbCHR.Name = "pbCHR";
            this.pbCHR.Size = new System.Drawing.Size(512, 512);
            this.pbCHR.TabIndex = 0;
            this.pbCHR.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(685, 581);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nametables";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // VideoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 614);
            this.Controls.Add(this.tabControl1);
            this.Name = "VideoViewer";
            this.Text = "VideoViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPPU)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCHR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbPalette;
        private System.Windows.Forms.Label lblPalIndex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pbPPU;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCHR;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
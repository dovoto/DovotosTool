namespace DovotosTool
{
    partial class MemoryViewer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbSram = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbNameTable = new System.Windows.Forms.TextBox();
            this.tpRom = new System.Windows.Forms.TabPage();
            this.tbRom = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tpRom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tpRom);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1560, 924);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbSram);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1552, 891);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SRAM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbSram
            // 
            this.tbSram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSram.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSram.Location = new System.Drawing.Point(3, 3);
            this.tbSram.Multiline = true;
            this.tbSram.Name = "tbSram";
            this.tbSram.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSram.Size = new System.Drawing.Size(1546, 885);
            this.tbSram.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbNameTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1552, 891);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PPU Nametables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbNameTable
            // 
            this.tbNameTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNameTable.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNameTable.Location = new System.Drawing.Point(3, 3);
            this.tbNameTable.Multiline = true;
            this.tbNameTable.Name = "tbNameTable";
            this.tbNameTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNameTable.Size = new System.Drawing.Size(1546, 885);
            this.tbNameTable.TabIndex = 0;
            // 
            // tpRom
            // 
            this.tpRom.Controls.Add(this.tbRom);
            this.tpRom.Location = new System.Drawing.Point(4, 29);
            this.tpRom.Name = "tpRom";
            this.tpRom.Padding = new System.Windows.Forms.Padding(3);
            this.tpRom.Size = new System.Drawing.Size(1552, 891);
            this.tpRom.TabIndex = 2;
            this.tpRom.Text = "ROM";
            this.tpRom.UseVisualStyleBackColor = true;
            // 
            // tbRom
            // 
            this.tbRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRom.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRom.Location = new System.Drawing.Point(3, 3);
            this.tbRom.Multiline = true;
            this.tbRom.Name = "tbRom";
            this.tbRom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRom.Size = new System.Drawing.Size(1546, 885);
            this.tbRom.TabIndex = 0;
            // 
            // MemoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 924);
            this.Controls.Add(this.tabControl1);
            this.Name = "MemoryViewer";
            this.Text = "MemoryViewer";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tpRom.ResumeLayout(false);
            this.tpRom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbSram;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbNameTable;
        private System.Windows.Forms.TabPage tpRom;
        private System.Windows.Forms.TextBox tbRom;
    }
}
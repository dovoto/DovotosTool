namespace DovotosTool
{
    partial class PaletteViewer
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
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPalette
            // 
            this.pbPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPalette.Location = new System.Drawing.Point(0, 0);
            this.pbPalette.Name = "pbPalette";
            this.pbPalette.Size = new System.Drawing.Size(234, 968);
            this.pbPalette.TabIndex = 0;
            this.pbPalette.TabStop = false;
            // 
            // PaletteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 968);
            this.Controls.Add(this.pbPalette);
            this.Name = "PaletteViewer";
            this.Text = "PaletteViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPalette;
    }
}
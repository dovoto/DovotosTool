namespace DovotosTool
{
    partial class VideoOutput
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
            this.pbVideoOut = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoOut)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVideoOut
            // 
            this.pbVideoOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVideoOut.Location = new System.Drawing.Point(0, 0);
            this.pbVideoOut.Name = "pbVideoOut";
            this.pbVideoOut.Size = new System.Drawing.Size(234, 184);
            this.pbVideoOut.TabIndex = 0;
            this.pbVideoOut.TabStop = false;
            // 
            // VideoOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 184);
            this.Controls.Add(this.pbVideoOut);
            this.MinimumSize = new System.Drawing.Size(256, 240);
            this.Name = "VideoOutput";
            this.Text = "Video Output";
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVideoOut;
    }
}
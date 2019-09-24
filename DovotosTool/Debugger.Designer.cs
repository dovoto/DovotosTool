namespace DovotosTool
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
            this.SuspendLayout();
            // 
            // tbDissassemble
            // 
            this.tbDissassemble.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDissassemble.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDissassemble.Location = new System.Drawing.Point(0, 0);
            this.tbDissassemble.Multiline = true;
            this.tbDissassemble.Name = "tbDissassemble";
            this.tbDissassemble.Size = new System.Drawing.Size(927, 450);
            this.tbDissassemble.TabIndex = 0;
            // 
            // tbGoto
            // 
            this.tbGoto.Location = new System.Drawing.Point(1011, 12);
            this.tbGoto.Name = "tbGoto";
            this.tbGoto.Size = new System.Drawing.Size(100, 26);
            this.tbGoto.TabIndex = 1;
            this.tbGoto.TextChanged += new System.EventHandler(this.TbGoto_TextChanged);
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 450);
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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DovotosTool
{
    public partial class Form1 : Form
    {

        public GameState GameState;

        public Form1()
        {
            InitializeComponent();

            GameState = new GameState();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "nes files(*.nes)| *.nes";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Stream file =  ofd.OpenFile();

                GameState = new GameState(file);
            }

           
        }

        private void CartridgeHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CartridgeHeader();
            
            f.Show();
        }

        private void PaletteViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new PaletteViewer();

            f.Show();
        }

        private void VideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new VideoViewer();

            f.Show();
        }

        private void DebuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Debugger();

            f.Show();
        }
    }
}

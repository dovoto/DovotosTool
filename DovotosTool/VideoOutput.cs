using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DovotosTool
{
    public partial class VideoOutput : Form
    {
        public VideoOutput()
        {
            InitializeComponent();

            pbVideoOut.Image = PPU.VideoOutput;

            PPU.VBlank += VBlank;
        }

        void VBlank()
        {
            pbVideoOut.Image = PPU.VideoOutput;
        }
    }
}

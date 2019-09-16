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
    public partial class PaletteViewer : Form
    {
        Bitmap palette;

        public PaletteViewer()
        {
            InitializeComponent();

           


            Paint += PaletteViewer_Paint;
            Resize += PaletteViewer_Resize;
        }

        private void PaletteViewer_Resize(object sender, EventArgs e)
        {
            Redraw();
        }

        private void PaletteViewer_Paint(object sender, PaintEventArgs e)
        {
            Redraw();

        }

        private void Redraw()
        {
            int mul = pbPalette.Width / 4 > pbPalette.Height / 16 ? pbPalette.Height / 16 : pbPalette.Width / 4;

            palette = new Bitmap(4 * mul, 16 * mul);

            for (int x = 0; x < 4 * mul; x++)
                for (int y = 0; y < 16 * mul; y++)
                {
                    palette.SetPixel(x, y, GameState.Palette[x / mul + y / mul * 4]);
                }

            pbPalette.Image = palette;
        }




    }
}

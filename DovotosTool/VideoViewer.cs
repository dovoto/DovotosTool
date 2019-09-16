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
    public partial class VideoViewer : Form
    {
        Bitmap palette;
        Bitmap CHR;
        int bank = 0;
        int address = 0;

        int palIndex = 0;

        public VideoViewer()
        {
            InitializeComponent();

            palette = new Bitmap(4 * 16, 1 * 16);
            CHR = new Bitmap(512,512);

            Paint += VideoViewer_Paint;
            Resize += VideoViewer_Resize;

            pbPalette.MouseWheel += PbPalette_MouseWheel;
            lblBank.MouseWheel += LblBank_MouseWheel;
            lblAddress.MouseWheel += LblAddress_MouseWheel;

            GameState.Reloaded += Redraw;

            Redraw();
        }

        private void LblAddress_MouseWheel(object sender, MouseEventArgs e)
        {
            address ^= 1;
            lblAddress.Text = (4096 * address).ToString();
            Redraw();
        }

        private void LblBank_MouseWheel(object sender, MouseEventArgs e)
        {
            bank += e.Delta > 0 ? 1 : -1;

            if (bank < 0) bank = 0;
            if (bank >= GameState.header.CHRBanks) bank = GameState.header.CHRBanks-1;

            lblBank.Text = bank.ToString() + "  (" + string.Format("{0:X4}",bank * 8192) + ")";

            Redraw();
        }

        private void PbPalette_MouseWheel(object sender, MouseEventArgs e)
        {
            palIndex += e.Delta > 0 ? 1 : -1;

            if (palIndex < 0) palIndex = 0;
            if (palIndex > 15) palIndex = 15;

            lblPalIndex.Text = palIndex.ToString();

            Redraw();
        }

        private void VideoViewer_Resize(object sender, EventArgs e)
        {
          
        }

        private void VideoViewer_Paint(object sender, PaintEventArgs e)
        {
           
        }



        private void Redraw()
        {
            if (GameState.RawCHR != null && GameState.RawCHR.Length >= 4096)
            {

                int x = 0;
                int y = 0;

                for (int t = 0; t < 256; t++)
                {
                    y = t / 16 * 32;

                    for (int ty = 0; ty < 8; ty++)
                    {
                        int p0 = GameState.RawCHR[t * (8 * 2) + ty  + bank * 8192 + address * 4096];
                        int p1 = GameState.RawCHR[t * (8 * 2) + 8 + ty  + bank * 8192 + address * 4096];

                        for (int i = 0; i < 4; i++)
                        {
                            x = (t % 16) * 32;
   
                            int c = (((p0 >> 7) & 1) << 1) | ((p1 >> 7) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 6) & 1) << 1) | ((p1 >> 6) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 5) & 1) << 1) | ((p1 >> 5) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 4) & 1) << 1) | ((p1 >> 4) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 3) & 1) << 1) | ((p1 >> 3) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 2) & 1) << 1) | ((p1 >> 2) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 1) & 1) << 1) | ((p1 >> 1) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            c = (((p0 >> 0) & 1) << 1) | ((p1 >> 0) & 1);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);
                            CHR.SetPixel(x++, y, GameState.Palette[palIndex * 4 + c]);


                            y++;
                        }
                    }
                }

            }
            for (int x = 0; x < 4 * 16; x++)
                for (int y = 0; y < 1 * 16; y++)
                {
                    palette.SetPixel(x, y, GameState.Palette[x / 16 + palIndex * 4]);
                }

            pbPalette.Image = palette;
            pbCHR.Image = CHR;           
        }


    }
}

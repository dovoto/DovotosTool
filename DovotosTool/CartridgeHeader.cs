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
    public partial class CartridgeHeader : Form
    {
        public GameState GameState;

        public CartridgeHeader()
        {
            InitializeComponent();

            Reload();

            GameState.Reloaded += Reload;
        }

        private void Reload()
        {

            if (GameState.header.raw == null || GameState.header.raw.Length != 16)
            {
                tbCart.Text = "load Rom! ";
                return;
            }

            tbCart.Text = "Header data: ";

            for (int i = 0; i < 16; i++)
                tbCart.Text += String.Format("{0:X2} ", GameState.header.raw[i]);

            tbCart.Text += Environment.NewLine + Environment.NewLine;

            tbCart.Text += GameState.header.nes + Environment.NewLine;
            tbCart.Text += "Mapper: " + GameState.header.mapper + Environment.NewLine;
            tbCart.Text += "PRG Bank Count: " + GameState.header.PRGBanks + " (" + GameState.header.PRGBanks * 16384 + ") " + Environment.NewLine;
            tbCart.Text += "CHR Bank Count: " + GameState.header.CHRBanks + " (" + GameState.header.CHRBanks * 8192 + ") " + Environment.NewLine;
            tbCart.Text += "CHR Ram: " + (GameState.header.CHRBanks == 0 ? "True" : "False") + Environment.NewLine;
            tbCart.Text += "PRG Ram: " + GameState.header.PRGRam + Environment.NewLine;
            tbCart.Text += "PRG Ram Battery Backed: " + GameState.header.batBackedPRGRam + Environment.NewLine;
            tbCart.Text += "PRG Ram Count: " + GameState.header.PRGRamBanks + " (" + GameState.header.PRGRamBanks * 8192 + ") " + Environment.NewLine;
            tbCart.Text += "NTSC: " + GameState.header.NTSC + Environment.NewLine;
            tbCart.Text += "NES 2.0 format: " + GameState.header.NES2_0 + Environment.NewLine;
            tbCart.Text += "PlayChoice: " + GameState.header.PlayChoice + Environment.NewLine;
            tbCart.Text += "Trainer: " + GameState.header.trainerPresent + Environment.NewLine;
            tbCart.Text += "Mirroring: " + (GameState.header.fourScreenVram ? "Four Screen" : GameState.header.VerticalMirror ? "Vertical" : "Horizontal") + Environment.NewLine;
            tbCart.Text += "VS System: " + GameState.header.VSunisys + Environment.NewLine;
        }

    }
}

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
    public partial class MemoryViewer : Form
    {
        public MemoryViewer()
        {
            InitializeComponent();

            Debugger.Step += SramUpdate;

            SramUpdate();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SramUpdate();
        }

        void SramUpdate()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                sb.Append(string.Format("{0:X4}: ", i * 32));

                for(int i2 = 0; i2 < 32; i2++)
                {
                    sb.Append(string.Format("{0:X2} ", GameState.Cart.CPURead(i * 32 + i2)));
                }
                for (int i2 = 0; i2 < 32; i2++)
                {
                    Char c = (Char)GameState.Cart.CPURead(i * 32 + i2);

                    sb.Append(string.Format("{0}", (Char.IsLetter(c) || Char.IsDigit(c) || c==' ') ? c : '.'));
                }

                sb.Append(Environment.NewLine);
            }

            tbSram.Text = sb.ToString();
        }
    }
}

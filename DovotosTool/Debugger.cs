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
    public partial class Debugger : Form
    {
        public Debugger()
        {
            InitializeComponent();

            tbGoto.Text = string.Format("{0:X4}", GameState.CPU.PC);

            Redraw();
        }

        private void TbGoto_TextChanged(object sender, EventArgs e)
        {
            try {
                GameState.CPU.PC = Convert.ToInt32(tbGoto.Text, 16);
            }
            catch
            {
                GameState.CPU.PC = 0;
            }

            Redraw();

        }

        private void Redraw()
        {
            if (!GameState.initialized) return;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                CPU_6502.Opcode op = CPU_6502.Opcode.Opcodes[GameState.Cart.CPURead(GameState.CPU.PC)];

                sb.Append(string.Format("{0:X4}: ", GameState.CPU.PC));

                for (int c = 0; c < 3; c++)
                {
                    if (c <= op.Size()-1)
                        sb.Append(string.Format("{0:X2} ", GameState.Cart.CPURead(GameState.CPU.PC + c)));
                    else
                        sb.Append("   ");

                }

                sb.Append("\t");

                sb.Append(op.Dissassemble());

                sb.Append(Environment.NewLine);

                GameState.CPU.PC += op.Size();

            }

            tbDissassemble.Text = sb.ToString();
        }
    }
}

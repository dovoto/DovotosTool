﻿using System;
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
        public int cycles = 0;

        public Debugger()
        {
            InitializeComponent();

            tbGoto.Text = string.Format("{0:X4}", GameState.CPU.PC);

            Step += Redraw;

            Redraw();
        }

        public delegate void StepHandler();
        public static StepHandler Step;

        private void Redraw()
        {
            if (!GameState.initialized) return;

            int index = GameState.CPU.PC;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 40; i++)
            {
                CPU_6502.Opcode op = CPU_6502.Opcode.Opcodes[GameState.Cart.CPURead(index)];

                sb.Append(string.Format("{0:X4}: ", index));

                for (int c = 0; c < 3; c++)
                {
                    if (c <= op.Size() - 1)
                        sb.Append(string.Format("{0:X2} ", GameState.Cart.CPURead(index + c)));
                    else
                        sb.Append("   ");

                }

                sb.Append("\t");

                sb.Append(op.Dissassemble(index));

                sb.Append(Environment.NewLine);

                index += op.Size();

            }

            tbDissassemble.Text = sb.ToString();

            tbA.Text = string.Format("{0:X2}", GameState.CPU.A);
            tbX.Text = string.Format("{0:X2}", GameState.CPU.X);
            tbY.Text = string.Format("{0:X2}", GameState.CPU.Y);
            tbSP.Text = string.Format("{0:X2}", GameState.CPU.SP);
            tbF.Text = string.Format("{0:X2}", GameState.CPU.F);
            tbPC.Text = string.Format("{0:X4}", GameState.CPU.PC);

            cbN.Checked = GameState.CPU.N;
            cbI.Checked = GameState.CPU.I;
            cbV.Checked = GameState.CPU.V;
            cbZ.Checked = GameState.CPU.Z;
            cbC.Checked = GameState.CPU.C;

            sb.Clear();

            for (int i = 0; i < 64; i++)
            {
                sb.Append(string.Format("{0:X2}", GameState.Cart.CPURead(i + 0x100)) + Environment.NewLine);
            }

            tbStack.Text = sb.ToString();

            lblCyclesTillFrame.Text = (PPU.CyclesPerLine * (PPU.Scanlines - PPU.Scanline) - cycles).ToString();
            lblCyclesTillLine.Text = (((PPU.Scanline + 1) * PPU.CyclesPerLine) - cycles).ToString();
            lblCyclesTillVblank.Text = (PPU.CyclesPerLine * (241 - PPU.Scanline) - cycles).ToString();
            lblLineNumber.Text = PPU.Scanline.ToString();

        }

        private void BtnGoto_Click(object sender, EventArgs e)
        {
            try
            {
                GameState.CPU.PC = Convert.ToInt32(tbGoto.Text, 16);
            }
            catch
            {
                GameState.CPU.PC = 0;
            }

            Redraw();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            GameState.CPU.Reset();
            Step();
        }

        private void BtnStep_Click(object sender, EventArgs e)
        {
            cycles += GameState.CPU.Execute();

            if (cycles >= ((PPU.Scanline + 1) * PPU.CyclesPerLine))
            {
                PPU.RenderLine();
            }

            Step();
        }

        private void RunOneLine()
        {


            while (cycles < ((PPU.Scanline + 1) * PPU.CyclesPerLine))
            {
                cycles += GameState.CPU.Execute();

            }

            PPU.RenderLine();
        }

        private void BtnOneLine_Click(object sender, EventArgs e)
        {
            RunOneLine();
            Step();
        }
    }
}

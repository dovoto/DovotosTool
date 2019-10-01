using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovotosTool.Mappers
{
    public class NROM : Mapper
    {
        public NROM()
        {
            PRGRom = GameState.RawPRG;

            chrRam = GameState.header.CHRBanks == 0;

            if (chrRam)
                CHRRam = new byte[8192];
            else
                CHRRom = GameState.RawCHR;

            if(GameState.header.PRGRam)
                PRGRam = new byte[8192];
        }
        public override byte CPUReadExt(int address)
        {

                if (GameState.header.PRGBanks == 1)
                    address &= 0x3FFF;
                else
                    address &= 0x7FFF;

                return PRGRom[address];

        }

        public override void CPUWriteExt(byte d, int address)
        {

                if (GameState.header.PRGBanks == 1)
                    address &= 0x3FFF;
                else
                    address &= 0x7FFF;

                PRGRom[address] = d;

        }

        public override byte PPUReadExt(int address)
        {
            if (address < 0x2000)
            {
                return chrRam ? CHRRam[address & 0x1FFF] : CHRRom[address & 0x1FFF];
            }
            else if (address < 0x3000)
            {
                //todo: mirroring
                return PPU.PPU_RAM[address & 0x7FF];
            }
            else if(address >= 0x3F00 && address < 0x3f20)
            {
                return PPU.Palettes[address & 0x1F];
            }

            return 0xFF;
        }

        public override void PPUWriteExt(byte d, int address)
        {
            //todo:mirroring
            if (address < 0x2000)
            {
                if(chrRam)CHRRam[address & 0x1FFF] = d;
            }
            else if (address < 0x3000)
            {
                PPU.PPU_RAM[address & 0x7FF] = d;
            }
            else if (address >= 0x3F00 && address < 0x3f20)
            {
                PPU.Palettes[address & 0x1F] = d;
            }
        }
    }
}

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
            //todo: mirroring
            return chrRam ? CHRRam[address & 0x3FFF] : CHRRom[address & 0x3FFF];
        }

        public override void PPUWriteExt(byte d, int address)
        {
            //todo:mirroring
            if (chrRam) CHRRam[address & 0x3FFF] = d;
        }
    }
}

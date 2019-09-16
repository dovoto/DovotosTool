using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovotosTool.Mappers
{
    public class MMC1 : Mapper
    {
 
        public MMC1()
        {
            PRGRom = new byte[GameState.header.PRGBanks * 16384];

            chrRam = GameState.header.CHRBanks == 0;
            if (chrRam)
                CHRRam = new byte[8192];
            else
                CHRRom = new byte[GameState.header.CHRBanks * 8192];
        }
        public override byte CPURead(int address)
        {
            throw new NotImplementedException();
        }

        public override void CPUWrite(byte d, int address)
        {
            throw new NotImplementedException();
        }

        public override byte PPURead(int address)
        {
            throw new NotImplementedException();
        }

        public override void PPUWrite(byte d, int address)
        {
            throw new NotImplementedException();
        }
    }
}

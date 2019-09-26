using DovotosTool.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovotosTool
{

    public abstract class Mapper
    {
        protected byte[] PRGRom;
        protected byte[] CHRRom;
        protected byte[] PRGRam;
        protected byte[] CHRRam;
        protected byte[] CPURam = new byte[0x800];

        protected bool chrRam;
        protected int curPRGBank = 0;
        protected int curCHRBank = 0;

        protected int PRGBankSize = 8192;

        public static Dictionary<int, Mapper> Mappers;
        
        public abstract byte CPUReadExt(int address);
        public abstract void CPUWriteExt(byte d, int address);
        public abstract byte PPUReadExt(int address);
        public abstract void PPUWriteExt(byte d, int address);


        public byte CPURead(int address)
        {
            if (address >= 0x8000)
            {
                return CPUReadExt(address);
            }
            else if (address >= 0x6000)
            {
                address &= 0x3FFF;
                return PRGRam[address];
            }else if (address < 0x800)
            {
                return CPURam[address & 0x7FF];
            }

            return 0xFF;
        }

        public void CPUWrite(byte d, int address)
        {
            if (address >= 0x8000)
            {
                CPUWriteExt(d, address);
            }
            else if (address >= 0x6000)
            {
                address &= 0x3FFF;
                PRGRam[address] = d;
            }
            else if (address < 0x800)
            {
                CPURam[address & 0x7FF] = d;
            }
        }

        public byte PPURead(int address)
        {
            return PPUReadExt(address);
        }

        public void PPUWrite(byte d, int address)
        {
            //todo:mirroring
            PPUWriteExt(d, address);
        }
        static Mapper()
        {
            Mappers = new Dictionary<int, Mapper>();

            Mappers.Add(0, new NROM());
            Mappers.Add(1, new MMC1());

        }
    }
}

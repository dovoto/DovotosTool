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

        protected bool chrRam;
        protected int curPRGBank = 0;
        protected int curCHRBank = 0;

        protected int PRGBankSize = 8192;

        public abstract byte CPURead(int address);
        public abstract void CPUWrite(byte d, int address);
        public abstract byte PPURead(int address);
        public abstract void PPUWrite(byte d, int address);
    }
}

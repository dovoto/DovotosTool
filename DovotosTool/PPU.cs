
using System.Drawing;


namespace DovotosTool
{
    //ntsc nes ppu
    public class PPU
    {
        public static byte reg2000_control;
        public static byte reg2001_mask;
        public static byte reg2002_status;
        public static byte reg2003_oamAddress;
        public static byte reg2004_oamData;
        public static int reg2006_vramAddress;
        public static byte reg2007_vramData;

        public static byte sx;
        public static byte sy;

        public static byte[] PPU_RAM = new byte[0x800];

        public static Color[] FrameBuffer = new Color[256 * 256];

        public static byte[] OAM = new byte[64 * 4];

        public static byte[] OAM_shadow = new byte[8 * 4];

        public static byte[] Palettes = new byte[8 * 4];

        public static int Scanline;

        public static bool InVblank;

        public const int Scanlines = 262;
        public const int CyclesPerLine = 114;

        public static byte syLatch;

        private static bool scrollLatch;
        private static bool addressLatch;

        public static void Reset()
        {
            scrollLatch = false;
            addressLatch = false;
            Scanline = 0;
        }

        public static void RenderLine()
        {
            reg2002_status &= (byte)((~(1 << 5)) & 0xFF);

            if (Scanline == 261) //pre render
            {
                reg2002_status &= (byte)((~1 << 7) & 0xFF);
                reg2002_status &= (byte)((~1 << 6) & 0xFF);
                reg2002_status &= (byte)((~1 << 5) & 0xFF);
                syLatch = sy;

                FetchSprites();
            }
            else if (Scanline >= 0 && Scanline < 240)
            {


                FetchSprites();

                for (int x = 0; x < 256; x++)
                {
                    int tileIndex = (((x + sx) & 0xFF) / 8) + (((Scanline + sy) & 0xFF) / 8) * 32;

                    byte charIndex = GameState.Cart.PPURead(tileIndex + 0x2000);


                }
            }
            else if (Scanline == 241)
            {
                reg2002_status |= (1 << 7);
            }

            Scanline++;
        }

        private static void FetchSprites()
        {
            int count = 0;
            int size = (reg2000_control & (1 << 5)) == (1 << 5) ? 16 : 8;
            int line = (Scanline + 1) % 262;

            for (int i = 0; i < 64; i++)
            {
                int y = OAM[i * 4];


                if (y > line && y <= line + size)
                {
                    if (count < 8)
                    {
                        OAM_shadow[count * 4] = OAM[i * 4];
                        OAM_shadow[count * 4 + 1] = OAM[i * 4 + 1];
                        OAM_shadow[count * 4 + 2] = OAM[i * 4 + 2];
                        OAM_shadow[count * 4 + 3] = OAM[i * 4 + 3];

                        count++;
                    }
                    else
                    {
                        reg2002_status |= (1 << 5);
                    }
                }
            }


            for (; count < 8; count++)
            {
                OAM_shadow[count * 4] = 0xFF;
                OAM_shadow[count * 4 + 1] = 0xFF;
                OAM_shadow[count * 4 + 2] = 0xFF;
                OAM_shadow[count * 4 + 3] = 0xFF;
            }


        }
        public static byte Read(int address)
        {
            switch (address & 0x7)
            {
                case 0:
                    return reg2000_control;

                case 1:
                    return reg2001_mask;

                case 2:
                    scrollLatch = false;
                    addressLatch = false;
                    reg2002_status &= (byte)((~1 << 7) & 0xFF);

                    return reg2002_status;

                case 3:
                    return reg2003_oamAddress;

                case 4:
                    return reg2004_oamData;

                case 5:
                    return 0xFF;
                case 6:

                    return 0xFF;
                case 7:
                    return GameState.Cart.PPURead(reg2006_vramAddress++);
                default: return 0xFF;

            }
        }

        public static void Write(int address, byte d)
        {
            switch (address & 0x7)
            {
                case 0:
                    reg2000_control = d;
                    break;
                case 1:
                    reg2001_mask = d;
                    break;
                case 2:

                    break;
                case 3:
                    reg2003_oamAddress = d;
                    break;
                case 4:
                    reg2004_oamData = d;
                    break;
                case 5:
                    if (scrollLatch) sy = d;
                    else sx = d;

                    scrollLatch = !scrollLatch;

                    break;
                case 6:
                    if (!addressLatch)
                    {
                        reg2006_vramAddress &= 0xff00;
                        reg2006_vramAddress |= d;
                    }
                    else
                    {
                        reg2006_vramAddress &= 0x00ff;
                        reg2006_vramAddress |= (d << 8);
                    }

                    addressLatch = !addressLatch;
                    break;
                case 7:
                    GameState.Cart.PPUWrite(d, reg2006_vramAddress++);
                    break;
                default: break;

            }
        }


    }

}
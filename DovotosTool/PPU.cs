
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

        public static bool InVblank
        {
            get { return (reg2002_status & (1 << 7)) == (1 << 7); }
        }
        public static bool VblankNMIEnabled
        {
            get { return (reg2000_control & (1 << 7)) == (1 << 7); }
        }
        public delegate void VBlankHandler();

        public static VBlankHandler VBlank;

        public const int Scanlines = 262;
        public const int CyclesPerLine = 114;
        public const int CyclesPerFrame = Scanlines * CyclesPerLine;

        public static byte syLatch;

        private static bool scrollLatch;
        private static bool addressLatch;

        private static Bitmap videoOutput;
        private static Bitmap backBuffer;

        public static Bitmap VideoOutput
        {
            get
            {
                if (videoOutput == null)
                    videoOutput = new Bitmap(256, 240);

                return videoOutput;

            }
        }

        public PPU()
        {
            videoOutput = new Bitmap(256, 240);
            backBuffer = new Bitmap(256, 240);
        }
        public static void Reset()
        {
            scrollLatch = false;
            addressLatch = false;
            Scanline = 0;
            
        }

        public static void RenderLine()
        {
            if (backBuffer == null) backBuffer = new Bitmap(256, 240);

            reg2002_status &= (byte)((~(1 << 5)) & 0xFF);

            Scanline++;

            if (Scanline == 262) Scanline = 0;

            if (Scanline == 261) //pre render
            {
                reg2002_status &= (byte)((~1 << 7) & 0xFF);
                reg2002_status &= (byte)((~1 << 6) & 0xFF);
                reg2002_status &= (byte)((~1 << 5) & 0xFF);
                syLatch = sy;

                Scanline = 0;

                FetchSprites();

            }
            else if (Scanline >= 0 && Scanline < 240)
            {


                FetchSprites();
                // There is a lot of room to optimize this line render...but we will let the compiler do its best for                   
                // the moment
                for (int x = 0; x < 256; x++)
                {
                    int tileIndex = (((x + sx) & 0xFF) / 8) + (((Scanline + sy) & 0xFF) / 8) * 32;

                    int charIndex = GameState.Cart.PPURead(tileIndex + 0x2000) * 2;
   
                    int attributeIndex = (((x + sx) & 0xFF) / 32) + (((Scanline + sy) & 0xFF) / 32) * 8;

                    int attributeBits = GameState.Cart.PPURead(attributeIndex + 0x2000 + 960);

                    int characterBits0 = GameState.Cart.PPURead(charIndex + ((Scanline + sy)&0x7) * 2);
                    int characterBits1 = GameState.Cart.PPURead(charIndex + ((Scanline + sy)&0x7) * 2 + 1);

                    int colorIndex =   characterBits0  >> (1 - ((x + sx)&0x7)) & 1 |
                                       characterBits1  >> (1 - ((x + sx)&0x7) - 1) & 2;

                    // attribute bits are 4 16 x 16 tiles
                    // 00 00 00 00
                    // 4  3  2  1
                    //
                    //  1   2
                    //  3   4
                    //
                    //

                    int palIndex = (attributeBits >> ((((((x + sx)/16) & 0x1)) + (((((Scanline + sy)/ 16) & 0x1)) * 2)) & 0x3)*2) &0x3;


                    Color c = GameState.Palette[PPU.Palettes[palIndex * 4 + colorIndex]];

                    backBuffer.SetPixel(x, Scanline, c);

                   
                }
            }
            else if (Scanline == 241)
            {
                reg2002_status |= (1 << 7);

                Bitmap temp = backBuffer;
                backBuffer = videoOutput;
                videoOutput = backBuffer;

                if (VBlank != null) VBlank();

                
            }

            
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
                    byte temp = reg2002_status;
                    reg2002_status &= (byte)(~(1 << 7) & 0xFF);

                    return temp;

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
                    if (addressLatch)
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

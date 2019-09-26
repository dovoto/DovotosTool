public class PPU
{
    public static byte reg2000_control;
    public static byte reg2001_mask;
    public static byte reg2002_status;
    public static byte reg2003_oamAddress;
    public static byte reg2004_oamData;
    public static byte reg2005_scroll;
    public static byte reg2006_vramAddress;
    public static byte reg2007_vramData;
    
    public static byte[] PPU_RAM = new byte[0x800];
    
    public static Color[] FrameBuffer = new Color[256*256];
    
    public static byte[] OAM = new byte[64*4];
    
    public static byte Read(int address)
    {
    }
    
    public static Write(int address, byte d)
    {
        case(address & 0x7)
        {
            0:
                reg2000_control = d;
                break;
            1:
                reg2001_mask = d;
                break;
            2:
                reg2002_control = d;
                break;
            3:
                reg2003_oamAddress = d;
                break;
            4:
                reg2004_oamData = d;
                break;
            5:
                reg2005_scroll = d;
                break;
            6:
                reg2007_vramData = d;
                break;
            7:
            default: break;
        }
    }
    
    
}

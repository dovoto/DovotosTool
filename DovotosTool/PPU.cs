public class PPU
{
    private static int reg2000_control;
    private static int reg2001_mask;
    private static int reg2002_status;
    private static int reg2003_oamAddress;
    private static int reg2004_oamData;
    private static int reg2005_scroll;
    private static int reg2006_vramAddress;
    private static int reg2007_vramData;
    
    private static byte[] PPU_RAM = new byte[0x800];
    
    public static Color[] FrameBuffer = new Color[256*256];
    
    public static byte[] OAM = new byte[40*4];
    
    public static byte Read(int address)
    {
    }
    
    public static Write(int address, int byte)
    {
    }
    
    
}

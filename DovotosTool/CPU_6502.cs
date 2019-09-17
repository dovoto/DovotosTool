public class CPU_6502
{
  private int X = 0;
  private int Y = 0;
  private int A = 0;
  
  private int SP = 0;
  private int F = 0;
  
  public CPU_6502()
  {
    
    
  }
  
  public static const string[] OpcodeNames = {
  //0x00
    "BRK",
    "ORA ({0},{1})",
    "invalid",
    "invalid",
    "ivalid",
    "ORA {0}",
    "ASL {0}",
    "invalid",
    "PHP",
    "ORA #{0}",
    "ASL A",
    "invalid",
    "invalid", 
    "ORA ${0}",
    "ASL ${0}",
    "invalid",
    
   //0x10
    "BRK",
    "ORA ({0},{1})",
    "invalid",
    "invalid", 
    "ivalid",
    "ORA {0}",
    "ASL {0}",
    "invalid",
    "PHP",
    "ORA #{0}",
    "ASL A",
    "invalid",
    "invalid", 
    "ORA ${0}",
    "ASL ${0}",
    "invalid",
      
  
  
  }
    
}

using DovotosTool;
using System;

public class CPU_6502
{
    public sbyte X = 0;
    public sbyte Y = 0;
    public sbyte A = 0;

    public byte SP = 0;
    public byte F = 0;
    public int PC = 0;

    public bool Z
    {
        get { return (F & 2) != 0; }
        set { F = value ? (F | 2) : (F & ~2); }
    }
    public bool C
    {
        get { return (F & 1) != 0; }
        set { F = value ? (F | 1) : (F & ~1); }
    }
    public bool B
    {
        get { return (F & 16) != 0; }
        set { F = value ? (F | 16) : (F & ~16); }
    }
    public bool I
    {
        get { return (F & 4) != 0; }
        set { F = value ? (F | 4) : (F & ~4); }
    }
    public bool D
    {
        get { return (F & 8) != 0; }
        set { F = value ? (F | 8) : (F & ~8); }
    }
    public bool V
    {
        get { return (F & 64) != 0; }
        set { F = value ? (F | 64) : (F & ~64); }
    }
    public bool N
    {
        get { return (F & 128) != 0; }
        set { F = value ? (F | 128) : (F & ~128); }
    }
    public enum AddressingMode
    {
        Immediate,
        ZeroPage,
        Absolute,
        AbsoluteX,
        AbsoluteY,
        Indirect,
        IndirectX,
        IndirectY,
        ZeroPageX,
        ZeroPageY,
        Accumulator,
        Implicit

    }

   public struct Opcode
    {
        public string name;
        public AddressingMode addressMode;
        public int cycles;
        public bool pageCrossPenalty;
        public delegate int Execute(Opcode op);
        public Execute execute;

        public Opcode(string name, AddressingMode addressingMode, int cycles, bool pageCrossPenalty, Execute execute)
        {
            this.name = name;
            this.addressMode = addressingMode;
            this.cycles = cycles;
            this.pageCrossPenalty = pageCrossPenalty;
            this.execute = execute;
           
        }

        public byte Read(int address)
        {
            return GameState.Cart.Read(address);
        }
        public void Write(byte d)
        {
            GameState.Cart.Write(d);
        }
        public void Push(byte d)
        {
            Write(SP + 0x100, d);
            SP++;
            SP &= 0xFF;
        }
        public byte Pop()
        {
            SP--;
            SP &= 0xFF;
            return Read(SP + 0x100);
        }
        public int Size()
        {
            switch (addressMode)
            {
                case AddressingMode.Implicit:
                    return 1;
                case AddressingMode.AbsoluteX:
                    return 3;
                case AddressingMode.Absolute:
                    return 3;
                case AddressingMode.AbsoluteY:
                    return 3;
                case AddressingMode.Accumulator:
                    return 1;
                case AddressingMode.Immediate:
                    return 2;
                case AddressingMode.Indirect:
                    return 3;
                case AddressingMode.IndirectX:
                    return 2;
                case AddressingMode.IndirectY:
                    return 2;
                case AddressingMode.ZeroPage:
                    return 2;
                case AddressingMode.ZeroPageX:
                    return 2;
                case AddressingMode.ZeroPageY:
                    return 2;
                default:
                    return 1;
            }
        }

        public static int Operand(AddressingMode addressMode)
        {
            
            switch (addressMode)
            {
                //no operand
                case AddressingMode.Implicit:
                case AddressingMode.Indirect:
                    return 0;

                case AddressingMode.AbsoluteX:
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8) + GameState.CPU.X);
                case AddressingMode.Absolute:
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8));
                case AddressingMode.AbsoluteY:
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8) + GameState.CPU.Y);
                case AddressingMode.Accumulator:
                    return GameState.CPU.A;
                case AddressingMode.Immediate:
                    return GameState.Cart.CPURead(GameState.CPU.PC + 1);
               
                case AddressingMode.IndirectX:
                    int zpAddressX = (GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.X) & 0xFF;
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(zpAddressX) | (GameState.Cart.CPURead((zpAddressX + 1) & 0xFF) << 8));

                case AddressingMode.IndirectY:
                    int zpAddressY = (GameState.Cart.CPURead(GameState.CPU.PC + 1) & 0xFF) + GameState.CPU.Y;
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(zpAddressY) | (GameState.Cart.CPURead((zpAddressY + 1) & 0xFF) << 8));

                case AddressingMode.ZeroPage:
                    return GameState.Cart.CPURead(GameState.CPU.PC & 0xFF);
                case AddressingMode.ZeroPageX:
                    return GameState.Cart.CPURead((GameState.CPU.PC + GameState.CPU.X) & 0xFF );
                case AddressingMode.ZeroPageY:
                    return GameState.Cart.CPURead((GameState.CPU.PC + GameState.CPU.Y) & 0xFF);
                default:
                    return 0;
            }
           
        }


        public static void Store(AddressingMode addressMode, byte d)
        {

            switch (addressMode)
            {
                //no operand
                case AddressingMode.Implicit:
                case AddressingMode.Indirect:
                    return;

                case AddressingMode.AbsoluteX:
                    GameState.Cart.CPUWrite(d, (GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8) + GameState.CPU.X));
                    return;
                case AddressingMode.Absolute:
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8));
                    return;
                case AddressingMode.AbsoluteY:
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8) + GameState.CPU.Y);
                    return;
                case AddressingMode.Accumulator:
                    GameState.CPU.A = d;
                    return;
                case AddressingMode.Immediate:
                    GameState.Cart.CPUWrite(d, GameState.CPU.PC + 1);
                    return;

                case AddressingMode.IndirectX:
                    int zpAddressX = (GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.X) & 0xFF;
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(zpAddressX) | (GameState.Cart.CPURead((zpAddressX + 1) & 0xFF) << 8));
                    return;
                case AddressingMode.IndirectY:
                    int zpAddressY = (GameState.Cart.CPURead(GameState.CPU.PC + 1) & 0xFF) + GameState.CPU.Y;
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(zpAddressY) | (GameState.Cart.CPURead((zpAddressY + 1) & 0xFF) << 8));
                    return;
                case AddressingMode.ZeroPage:
                    GameState.Cart.CPUWrite(d, GameState.CPU.PC & 0xFF);
                    return;
                case AddressingMode.ZeroPageX:
                    GameState.Cart.CPUWrite(d, (GameState.CPU.PC + GameState.CPU.X) & 0xFF);
                    return;
                case AddressingMode.ZeroPageY:
                    GameState.Cart.CPUWrite(d, (GameState.CPU.PC + GameState.CPU.Y) & 0xFF);
                    return;
                default:
                    return;
            }

        }
        public string Dissassemble()
        {
            
            
            switch(addressMode)
            {
                case AddressingMode.Implicit:
                    return string.Format(name + "            \t;implicit");
                case AddressingMode.Absolute:
                    return string.Format(name + " ${1:X2}{0:X2}    \t;absolute", GameState.Cart.CPURead(GameState.CPU.PC+1), GameState.Cart.CPURead(GameState.CPU.PC + 2));
                case AddressingMode.AbsoluteX:
                    return string.Format(name + " ${1:X2}{0:X2}, X \t;absolute x", GameState.Cart.CPURead(GameState.CPU.PC + 1), GameState.Cart.CPURead(GameState.CPU.PC + 2));
                case AddressingMode.AbsoluteY:
                    return string.Format(name + " ${1:X2}{0:X2}, Y \t;absolute y", GameState.Cart.CPURead(GameState.CPU.PC + 1), GameState.Cart.CPURead(GameState.CPU.PC + 2));
                case AddressingMode.Accumulator:
                    return string.Format(name + " A          \t;accumulator");
                case AddressingMode.Immediate:
                    return string.Format(name + " #{0:X2}       \t;immediate", GameState.Cart.CPURead(GameState.CPU.PC + 1), GameState.Cart.CPURead(GameState.CPU.PC + 2));
                case AddressingMode.Indirect:
                    return string.Format(name + " (${1:X2}{0:X2} ) \t;indirect", GameState.Cart.CPURead(GameState.CPU.PC + 1), GameState.Cart.CPURead(GameState.CPU.PC + 2));
                case AddressingMode.IndirectX:
                    return string.Format(name + " (${0:X2}, X)  \t;indirect x", GameState.Cart.CPURead(GameState.CPU.PC + 1));
                case AddressingMode.IndirectY:
                    return string.Format(name + " (${0:X2}), Y  \t;indirect y", GameState.Cart.CPURead(GameState.CPU.PC + 1));
                case AddressingMode.ZeroPage:
                    return string.Format(name + " ${0:X2}       \t;zero page", GameState.Cart.CPURead(GameState.CPU.PC + 1));
                case AddressingMode.ZeroPageX:
                    return string.Format(name + " ${0:X2}, X    \t;zero page X", GameState.Cart.CPURead(GameState.CPU.PC + 1));
                case AddressingMode.ZeroPageY:
                    return string.Format(name + " ${0:X2}, Y    \t;zero page Y", GameState.Cart.CPURead(GameState.CPU.PC + 1));
                default:
                    return name;
            }
        }

 //Math
        private static void ORA(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A | Operand(op.addressMode));
            
            return op.cycles;
        }
        private static void ADC(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A + Operand(op.addressMode) + (GameState.CPU.C ? 1 : 0));
            
            return op.cycles;
        }
        private static void SBC(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A - Operand(op.addressMode) - (GameState.CPU.C ? 1 : 0));
            
            return op.cycles;
        }
        private static void CMP(Opcode op)
        {
            int temp = (GameState.CPU.A - Operand(op.addressMode));
            
            return op.cycles;
        }
        private static void CPX(Opcode op)
        {
            int temp = (GameState.CPU.X - Operand(op.addressMode));
            
            return op.cycles;
        }
        private static void CPY(Opcode op)
        {
            int temp = (GameState.CPU.Y - Operand(op.addressMode));
            
            return op.cycles;
        }
        private static void INC(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A + 1);
            
            return op.cycles;
        }
        private static void INX(Opcode op)
        {
            GameState.CPU.X = (byte)(GameState.CPU.X + 1);
            
            return op.cycles;
        }
        private static void INY(Opcode op)
        {
            GameState.CPU.Y = (byte)(GameState.CPU.Y + 1);
            
            return op.cycles;
        }
        private static void DEC(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A - 1);
            
            return op.cycles;
        }
        private static void DEX(Opcode op)
        {
            GameState.CPU.X = (byte)(GameState.CPU.X - 1);
            
            return op.cycles;
        }
        private static void DEY(Opcode op)
        {
            GameState.CPU.Y = (byte)(GameState.CPU.Y - 1);
            
            return op.cycles;
        }
       
  //Bitwise Operations
        private static void BIT(Opcode op)
        {
            int result = Operand(op.addressMode);

            GameState.CPU.V = (result & (1 << 6)) != 0;
            GameState.CPU.N = (result & (1 << 7)) != 0;
            GameState.CPU.Z = (result & GameState.CPU.A) != 0;

            
            return op.cycles;
        }
        private static void AND(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A & Operand(op.addressMode));
            
            
            return op.cycles;
        }
        private static void EOR(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A ^ Operand(op.addressMode));
            
            
            return op.cycles;
        }
        private static void ASL(Opcode op)
        {
            GameState.CPU.A = (byte)(Operand(op.addressMode)<<1);
            
            return op.cycles;
        }
        private static void LSR(Opcode op)
        {
            GameState.CPU.A = (byte)(Operand(op.addressMode) >> 1);
            
            return op.cycles;
        }
        private static void ROL(Opcode op)
        {
            int b = Operand(op.addressMode);

            GameState.CPU.A = (byte)((b << 1) | (b >> 7));
        }
        private static void ROR(Opcode op)
        {
            int b = Operand(op.addressMode);

            GameState.CPU.A = (byte)((b >> 1) | (b << 7));
            
            return op.cycles;
        }
       
  //  JMP - Jump to Location
  //  JSR - Jump to Location Save Return Address
  //  RTI - Return from Interrupt
  //  RTS - Return from Subroutine    
        private static void JMP(Opcode op)
        {
            int addr = 0;
            
            addr = GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8);
            
            if(op.AddressMode == AddressMode.indirect)
            {
                addr = GameState.Cart.CPURead(addr) | (GameState.Cart.CPURead(addr + 1) << 8);    
            }
            
            GameState.CPU.PC = addr;
            
            return op.cycles;
        }  
        private static void JSR(Opcode op)
        {    
            GameState.CPU.Push((GameState.CPU.PC + 2) & 0xFF);
            GameState.CPU.Push((GameState.CPU.PC + 3) & 0xFF);
            GameState.CPU.PC = GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8);
        
            return op.cycles;
        }  
        private static void RTI(Opcode op)
        {    
            GameState.CPU.PC = GameState.CPU.Pop() | (GameState.CPU.Pop()<<8);
            GameState.CPU.F = GameState.CPU.Pop();
            
            return op.cycles;
        }
        private static void RTS(Opcode op)
        {    
            GameState.CPU.PC = (GameState.CPU.Pop() | (GameState.CPU.Pop()<<8)) + 1;
            
            return op.cycles;
        }
  
  //  PHA - Push A on Stack
  //  PHP - Push Processor Status on Stack
  //  PLA - Pull A from Stack
  //  PLP - Pull Processor Status from Stack     
        private static void PHA(Opcode op)
        {
           GameState.CPU.Push(GameState.CPU.A);
            
            return op.cycles;
        }  
        private static void PHP(Opcode op)
        {
           GameState.CPU.Push(GameState.CPU.F)
               
            return op.cycles;
        }
        private static void PLA(Opcode op)
        {
           GameState.CPU.A = GameState.CPU.POP();
            
            return op.cycles;
        }
        private static void PLP(Opcode op)
        {
            GameState.CPU.F = GameState.CPU.POP();
            
            return op.cycles;
        }
  //  BCC - Branch on Carry Clear
  //  BCS - Branch on Carry Set
  //  BEQ - Branch on Result Zero
  //  BMI - Branch on Result Minus
  //  BNE - Branch on Result not Zero
  //  BPL - Branch on Result Plus
  //  BVC - Branch on Overflow Clear
  //  BVS - Branch on Overflow Set
        private static void BCC(Opcode op)
        {
            if(!GameState.CPU.C)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        }        
        private static void BCS(Opcode op)
        {
            if(GameState.CPU.C)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BEQ(Opcode op)
        {
            if(GameState.CPU.Z)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BMI(Opcode op)
        {
            if(GameState.CPU.N)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BNE(Opcode op)
        {
            if(!GameState.CPU.Z)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BPL(Opcode op)
        {
            if(!GameState.CPU.N)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BVC(Opcode op)
        {
            if(!GameState.CPU.V)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
        private static void BVS(Opcode op)
        {
            if(!GameState.CPU.V)
                GameState.CPU.PC += (sbyte)Operand(op.addressMode);
            
            return op.cycles;
        } 
       
  //Storage      
        private static void TXA(Opcode op)
        {
            GameState.CPU.A = GameState.CPU.X;
            
            return op.cycles;
        }
        private static void TAX(Opcode op)
        {
            GameState.CPU.X = GameState.CPU.A;
            
            return op.cycles;
        }
        private static void TYA(Opcode op)
        {
            GameState.CPU.A = GameState.CPU.Y;
            
            return op.cycles;
        }
        private static void TAY(Opcode op)
        {
            GameState.CPU.Y = GameState.CPU.A;
            
            return op.cycles;
        }
        private static void TXS(Opcode op)
        {
            GameState.CPU.X = GameState.CPU.SP;
            
            return op.cycles;
        }
        private static void TSX(Opcode op)
        {
            GameState.CPU.SP = GameState.CPU.X;
            
            return op.cycles;
        }
        private static void LDA(Opcode op)
        {
            GameState.CPU.A = (byte)(Operand(op.addressMode);
                                     
            return op.cycles;
        }
        private static void LDX(Opcode op)
        {
            GameState.CPU.X = (byte)(Operand(op.addressMode);
                                     
            return op.cycles;
        }
        private static void LDY(Opcode op)
        {
            GameState.CPU.Y = (byte)(Operand(op.addressMode);
                                     
            return op.cycles;
        }
        private static void STA(Opcode op)
        {
            Store(op.addressMode, GameState.CPU.A);
            
            return op.cycles;
        }
        private static void STX(Opcode op)
        {
            Store(op.addressMode, GameState.CPU.X);
            
            return op.cycles;
        }
        private static void STY(Opcode op)
        {
            Store(op.addressMode, GameState.CPU.Y);
            
            return op.cycles;
        }
        private static void Invalid(Opcode op)
        {
            return 4;
            //do nothing
        }

        public static Opcode[] Opcodes = {
          //0x00
            new Opcode("BRK",AddressingMode.Immediate,4,false, ORA ),
            new Opcode("ORA",AddressingMode.IndirectX, 4, false, ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ORA",AddressingMode.ZeroPage, 4, false, ORA),
            new Opcode("ASL",AddressingMode.ZeroPage, 4, false, ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("PHP",AddressingMode.Implicit, 4, false, PHP),
            new Opcode("ORA",AddressingMode.Immediate, 4, false, ORA),
            new Opcode("ASL",AddressingMode.ZeroPage, 4, false, ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ORA",AddressingMode.Absolute, 4, false, ORA),
            new Opcode("ASL",AddressingMode.Accumulator, 4, false, ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x10
            new Opcode("BPL",AddressingMode.Immediate, 4, false, BPL),
            new Opcode("ORA",AddressingMode.IndirectX, 4, false, ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ORA",AddressingMode.ZeroPageX, 4, false, ORA),
            new Opcode("ASL",AddressingMode.ZeroPageX, 4, false, ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CLC",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.C = false; return op.cycles;}),
            new Opcode("ORA",AddressingMode.AbsoluteY, 4, false, ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ORA",AddressingMode.AbsoluteX, 4, false, ORA),
            new Opcode("ASL",AddressingMode.AbsoluteX, 4, false, ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x20
            new Opcode("JSR",AddressingMode.Absolute, 4, false, JSR),
            new Opcode("AND",AddressingMode.IndirectX, 4, false, AND),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("BIT",AddressingMode.ZeroPage, 4, false, BIT),
            new Opcode("AND",AddressingMode.ZeroPage, 4, false, AND),
            new Opcode("ROL",AddressingMode.ZeroPage, 4, false, ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("PLP",AddressingMode.Implicit, 4, false, PLP),
            new Opcode("AND",AddressingMode.Immediate, 4, false, AND),
            new Opcode("ROL",AddressingMode.Accumulator, 4, false, ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("BIT",AddressingMode.Absolute, 4, false, BIT),
            new Opcode("AND",AddressingMode.Absolute, 4, false, AND),
            new Opcode("ROL",AddressingMode.Absolute, 4, false, ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x30
            new Opcode("BMI",AddressingMode.Immediate, 4, false, BMI),
            new Opcode("AND",AddressingMode.IndirectY, 4, false, AND),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("AND",AddressingMode.ZeroPageX, 4, false, AND),
            new Opcode("ROL",AddressingMode.ZeroPageX, 4, false, ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("SEC",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.C = true;  return op.cycles;}),
            new Opcode("AND",AddressingMode.AbsoluteY, 4, false, AND),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("AND",AddressingMode.AbsoluteX, 4, false, AND),
            new Opcode("ROL",AddressingMode.AbsoluteX, 4, false, ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x40
            new Opcode("RTI",AddressingMode.Implicit, 4, false, RTI),
            new Opcode("EOR",AddressingMode.IndirectX, 4, false, EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("EOR",AddressingMode.ZeroPage, 4, false, EOR),
            new Opcode("LSR",AddressingMode.ZeroPage, 4, false, LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("PHA",AddressingMode.Implicit, 4, false, PHA),
            new Opcode("EOR",AddressingMode.Immediate, 4, false, EOR),
            new Opcode("LSR",AddressingMode.Accumulator, 4, false, LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("JMP",AddressingMode.Absolute, 4, false, JMP),
            new Opcode("EOR",AddressingMode.Absolute, 4, false, EOR),
            new Opcode("LSR",AddressingMode.Absolute, 4, false, LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x50
            new Opcode("BVC",AddressingMode.Immediate, 4, false, BVC),
            new Opcode("EOR",AddressingMode.IndirectY, 4, false, EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("EOR",AddressingMode.ZeroPageX, 4, false, EOR),
            new Opcode("LSR",AddressingMode.ZeroPageX, 4, false, LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CLI",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.I = false;  return op.cycles;}),
            new Opcode("EOR",AddressingMode.AbsoluteY, 4, false, EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("EOR",AddressingMode.AbsoluteX, 4, false, EOR),
            new Opcode("LSR",AddressingMode.AbsoluteX, 4, false, LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x60
            new Opcode("RTS",AddressingMode.Implicit, 4, false, RTS),
            new Opcode("ADC",AddressingMode.IndirectX, 4, false, ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ADC",AddressingMode.ZeroPage, 4, false, ADC),
            new Opcode("ROR",AddressingMode.ZeroPage, 4, false, ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("PLA",AddressingMode.Implicit, 4, false, PLA),
            new Opcode("ADC",AddressingMode.Immediate, 4, false, ADC),
            new Opcode("ROR",AddressingMode.Accumulator, 4, false, ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("JMP",AddressingMode.Indirect, 4, false, JMP),
            new Opcode("ADC",AddressingMode.Absolute, 4, false, ADC),
            new Opcode("ROR",AddressingMode.Absolute, 4, false, ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x70
            new Opcode("BVS",AddressingMode.Immediate, 4, false, BVS),
            new Opcode("ADC",AddressingMode.IndirectY, 4, false, ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ADC",AddressingMode.ZeroPageX, 4, false, ADC),
            new Opcode("ROR",AddressingMode.ZeroPageX, 4, false, ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("SEI",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.I = true;  return op.cycles;}),
            new Opcode("ADC",AddressingMode.AbsoluteY, 4, false, ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("ADC",AddressingMode.AbsoluteX, 4, false, ADC),
            new Opcode("ROR",AddressingMode.AbsoluteX, 4, false, ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x80
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("STA",AddressingMode.IndirectX, 4, false, STA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("STY",AddressingMode.ZeroPage, 4, false, STY),
            new Opcode("STA",AddressingMode.ZeroPage, 4, false, STA),
            new Opcode("STX",AddressingMode.ZeroPage, 4, false, STX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("DEY",AddressingMode.Implicit, 4, false, DEY),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("TXA",AddressingMode.Implicit, 4, false, TXA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("STY",AddressingMode.Absolute, 4, false, STY),
            new Opcode("STA",AddressingMode.Absolute, 4, false, STA),
            new Opcode("STX",AddressingMode.Absolute, 4, false, STX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0x90
            new Opcode("BCC",AddressingMode.Immediate, 4, false, BCC),
            new Opcode("STA",AddressingMode.IndirectY, 4, false, STA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("STY",AddressingMode.ZeroPageX, 4, false, STY),
            new Opcode("STA",AddressingMode.ZeroPageX, 4, false, STA),
            new Opcode("STX",AddressingMode.ZeroPageY, 4, false, STX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("TYA",AddressingMode.Implicit, 4, false, TYA),
            new Opcode("STA",AddressingMode.AbsoluteY, 4, false, STA),
            new Opcode("TXS",AddressingMode.Implicit, 4, false, TXS),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("STA",AddressingMode.AbsoluteX, 4, false, STA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0xA0
            new Opcode("LDY",AddressingMode.Immediate, 4, false, LDY),
            new Opcode("LDA",AddressingMode.IndirectX, 4, false, LDA),
            new Opcode("LDX",AddressingMode.Immediate, 4, false, LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("LDY",AddressingMode.ZeroPage, 4, false, LDY),
            new Opcode("LDA",AddressingMode.ZeroPage, 4, false, LDA),
            new Opcode("LDX",AddressingMode.ZeroPage, 4, false, LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("TAY",AddressingMode.Implicit, 4, false, TAY),
            new Opcode("LDA",AddressingMode.Immediate, 4, false, LDA),
            new Opcode("TAX",AddressingMode.Implicit, 4, false, TAX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("LDY",AddressingMode.Absolute, 4, false, LDY),
            new Opcode("LDA",AddressingMode.Absolute, 4, false, LDA),
            new Opcode("LDX",AddressingMode.Absolute, 4, false, LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0xB0
            new Opcode("BCS",AddressingMode.Immediate, 4, false, BCS),
            new Opcode("LDA",AddressingMode.IndirectY, 4, false, LDA),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("LDY",AddressingMode.ZeroPageX, 4, false, LDY),
            new Opcode("LDA",AddressingMode.ZeroPageX, 4, false, LDA),
            new Opcode("LDX",AddressingMode.ZeroPageY, 4, false, LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CLV",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.V = false; return op.cycles; }),
            new Opcode("LDA",AddressingMode.AbsoluteY, 4, false, LDA),
            new Opcode("TSX",AddressingMode.Implicit, 4, false, TSX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("LDY",AddressingMode.AbsoluteX, 4, false, LDY),
            new Opcode("LDA",AddressingMode.AbsoluteX, 4, false, LDA),
            new Opcode("LDX",AddressingMode.AbsoluteY, 4, false, LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0xC0
            new Opcode("CPY",AddressingMode.Immediate, 4, false, CPY),
            new Opcode("CMP",AddressingMode.IndirectX, 4, false, CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CPY",AddressingMode.ZeroPage, 4, false, CPY),
            new Opcode("CMP",AddressingMode.ZeroPage, 4, false, CMP),
            new Opcode("DEC",AddressingMode.ZeroPage, 4, false, DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("INY",AddressingMode.Implicit, 4, false, INY),
            new Opcode("CMP",AddressingMode.Immediate, 4, false, CMP),
            new Opcode("DEX",AddressingMode.Implicit, 4, false, DEX),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CPY",AddressingMode.Absolute, 4, false, CPY),
            new Opcode("CMP",AddressingMode.Absolute, 4, false, CMP),
            new Opcode("DEC",AddressingMode.Absolute, 4, false, DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0xD0
            new Opcode("BNE",AddressingMode.Immediate, 4, false, BNE),
            new Opcode("CMP",AddressingMode.IndirectY, 4, false, CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CMP",AddressingMode.ZeroPageX, 4, false, CMP),
            new Opcode("DEC",AddressingMode.ZeroPageX, 4, false, DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CLD",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.D = false; return op.cycles; }),
            new Opcode("CMP",AddressingMode.AbsoluteY, 4, false, CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CMP",AddressingMode.AbsoluteX, 4, false, CMP),
            new Opcode("DEC",AddressingMode.AbsoluteX, 4, false, DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
          //0xE0
            new Opcode("CPX",AddressingMode.Immediate, 4, false, CPX),
            new Opcode("SBC",AddressingMode.IndirectX, 4, false, SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CPX",AddressingMode.ZeroPage, 4, false, CPX),
            new Opcode("SBC",AddressingMode.ZeroPage, 4, false, SBC),
            new Opcode("INC",AddressingMode.ZeroPage, 4, false, INC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("INX",AddressingMode.Implicit, 4, false, INX),
            new Opcode("SBC",AddressingMode.Immediate, 4, false, SBC),
            new Opcode("NOP",AddressingMode.Implicit, 4, false, delegate(Opcode op){}),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("CPX",AddressingMode.Absolute, 4, false, CPX),
            new Opcode("SBC",AddressingMode.Absolute, 4, false, SBC),
            new Opcode("INC",AddressingMode.Absolute, 4, false, INC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            //0XF0
            new Opcode("BEQ",AddressingMode.Immediate, 4, false, BEQ),
            new Opcode("SBC",AddressingMode.IndirectY, 4, false, SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("SBC",AddressingMode.ZeroPageX, 4, false, SBC),
            new Opcode("INC",AddressingMode.ZeroPageX, 4, false, INC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("SED",AddressingMode.Implicit, 4, false, delegate(Opcode op){GameState.CPU.D = true;  return op.cycles;}),
            new Opcode("SBC",AddressingMode.AbsoluteY, 4, false, SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
            new Opcode("SBC",AddressingMode.AbsoluteX, 4, false, SBC),
            new Opcode("INC",AddressingMode.AbsoluteX, 4, false, INC),
            new Opcode("invalid",AddressingMode.Implicit, 4, false, Invalid),
  };
    }
      public CPU_6502()
      {
          
      }

    public void Reset()
    {
        PC = GameState.Cart.CPURead(0xfffc) | (GameState.Cart.CPURead(0xfffd) << 8);
    }



    
}

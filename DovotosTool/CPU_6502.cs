using DovotosTool;
using System;

public class CPU_6502
{
    public int X = 0;
    public int Y = 0;
    public int A = 0;

    public int SP = 0;
    public int F = 0;
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
        Implicit,
        Relative

    }

    public int Execute()
    {
        Opcode curOp = CPU_6502.Opcode.Opcodes[GameState.Cart.CPURead(PC)];

        int cycles = curOp.execute(curOp);

       // PC += curOp.Size();

        return cycles;
    }
    public void Push(byte d)
    {
        Write(d, SP + 0x100);
        SP--;
        SP &= 0xFF;
    }
    public byte Pop()
    {
        SP++;
        SP &= 0xFF;
        return Read(SP + 0x100);
    }
    public byte Read(int address)
    {
        return GameState.Cart.CPURead(address);
    }
    public void Write(byte d, int address)
    {
        GameState.Cart.CPUWrite(d, address);
    }
    public struct Opcode
    {
        public string name;
        public AddressingMode addressMode;
        public int cycles;
        public delegate int Execute(Opcode op);
        public Execute execute;

        public Opcode(string name, AddressingMode addressingMode, int cycles, Execute execute)
        {
            this.name = name;
            this.addressMode = addressingMode;
            this.cycles = cycles;
            this.execute = execute;

        }



        public int Size()
        {
            switch (addressMode)
            {
                case AddressingMode.Implicit:
                    return 1;
                case AddressingMode.Relative:
                    return 2;
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
                case AddressingMode.Relative:
                    return GameState.Cart.CPURead(GameState.CPU.PC + 1);
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
                    return GameState.Cart.CPURead(GameState.Cart.CPURead(GameState.CPU.PC + 1));
                case AddressingMode.ZeroPageX:
                    return GameState.Cart.CPURead((GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.X) & 0xFF);
                case AddressingMode.ZeroPageY:
                    return GameState.Cart.CPURead((GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.Y) & 0xFF);
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
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(GameState.CPU.PC + 1));
                    return;

                case AddressingMode.IndirectX:
                    int zpAddressX = (GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.X) & 0xFF;
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(zpAddressX) | (GameState.Cart.CPURead((zpAddressX + 1) & 0xFF) << 8));
                    return;
                case AddressingMode.IndirectY:
                    int zpAddressY = (GameState.Cart.CPURead(GameState.CPU.PC + 1 & 0xFF) + GameState.CPU.Y);
                    GameState.Cart.CPUWrite(d, GameState.Cart.CPURead(zpAddressY) | (GameState.Cart.CPURead((zpAddressY + 1) & 0xFF) << 8));
                    return;
                case AddressingMode.ZeroPage:
                    GameState.Cart.CPUWrite(d, (GameState.Cart.CPURead(GameState.CPU.PC + 1)));
                    return;
                case AddressingMode.ZeroPageX:
                    GameState.Cart.CPUWrite(d, (GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.Y) & 0xFF);
                    return;
                case AddressingMode.ZeroPageY:
                    GameState.Cart.CPUWrite(d, (GameState.Cart.CPURead(GameState.CPU.PC + 1) + GameState.CPU.X) & 0xFF);
                    return;
                default:
                    return;
            }

        }
        public string Dissassemble(int index)
        {


            switch (addressMode)
            {
                case AddressingMode.Implicit:
                    return string.Format(name + "            \t;implicit");
                case AddressingMode.Absolute:
                    return string.Format(name + " ${1:X2}{0:X2}    \t;absolute", GameState.Cart.CPURead(index + 1), GameState.Cart.CPURead(index + 2));
                case AddressingMode.AbsoluteX:
                    return string.Format(name + " ${1:X2}{0:X2}, X \t;absolute x", GameState.Cart.CPURead(index + 1), GameState.Cart.CPURead(index + 2));
                case AddressingMode.AbsoluteY:
                    return string.Format(name + " ${1:X2}{0:X2}, Y \t;absolute y", GameState.Cart.CPURead(index + 1), GameState.Cart.CPURead(index + 2));
                case AddressingMode.Accumulator:
                    return string.Format(name + " A          \t;accumulator");
                case AddressingMode.Immediate:
                    return string.Format(name + " #{0:X2}       \t;immediate", GameState.Cart.CPURead(index + 1));
                case AddressingMode.Relative:
                    return string.Format(name + " ${0:X4}     \t;relative", index + (sbyte)GameState.Cart.CPURead(index + 1) + 2);
                case AddressingMode.Indirect:
                    return string.Format(name + " (${1:X2}{0:X2} ) \t;indirect", GameState.Cart.CPURead(index + 1), GameState.Cart.CPURead(index + 2));
                case AddressingMode.IndirectX:
                    return string.Format(name + " (${0:X2}, X)  \t;indirect x", GameState.Cart.CPURead(index + 1));
                case AddressingMode.IndirectY:
                    return string.Format(name + " (${0:X2}), Y  \t;indirect y", GameState.Cart.CPURead(index + 1));
                case AddressingMode.ZeroPage:
                    return string.Format(name + " ${0:X2}       \t;zero page", GameState.Cart.CPURead(index + 1));
                case AddressingMode.ZeroPageX:
                    return string.Format(name + " ${0:X2}, X    \t;zero page X", GameState.Cart.CPURead(index + 1));
                case AddressingMode.ZeroPageY:
                    return string.Format(name + " ${0:X2}, Y    \t;zero page Y", GameState.Cart.CPURead(index + 1));
                default:
                    return name;
            }
        }

        //Math
        private static int ORA(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A | Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);

            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int ADC(Opcode op)
        {
            int o = Operand(op.addressMode);
            int a = GameState.CPU.A;
            int r = (a + o + (GameState.CPU.C ? 1 : 0));
            GameState.CPU.A = (byte)r;

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.C = r >= 256;

            GameState.CPU.V = ((o ^ r) & (a ^ r) & 0x80) == 0x80;

            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int SBC(Opcode op)
        {
            int o = Operand(op.addressMode);
            int a = GameState.CPU.A;
            int r = (a - o - (GameState.CPU.C ? 1 : 0));
            GameState.CPU.A = (byte)r;

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.C = r >= 256;

            GameState.CPU.V = ((o ^ r) & (a ^ r) & 0x80) == 0x80;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int CMP(Opcode op)
        {
            int o = Operand(op.addressMode);
            int a = GameState.CPU.A;
            int r = (a - o - (GameState.CPU.C ? 1 : 0));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.C = r >= 256;

            GameState.CPU.V = ((o ^ r) & (a ^ r) & 0x80) == 0x80;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int CPX(Opcode op)
        {
            int o = Operand(op.addressMode);
            int a = GameState.CPU.X;
            int r = (a - o - (GameState.CPU.C ? 1 : 0));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.C = r >= 256;

            GameState.CPU.V = ((o ^ r) & (a ^ r) & 0x80) == 0x80;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int CPY(Opcode op)
        {
            int o = Operand(op.addressMode);
            int a = GameState.CPU.Y;
            int r = (a - o - (GameState.CPU.C ? 1 : 0));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.C = r >= 256;

            GameState.CPU.V = ((o ^ r) & (a ^ r) & 0x80) == 0x80;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int INC(Opcode op)
        {
            int o = Operand(op.addressMode);
            Store(op.addressMode, (byte)(o + 1));

            GameState.CPU.N = (o & 128) == 128;
            GameState.CPU.Z = (o == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int INX(Opcode op)
        {
            GameState.CPU.X = (byte)(GameState.CPU.X + 1);

            GameState.CPU.N = (GameState.CPU.X & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.X == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int INY(Opcode op)
        {
            GameState.CPU.Y = (byte)(GameState.CPU.Y + 1);

            GameState.CPU.N = (GameState.CPU.Y & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.Y == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int DEC(Opcode op)
        {
            int o = Operand(op.addressMode);
            Store(op.addressMode, (byte)(o - 1));

            GameState.CPU.N = (o & 128) == 128;
            GameState.CPU.Z = (o == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int DEX(Opcode op)
        {
            GameState.CPU.X = (byte)(GameState.CPU.X - 1);

            GameState.CPU.N = (GameState.CPU.X & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.X == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int DEY(Opcode op)
        {
            GameState.CPU.Y = (byte)(GameState.CPU.Y - 1);

            GameState.CPU.N = (GameState.CPU.Y & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.Y == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }

        //Bitwise Operations
        private static int BIT(Opcode op)
        {
            int result = Operand(op.addressMode);

            GameState.CPU.V = (result & (1 << 6)) != 0;
            GameState.CPU.N = (result & (1 << 7)) != 0;
            GameState.CPU.Z = (result & GameState.CPU.A) != 0;

            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int AND(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A & Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int EOR(Opcode op)
        {
            GameState.CPU.A = (byte)(GameState.CPU.A ^ Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int ASL(Opcode op)
        {
            int operand = Operand(op.addressMode) << 1;

            Store(op.addressMode, (byte)operand);

            GameState.CPU.N = (operand & 128) == 128;
            GameState.CPU.Z = (operand == 0);
            GameState.CPU.C = (operand & 256) == 256;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int LSR(Opcode op)
        {
            int operand = Operand(op.addressMode);

            GameState.CPU.N = (operand & 128) == 128;
            GameState.CPU.Z = (operand == 0);
            GameState.CPU.C = (operand & 1) == 1;

            Store(op.addressMode, (byte)(operand >> 1));
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int ROL(Opcode op)
        {
            int o = Operand(op.addressMode);
            int c = GameState.CPU.C ? 1 : 0;
            int r = ((o << 1) | c);

            Store(op.addressMode, (byte)r);

            GameState.CPU.N = (r & 128) == 128;
            GameState.CPU.Z = (r == 0);
            GameState.CPU.C = (o & 128) == 128;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int ROR(Opcode op)
        {
            int o = Operand(op.addressMode);
            int c = GameState.CPU.C ? 1 : 0;
            int r = (o >> 1) | (c << 7);

            Store(op.addressMode, (byte)r);

            GameState.CPU.N = (r & 128) == 128;
            GameState.CPU.Z = (r == 0);
            GameState.CPU.C = (o & 1) == 1;
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }

        //  JMP - Jump to Location
        //  JSR - Jump to Location Save Return Address
        //  RTI - Return from Interrupt
        //  RTS - Return from Subroutine    
        private static int JMP(Opcode op)
        {
            int addr = 0;

            addr = GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8);

            if (op.addressMode == AddressingMode.Indirect)
            {
                addr = GameState.Cart.CPURead(addr) | (GameState.Cart.CPURead(addr + 1) << 8);
            }

            GameState.CPU.PC = addr;

            return op.cycles;
        }
        private static int JSR(Opcode op)
        {
            GameState.CPU.Push((byte)((GameState.CPU.PC + 2) & 0xFF));
            GameState.CPU.Push((byte)(((GameState.CPU.PC + 2) >> 8) & 0xFF));
            
            GameState.CPU.PC = GameState.Cart.CPURead(GameState.CPU.PC + 1) | (GameState.Cart.CPURead(GameState.CPU.PC + 2) << 8);

            return op.cycles;
        }

        private static int RTI(Opcode op)
        {
            GameState.CPU.F = GameState.CPU.Pop();
            GameState.CPU.PC = ((GameState.CPU.Pop() << 8));
            GameState.CPU.PC += GameState.CPU.Pop();
            

            return op.cycles;
        }
        private static int RTS(Opcode op)
        {
            GameState.CPU.PC = ((GameState.CPU.Pop() << 8));
            GameState.CPU.PC += GameState.CPU.Pop() + 1;
            return op.cycles;
        }

        //  PHA - Push A on Stack
        //  PHP - Push Processor Status on Stack
        //  PLA - Pull A from Stack
        //  PLP - Pull Processor Status from Stack     
        private static int PHA(Opcode op)
        {
            GameState.CPU.Push((byte)GameState.CPU.A);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int PHP(Opcode op)
        {
            GameState.CPU.Push((byte)GameState.CPU.F);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int PLA(Opcode op)
        {
            GameState.CPU.A = GameState.CPU.Pop();

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int PLP(Opcode op)
        {
            GameState.CPU.F = GameState.CPU.Pop();
            GameState.CPU.PC += op.Size();
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
        private static int BCC(Opcode op)
        {
            if (!GameState.CPU.C)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BCS(Opcode op)
        {
            if (GameState.CPU.C)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BEQ(Opcode op)
        {
            if (GameState.CPU.Z)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BMI(Opcode op)
        {
            if (GameState.CPU.N)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BNE(Opcode op)
        {
            if (!GameState.CPU.Z)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BPL(Opcode op)
        {
            if (!GameState.CPU.N)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BVC(Opcode op)
        {
            if (!GameState.CPU.V)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int BVS(Opcode op)
        {
            if (!GameState.CPU.V)
            {
                int bp = (GameState.CPU.PC & 0xFF00);
                GameState.CPU.PC += (sbyte)Operand(op.addressMode) + 2; ;
                return op.cycles + 1 + ((bp == (GameState.CPU.PC & 0xFF00)) ? 1 : 0);
            }
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }

        //Storage      
        private static int TAX(Opcode op)
        {
            GameState.CPU.X = GameState.CPU.A;

            GameState.CPU.N = (GameState.CPU.X & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.X == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int TXA(Opcode op)
        {
            GameState.CPU.A = GameState.CPU.X;

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int TAY(Opcode op)
        {
            GameState.CPU.Y = GameState.CPU.A;

            GameState.CPU.N = (GameState.CPU.Y & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.Y== 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int TYA(Opcode op)
        {
            GameState.CPU.A = GameState.CPU.Y;

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int TXS(Opcode op)
        {
            GameState.CPU.SP = GameState.CPU.X;

            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int TSX(Opcode op)
        {
            GameState.CPU.X = GameState.CPU.SP;

            GameState.CPU.N = (GameState.CPU.X & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.X == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int LDA(Opcode op)
        {
            GameState.CPU.A = (byte)(Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.A & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.A == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int LDX(Opcode op)
        {
            GameState.CPU.X = (byte)(Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.X & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.X == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int LDY(Opcode op)
        {
            GameState.CPU.Y = (byte)(Operand(op.addressMode));

            GameState.CPU.N = (GameState.CPU.Y & 128) == 128;
            GameState.CPU.Z = (GameState.CPU.Y == 0);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int STA(Opcode op)
        {
            Store(op.addressMode, (byte)GameState.CPU.A);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int STX(Opcode op)
        {
            Store(op.addressMode, (byte)GameState.CPU.X);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int STY(Opcode op)
        {
            Store(op.addressMode, (byte)GameState.CPU.Y);
            GameState.CPU.PC += op.Size();
            return op.cycles;
        }
        private static int Invalid(Opcode op)
        {
            GameState.CPU.PC += op.Size();
            return 4;
            //do nothing
        }

        public static Opcode[] Opcodes = {
          //0x00
            new Opcode("BRK",AddressingMode.Immediate,7, ORA ),
            new Opcode("ORA",AddressingMode.IndirectX, 6 , ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ORA",AddressingMode.ZeroPage, 3 , ORA),
            new Opcode("ASL",AddressingMode.ZeroPage, 5 , ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("PHP",AddressingMode.Implicit, 3 , PHP),
            new Opcode("ORA",AddressingMode.Immediate, 2 , ORA),
            new Opcode("ASL",AddressingMode.Accumulator, 2 , ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ORA",AddressingMode.Absolute, 4 , ORA),
            new Opcode("ASL",AddressingMode.Absolute, 6 , ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x10
            new Opcode("BPL",AddressingMode.Relative, 2 , BPL),
            new Opcode("ORA",AddressingMode.IndirectY, 5 , ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ORA",AddressingMode.ZeroPageX, 4 , ORA),
            new Opcode("ASL",AddressingMode.ZeroPageX, 6 , ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CLC",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.C = false; GameState.CPU.PC += op.Size(); return op.cycles;}),
            new Opcode("ORA",AddressingMode.AbsoluteY, 4 , ORA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ORA",AddressingMode.AbsoluteX, 4 , ORA),
            new Opcode("ASL",AddressingMode.AbsoluteX, 7 , ASL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x20
            new Opcode("JSR",AddressingMode.Absolute, 6 , JSR),
            new Opcode("AND",AddressingMode.IndirectX, 6 , AND),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("BIT",AddressingMode.ZeroPage, 3 , BIT),
            new Opcode("AND",AddressingMode.ZeroPage, 3 , AND),
            new Opcode("ROL",AddressingMode.ZeroPage, 5 , ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("PLP",AddressingMode.Implicit, 4 , PLP),
            new Opcode("AND",AddressingMode.Immediate, 2 , AND),
            new Opcode("ROL",AddressingMode.Accumulator, 2 , ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("BIT",AddressingMode.Absolute, 4 , BIT),
            new Opcode("AND",AddressingMode.Absolute, 4 , AND),
            new Opcode("ROL",AddressingMode.Absolute, 6 , ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x30
            new Opcode("BMI",AddressingMode.Relative, 2 , BMI),
            new Opcode("AND",AddressingMode.IndirectY, 5 , AND),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("AND",AddressingMode.ZeroPageX, 4 , AND),
            new Opcode("ROL",AddressingMode.ZeroPageX, 6 , ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("SEC",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.C = true;  GameState.CPU.PC += op.Size();return op.cycles;}),
            new Opcode("AND",AddressingMode.AbsoluteY, 4 , AND),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("AND",AddressingMode.AbsoluteX, 4 , AND),
            new Opcode("ROL",AddressingMode.AbsoluteX, 7 , ROL),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x40
            new Opcode("RTI",AddressingMode.Implicit, 6 , RTI),
            new Opcode("EOR",AddressingMode.IndirectX, 6 , EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("EOR",AddressingMode.ZeroPage, 3 , EOR),
            new Opcode("LSR",AddressingMode.ZeroPage, 5 , LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("PHA",AddressingMode.Implicit, 3 , PHA),
            new Opcode("EOR",AddressingMode.Immediate, 2 , EOR),
            new Opcode("LSR",AddressingMode.Accumulator, 2 , LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("JMP",AddressingMode.Absolute, 3 , JMP),
            new Opcode("EOR",AddressingMode.Absolute, 4 , EOR),
            new Opcode("LSR",AddressingMode.Absolute, 6 , LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x50
            new Opcode("BVC",AddressingMode.Relative, 2 , BVC),
            new Opcode("EOR",AddressingMode.IndirectY, 5 , EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("EOR",AddressingMode.ZeroPageX, 4 , EOR),
            new Opcode("LSR",AddressingMode.ZeroPageX, 6 , LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CLI",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.I = false;  GameState.CPU.PC += op.Size();return op.cycles;}),
            new Opcode("EOR",AddressingMode.AbsoluteY, 4 , EOR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("EOR",AddressingMode.AbsoluteX, 4 , EOR),
            new Opcode("LSR",AddressingMode.AbsoluteX, 7 , LSR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x60
            new Opcode("RTS",AddressingMode.Implicit, 6 , RTS),
            new Opcode("ADC",AddressingMode.IndirectX, 6 , ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ADC",AddressingMode.ZeroPage, 3 , ADC),
            new Opcode("ROR",AddressingMode.ZeroPage, 5 , ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("PLA",AddressingMode.Implicit, 4 , PLA),
            new Opcode("ADC",AddressingMode.Immediate, 2 , ADC),
            new Opcode("ROR",AddressingMode.Accumulator, 2 , ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("JMP",AddressingMode.Indirect, 6 , JMP),
            new Opcode("ADC",AddressingMode.Absolute, 4 , ADC),
            new Opcode("ROR",AddressingMode.Absolute, 6 , ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x70
            new Opcode("BVS",AddressingMode.Relative, 2 , BVS),
            new Opcode("ADC",AddressingMode.IndirectY, 5 , ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ADC",AddressingMode.ZeroPageX, 4 , ADC),
            new Opcode("ROR",AddressingMode.ZeroPageX, 6 , ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("SEI",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.I = true;  GameState.CPU.PC += op.Size();return op.cycles;}),
            new Opcode("ADC",AddressingMode.AbsoluteY, 4 , ADC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("ADC",AddressingMode.AbsoluteX, 4 , ADC),
            new Opcode("ROR",AddressingMode.AbsoluteX, 7 , ROR),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x80
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("STA",AddressingMode.IndirectX, 6 , STA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("STY",AddressingMode.ZeroPage, 3 , STY),
            new Opcode("STA",AddressingMode.ZeroPage, 3 , STA),
            new Opcode("STX",AddressingMode.ZeroPage, 3 , STX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("DEY",AddressingMode.Implicit, 2 , DEY),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("TXA",AddressingMode.Implicit, 2 , TXA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("STY",AddressingMode.Absolute, 4 , STY),
            new Opcode("STA",AddressingMode.Absolute, 4 , STA),
            new Opcode("STX",AddressingMode.Absolute, 4 , STX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0x90
            new Opcode("BCC",AddressingMode.Relative, 2 , BCC),
            new Opcode("STA",AddressingMode.IndirectY, 6 , STA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("STY",AddressingMode.ZeroPageX, 4 , STY),
            new Opcode("STA",AddressingMode.ZeroPageX, 4 , STA),
            new Opcode("STX",AddressingMode.ZeroPageY, 4 , STX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("TYA",AddressingMode.Implicit, 2 , TYA),
            new Opcode("STA",AddressingMode.AbsoluteY, 5 , STA),
            new Opcode("TXS",AddressingMode.Implicit, 2 , TXS),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("STA",AddressingMode.AbsoluteX, 5 , STA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0xA0
            new Opcode("LDY",AddressingMode.Immediate, 2 , LDY),
            new Opcode("LDA",AddressingMode.IndirectX, 6 , LDA),
            new Opcode("LDX",AddressingMode.Immediate, 2 , LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("LDY",AddressingMode.ZeroPage, 3 , LDY),
            new Opcode("LDA",AddressingMode.ZeroPage, 3 , LDA),
            new Opcode("LDX",AddressingMode.ZeroPage, 3 , LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("TAY",AddressingMode.Implicit, 2 , TAY),
            new Opcode("LDA",AddressingMode.Immediate, 2 , LDA),
            new Opcode("TAX",AddressingMode.Implicit, 2 , TAX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("LDY",AddressingMode.Absolute, 4 , LDY),
            new Opcode("LDA",AddressingMode.Absolute, 4 , LDA),
            new Opcode("LDX",AddressingMode.Absolute, 4 , LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0xB0
            new Opcode("BCS",AddressingMode.Relative, 2 , BCS),
            new Opcode("LDA",AddressingMode.IndirectY, 5 , LDA),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("LDY",AddressingMode.ZeroPageX, 4 , LDY),
            new Opcode("LDA",AddressingMode.ZeroPageX, 4 , LDA),
            new Opcode("LDX",AddressingMode.ZeroPageY, 4 , LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CLV",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.V = false; GameState.CPU.PC += op.Size();return op.cycles; }),
            new Opcode("LDA",AddressingMode.AbsoluteY, 2 , LDA),
            new Opcode("TSX",AddressingMode.Implicit, 4 , TSX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("LDY",AddressingMode.AbsoluteX, 4 , LDY),
            new Opcode("LDA",AddressingMode.AbsoluteX, 4 , LDA),
            new Opcode("LDX",AddressingMode.AbsoluteY, 4 , LDX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0xC0
            new Opcode("CPY",AddressingMode.Immediate, 2 , CPY),
            new Opcode("CMP",AddressingMode.IndirectX, 6 , CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CPY",AddressingMode.ZeroPage, 3 , CPY),
            new Opcode("CMP",AddressingMode.ZeroPage, 3 , CMP),
            new Opcode("DEC",AddressingMode.ZeroPage, 5 , DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("INY",AddressingMode.Implicit, 2 , INY),
            new Opcode("CMP",AddressingMode.Immediate, 2 , CMP),
            new Opcode("DEX",AddressingMode.Implicit, 2 , DEX),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CPY",AddressingMode.Absolute, 4 , CPY),
            new Opcode("CMP",AddressingMode.Absolute, 4 , CMP),
            new Opcode("DEC",AddressingMode.Absolute, 6 , DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0xD0
            new Opcode("BNE",AddressingMode.Relative, 2 , BNE),
            new Opcode("CMP",AddressingMode.IndirectY, 5 , CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CMP",AddressingMode.ZeroPageX, 4 , CMP),
            new Opcode("DEC",AddressingMode.ZeroPageX, 6 , DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CLD",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.D = false; GameState.CPU.PC += op.Size();return op.cycles; }),
            new Opcode("CMP",AddressingMode.AbsoluteY, 4 , CMP),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CMP",AddressingMode.AbsoluteX, 4 , CMP),
            new Opcode("DEC",AddressingMode.AbsoluteX, 7 , DEC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
          //0xE0
            new Opcode("CPX",AddressingMode.Immediate, 2 , CPX),
            new Opcode("SBC",AddressingMode.IndirectX, 6 , SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CPX",AddressingMode.ZeroPage, 3 , CPX),
            new Opcode("SBC",AddressingMode.ZeroPage, 3 , SBC),
            new Opcode("INC",AddressingMode.ZeroPage, 5 , INC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("INX",AddressingMode.Implicit, 2 , INX),
            new Opcode("SBC",AddressingMode.Immediate, 2 , SBC),
            new Opcode("NOP",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.PC += op.Size();return op.cycles;}),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("CPX",AddressingMode.Absolute, 4 , CPX),
            new Opcode("SBC",AddressingMode.Absolute, 4 , SBC),
            new Opcode("INC",AddressingMode.Absolute, 6 , INC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            //0XF0
            new Opcode("BEQ",AddressingMode.Relative, 2 , BEQ),
            new Opcode("SBC",AddressingMode.IndirectY, 5 , SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("SBC",AddressingMode.ZeroPageX, 4 , SBC),
            new Opcode("INC",AddressingMode.ZeroPageX, 6 , INC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("SED",AddressingMode.Implicit, 2 , delegate(Opcode op){GameState.CPU.D = true;  GameState.CPU.PC += op.Size();return op.cycles;}),
            new Opcode("SBC",AddressingMode.AbsoluteY, 4 , SBC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
            new Opcode("SBC",AddressingMode.AbsoluteX, 4 , SBC),
            new Opcode("INC",AddressingMode.AbsoluteX, 7 , INC),
            new Opcode("invalid",AddressingMode.Implicit, 4 , Invalid),
  };
    }
    public CPU_6502()
    {

    }

    public void Reset()
    {
        PC = GameState.Cart.CPURead(0xfffc) | (GameState.Cart.CPURead(0xfffd) << 8);

        A = 0;
        X = 0;
        Y = 0;
        SP = 0;
        F = 0;

    }

    public void NMI()
    {
        GameState.CPU.Push((byte)((GameState.CPU.PC) & 0xFF));
        GameState.CPU.Push((byte)(((GameState.CPU.PC) >> 8) & 0xFF));
        GameState.CPU.Push((byte)(GameState.CPU.F | (1 << 4)));

        PC = GameState.Cart.CPURead(0xfffa) | (GameState.Cart.CPURead(0xfffb) << 8);

        
    }


}

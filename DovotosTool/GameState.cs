using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DovotosTool.Mappers;

namespace DovotosTool
{
    public class GameState
    {
        public static byte[] RawPRG;
        public static byte[] RawCHR;

        public static Mapper Cart;

        public delegate void Reload();

        public static Reload Reloaded;
        public static Color[] Palette;

        public static CPU_6502 CPU;
        public static bool initialized = false;

        public struct Header
        {
            public byte[] raw;
            public String nes;
            public bool valid;

            public int PRGBanks;
            public int CHRBanks;
            public int PRGRamBanks;

            public bool VerticalMirror;

            public bool batBackedPRGRam;
            public bool trainerPresent;
            public bool fourScreenVram;

            public bool VSunisys;
            public bool PlayChoice;

            public bool NTSC;

            public bool PRGRam;
            public bool BusConflicts;

            public bool NES2_0;

            public int mapper;

            
        }

        public static Header header;

        public GameState()
        {
            CPU = new CPU_6502();

            Palette = new Color[64];

            for (int i = 0; i < 64; i++)
                Palette[i] = Color.FromArgb(colorData[i * 3], colorData[i * 3 + 1], colorData[i * 3 + 2]);

          

        }
        public GameState(Stream s) : this()
        {
            LoadRom(s);

            initialized = true;
        }

        public void LoadRom(Stream s)
        {
            BinaryReader br = new BinaryReader(s);

            header.valid = true;

            header.raw = br.ReadBytes(16);

            br.BaseStream.Seek(0, SeekOrigin.Begin);

            header.nes = Encoding.UTF8.GetString(br.ReadBytes(3));

            if (br.ReadByte() != 0x1A) header.valid = false;

            header.PRGBanks = br.ReadByte();
            header.CHRBanks = br.ReadByte();

            int flags = br.ReadByte();
            int mapper = (flags >> 4);
            header.VerticalMirror = (flags & 1) != 0;
            header.batBackedPRGRam = (flags & 2) != 0;
            header.trainerPresent = (flags & 4) != 0;
            header.fourScreenVram = (flags & 8) != 0;

            flags = br.ReadByte();
            header.mapper = ((flags & 0xF0) | mapper);
            header.VSunisys = (flags & 1) != 0;
            header.PlayChoice = (flags & 2) != 0;
            header.NES2_0 = (flags & 12) != 8;

            header.PRGRamBanks = br.ReadByte();

            flags = br.ReadByte();

            header.NTSC = (flags & 3) == 0;
            header.PRGRam = (flags & 16) == 0;
            header.BusConflicts = (flags & 32) != 0;

            br.BaseStream.Seek(16, SeekOrigin.Begin);

            RawPRG = br.ReadBytes(16384 * header.PRGBanks);
            
            RawCHR = br.ReadBytes(8192 * header.CHRBanks);

            br.Close();

            if (Mapper.Mappers.ContainsKey(header.mapper))
                Cart = Mapper.Mappers[header.mapper];
            else
                Cart = new NROM();

            CPU.Reset();

            Reloaded?.Invoke();
        }

        public static int[] colorData =
        {
            124,124,124,
            0,0,252,
            0,0,188,
            68,40,188,
            148,0,132,
            168,0,32,
            168,16,0,
            136,20,0,
            80,48,0,
            0,120,0,
            0,104,0,
            0,88,0,
            0,64,88,
            0,0,0,
            0,0,0,
            0,0,0,
            188,188,188,
            0,120,248,
            0,88,248,
            104,68,252,
            216,0,204,
            228,0,88,
            248,56,0,
            228,92,16,
            172,124,0,
            0,184,0,
            0,168,0,
            0,168,68,
            0,136,136,
            0,0,0,
            0,0,0,
            0,0,0,
            248,248,248,
            60,188,252,
            104,136,252,
            152,120,248,
            248,120,248,
            248,88,152,
            248,120,88,
            252,160,68,
            248,184,0,
            184,248,24,
            88,216,84,
            88,248,152,
            0,232,216,
            120,120,120,
            0,0,0,
            0,0,0,
            252,252,252,
            164,228,252,
            184,184,248,
            216,184,248,
            248,184,248,
            248,164,192,
            240,208,176,
            252,224,168,
            248,216,120,
            216,248,120,
            184,248,184,
            184,248,216,
            0,252,252,
            248,216,248,
            0,0,0,
            0,0,0,
        };
    }

 
}

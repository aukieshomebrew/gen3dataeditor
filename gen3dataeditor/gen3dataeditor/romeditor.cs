using System;
using System.IO;
using System.Text;

namespace gen3dataeditor
{


    class RomEditor : XmlParser
    {
        private string rompath;
        BinaryReader binaryreader;
        
        public RomEditor(string rompath, string xmlpath) : base(xmlpath)
        {
            this.rompath = rompath;
        }

        public string GetGameCode()
        {
            string ret = string.Empty;
            binaryreader = new BinaryReader(File.OpenRead(rompath));
            binaryreader.BaseStream.Seek(0xAC, SeekOrigin.Begin);

            byte[] array = binaryreader.ReadBytes(4);

            ret = Encoding.UTF8.GetString(array);

            binaryreader = null;

            return ret;
        }

        public byte[] GetValueByteArray(string structname, string offsetname, Int32 index)
        {
            Int32 global = GetGlobalOffsetByGameCode(structname, GetGameCode());
            Int16 offset = GetValueOffsetByName(structname, offsetname);
            Int16 size = GetValueSizeByName(structname, offsetname);
            Int16 globalsize = GetGlobalSizeByGameCode(structname, GetGameCode());
            Int32 pos = global + offset + (index * globalsize) - 0x8000000;

            BinaryReader binaryreader = new BinaryReader(File.OpenRead(rompath));
            binaryreader.BaseStream.Seek(pos, SeekOrigin.Begin);
            byte[] ret = binaryreader.ReadBytes(size);
            binaryreader = null;
            return ret;

        }

        public string ConvertByteArrayToString(byte[] array)
        {
            StringBuilder str = new StringBuilder();
            foreach(byte i in array)
            {
                str.Append(GetAsciiByByte(i));
            }

            return str.ToString();
        }


    }

}

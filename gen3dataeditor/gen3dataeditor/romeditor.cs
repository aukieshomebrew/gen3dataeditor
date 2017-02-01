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

            using (binaryreader = new BinaryReader(File.OpenRead(rompath)))
            {
                binaryreader.BaseStream.Seek(0xAC, SeekOrigin.Begin);

                byte[] array = binaryreader.ReadBytes(4);

                ret = Encoding.UTF8.GetString(array);
            }


           

            return ret;
        }

        public byte[] GetValueByteArray(string structname, string offsetname, Int32 index)
        {
            byte[] ret;
            Int32 global = GetGlobalOffsetByGameCode(structname, GetGameCode());
            Int16 offset = GetValueOffsetByName(structname, offsetname);
            Int16 size = GetValueSizeByName(structname, offsetname);
            Int16 globalsize = GetGlobalSizeByGameCode(structname, GetGameCode());
            Int32 pos = global + offset + (index * globalsize) - 0x8000000;
            using (BinaryReader binaryreader = new BinaryReader(File.OpenRead(rompath)))
            {
                binaryreader.BaseStream.Seek(pos, SeekOrigin.Begin);
                ret = binaryreader.ReadBytes(size);
                

            }


            return ret;

        }

        public void SetValueByteArray(string structname, string offsetname, Int32 index, byte[] newvalue)
        {

            Int32 global = GetGlobalOffsetByGameCode(structname, GetGameCode());
            Int16 offset = GetValueOffsetByName(structname, offsetname);
            Int16 size = GetValueSizeByName(structname, offsetname);
            Int16 globalsize = GetGlobalSizeByGameCode(structname, GetGameCode());
            Int32 pos = global + offset + (index * globalsize) - 0x8000000;
            
            
            

            using (BinaryWriter binarywriter = new BinaryWriter(File.OpenWrite(rompath)))
            {
                Int32 j = 0;
                for (Int32 i = pos; i < i + newvalue.Length; i++, j++)
                {
                    binarywriter.BaseStream.Position = i;

                    binarywriter.Write(newvalue[j]);
                }
                byte[] zero = new byte[size - newvalue.Length];


                binarywriter.BaseStream.Position = pos + newvalue.Length;
                binarywriter.Write(zero);
                

                
                
                
             
                binarywriter.Flush();

            }

         
        }

        public bool ConvertByteArrayToInt32(byte[] array, out Int32 ret)
        {
            
            if(array.Length != 4)
            {
                ret = 0;
                return false;
            }
            else
            {
                ret = BitConverter.ToInt32(array, 0);
                return true;
            }

            
        }

        public bool ConvertByteArrayToInt16(byte[] array, out Int16 ret)
        {
            ret = 0;
            if(array.Length != 2)
            {
                ret = 0;
                return false;
            }
            else
            {
                ret = BitConverter.ToInt16(array, 0);
                return true;
            }

           
        }

        public bool ConvertByteArrayToByte(byte[] array, out byte ret)
        {
            
            if(array.Length != 1)
            {
                ret = 0;
                return false;
            }
            else
            {
                ret = array[0];
                return true;
            }

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

        public byte[] ConvertStringToByteArray(string val)
        {
            byte[] ret = new byte[val.Length];
            int j = 0;
            foreach (char i in val)
            {
                ret[j] = GetByteByAscii(i);
                j++;
            }

            return ret;
        }

        public byte[] ConvertIntToByteArray(Int32 val)
        {
            return BitConverter.GetBytes(val);
        }

        public string GetGameName()
        {
            return GetGameNameByGameCode(GetGameCode());
        }


    }

}

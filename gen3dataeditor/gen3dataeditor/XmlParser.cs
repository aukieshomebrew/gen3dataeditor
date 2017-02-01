using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace gen3dataeditor
{
    class XmlParser
    {
        private XDocument xml;
        private string path;
        private XElement root;

        protected XmlParser(string path)
        {
            this.path = path;
        }

        private void Open()
        {
            xml = XDocument.Load(path);
            root = xml.Element("data");     
        }

        private void Close()
        {
            if (root != null)
                root = null;
            if (xml != null)
                xml = null;
        }

        protected Int32 GetGlobalOffsetByGameCode(string structname, string gamecode)
        {
            Open();

            
            XElement global = root.Element("structs").Element(structname).Element("global");
            
            IEnumerable<XElement> offsets = global.Descendants("offset");
            foreach(XElement offset in offsets)
            {
                if(offset.Attribute("gamecode").Value == gamecode)
                {
                    Int32 ret = Int32.Parse(offset.Attribute("offset").Value.Substring(2), NumberStyles.HexNumber);
                    Close();
                    return ret;
                    
                }
                else
                {
                    continue;
                }
            }

            Close();
            return 0;

        }

        protected Int16 GetGlobalSizeByGameCode(string structname, string gamecode)
        {
            Open();

            
            XElement global = root.Element("structs").Element(structname).Element("global");

            IEnumerable<XElement> offsets = global.Descendants("offset");
            foreach (XElement offset in offsets)
            {
                if (offset.Attribute("gamecode").Value == gamecode)
                {
                    Int16 ret = Int16.Parse(offset.Attribute("size").Value.Substring(2), NumberStyles.HexNumber);
                    Close();
                    return ret;
                }
                else
                {
                    continue;
                }
            }
            Close();

            return 0;
        }
        protected Int16 GetValueOffsetByName(string structname, string offsetname)
        {
            Open();
            IEnumerable<XElement> offsets = root.Element("structs").Element(structname).Element("struct").Descendants("offset");
            foreach (XElement offset in offsets)
            {
                if(offset.Attribute("name").Value == offsetname)
                {
                    Int16 ret = Int16.Parse(offset.Attribute("offset").Value.Substring(2), NumberStyles.HexNumber);
                    Close();
                    return ret;
                }

                else
                {
                    continue;
                }

            }
            Close();

            return 0x0;
        }

        protected Int16 GetValueSizeByName(string structname, string offsetname)
        {
            Open();
            IEnumerable<XElement> offsets = root.Element("structs").Element(structname).Element("struct").Descendants("offset");
            foreach (XElement offset in offsets)
            {
                if (offset.Attribute("name").Value == offsetname)
                {
                    Int16 ret = Int16.Parse(offset.Attribute("size").Value.Substring(2), NumberStyles.HexNumber);
                    Close();
                    return ret;
                }

                else
                {
                    continue;
                }

            }
            Close();
            return 0x0;
        }

        protected char GetAsciiByByte(byte val)
        {
            Open();
            IEnumerable<XElement> table = root.Element("encoding-table").Descendants("encoding");
            

            foreach(XElement character in table)
            {
                if(Byte.Parse(character.Attribute("hex").Value.Substring(2), NumberStyles.HexNumber) == val)
                {
                    char ret = character.Attribute("ascii").Value[0];
                    Close();
                    return ret;
                    
                }
                else
                {
                    continue;
                }

            }

            Close();
            return ' ';
        }

        protected byte GetByteByAscii(char c)
        {
            Open();
            IEnumerable<XElement> table = root.Element("encoding-table").Descendants("encoding");

            

            foreach(XElement character in table)
            {
                if(Char.Parse(character.Attribute("ascii").Value) == c)
                {
                    byte ret = Byte.Parse(character.Attribute("hex").Value.Substring(2), NumberStyles.HexNumber);
                    Close();
                    return ret;
                    

                }
                else
                {
                    continue;
                }

                
            }

            Close();
            return 0x00;

        }

        protected string GetStringByByteArray(byte[] chars)
        {
            StringBuilder str = new StringBuilder();
            foreach(byte i in chars)
            {
                str.Append(GetAsciiByByte(i));
            }

            return str.ToString();
        }

    }
}

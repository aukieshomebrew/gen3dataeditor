
using CommandLine;
using CommandLine.Text;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace gen3dataeditor
{
    class gen3dataeditor
    {

        
        static int Main(string[] args)
        {
            Options opt = new Options();
            Parser p = new Parser();
            gen3dataeditor main = new gen3dataeditor();



            if (!p.ParseArguments(args, opt))
            {
                Console.WriteLine(opt.GetUsage());
                return 0;
            }


            if (!File.Exists(opt.ArgRomFile))
            {
                Console.WriteLine("Invalid GBA ROM path.");
                return 0;
            }
                
            if (!File.Exists(opt.ArgXmlFile))
            {
                Console.WriteLine("Invalid data XML path.");
                return 0;
            }

            if (opt.ArgListStruct)
            {
                main.ListStruct(opt);
                return 0;
            }

            if (!string.IsNullOrWhiteSpace(opt.ArgListOffsets))
            {
                main.ListOffsets(opt.ArgListOffsets, opt);
                return 0;
            }

            string game = "";
            RomEditor gamecoder = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);
            



            game = gamecoder.GetGameName();

            
          

            gamecoder = null;
            
            if (string.IsNullOrEmpty(game))
            {
                Console.WriteLine("Game not supported!");
              
                return 0;
            }
            Console.WriteLine("Game: {0}", game);





            gamecoder = null;


            if (opt.ArgGetValueString)
            {
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);
                string line = romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex));
                Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                Console.Write("Value: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(line);
                Console.ResetColor();
                romeditor = null;
                return 0;
            }
            else if (opt.ArgGetValueInt)
            {
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

                Int32 write32 = 0;
                Int16 write16 = 0;
                byte writebyte = 0;

                if (!romeditor.ConvertByteArrayToInt32(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex), out write32))
                {
                }
                else
                {
                    Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", write32);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", write32);
                        Console.ResetColor();
                    }
                    
                    romeditor = null;
                    return 0;
                }
                if (!romeditor.ConvertByteArrayToInt16(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex), out write16))
                {
                }
                else
                {
                    Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", write16);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", write16);
                        Console.ResetColor();
                    }
                    romeditor = null;
                    return 0;
                }
                if (!romeditor.ConvertByteArrayToByte(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex), out writebyte))
                {
                    Console.WriteLine("Failed!");
                }
                else
                {
                    Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", writebyte);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", writebyte);
                        Console.ResetColor();
                    }
                    romeditor = null;
                    return 0;
                }

            }

            else if (!string.IsNullOrWhiteSpace(opt.ArgSetValueString))
            {
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

                Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);

                Console.Write("Value before: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}", romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex)));
                Console.ResetColor();

                romeditor.SetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex, romeditor.ConvertStringToByteArray(opt.ArgSetValueString), true);

                Console.Write("Value after: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}", romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex)));
                Console.ResetColor();

                romeditor = null;
                return 0;
            }
            else if (opt.ArgSetValueInt > 0)
            {
               
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

                Int16 write16 =0;
                Int32 write32 =0;
                byte writebyte =0;

                byte[] array = romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex);

                Console.WriteLine("Struct: {0}, Offset: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                if(!romeditor.ConvertByteArrayToInt32(array, out write32))
                {

                }
                else
                {
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value before: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", write32);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value before: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", write32);
                        Console.ResetColor();
                    }
                }
                if (!romeditor.ConvertByteArrayToInt16(array, out write16))
                {

                }
                else
                {
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", write16);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value before: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", write16);
                        Console.ResetColor();
                    }
                }
                if (!romeditor.ConvertByteArrayToByte(array, out writebyte))
                {

                }
                else
                {
                    if (opt.ArgPrintHex)
                    {
                        Console.Write("Value before: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", writebyte);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value before: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", writebyte);
                        Console.ResetColor();
                    }
                }

                romeditor.SetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex, romeditor.ConvertIntToByteArray(opt.ArgSetValueInt), false);

                array = romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                Int16 afterwrite16 = 0;
                Int32 afterwrite32 = 0;
                byte afterwritebyte = 0;

                if (!romeditor.ConvertByteArrayToInt32(array, out afterwrite32))
                {

                }
                else
                {
                    if(opt.ArgPrintHex)
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", afterwrite32);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", afterwrite32);
                        Console.ResetColor();
                    }
                }
                if (!romeditor.ConvertByteArrayToInt16(array, out afterwrite16))
                {

                }
                else
                {
                    if (opt.ArgPrintHex)
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", afterwrite16);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", afterwrite16);
                        Console.ResetColor();
                    }
                }
                if (!romeditor.ConvertByteArrayToByte(array, out afterwritebyte))
                {

                }
                else
                {
                    if (opt.ArgPrintHex)
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("0x{0:X}", afterwritebyte);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Value after: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", afterwritebyte);
                        Console.ResetColor();
                    }
                }




                return 0;
            }



            Console.WriteLine("Nothing done!");
            return 0;
        }

        public void ListStruct(Options opt)
        {
            RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

            List<string> list = romeditor.GetStructList();

            Console.WriteLine("Structures: ");
            Console.WriteLine();

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

           

        }

        public void ListOffsets(string structname, Options opt)
        {
            RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

            List<string> list = romeditor.GetOffsetList(structname);
            Console.WriteLine("Offsets in: {0}", structname);
            Console.WriteLine();
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

      

        }


    }


    class Options
    {
        [Option('f', "rom-file", HelpText = "Path to ROM file.", Required = true)]
        public string ArgRomFile { get; set; }

        [Option('d', "xml-file", HelpText = "Path to XML file.", DefaultValue = "data.xml")]
        public string ArgXmlFile { get; set; }

        [Option("get-value-string", HelpText = "Gets a value string.", MutuallyExclusiveSet = "get")]
        public bool ArgGetValueString { get; set; }

        [Option("set-value-string", HelpText = "Sets value to string", MutuallyExclusiveSet = "set")]
        public string ArgSetValueString { get; set; }

        [Option("get-value-int", HelpText = "Gets a value integer.", MutuallyExclusiveSet = "get")]
        public bool ArgGetValueInt { get; set; }

        [Option("set-value-int", HelpText = "Sets value to int", MutuallyExclusiveSet ="set", DefaultValue = -1)]
        public int ArgSetValueInt { get; set; }

        [Option("struct", HelpText = "Specify structname.", DefaultValue = "itemdatastruct" )]
        public string ArgStruct { get; set; }

        [Option("offset", HelpText = "Specify offset name", DefaultValue = "name")]
        public string ArgName { get; set; }

        [Option("index", HelpText = "Specify index number.", DefaultValue = 1)]
        public int ArgIndex { get; set; }

        [Option('x', "print-hex", HelpText = "Print integer as hexnumber", Required = false)]
        public bool ArgPrintHex { get; set; }

        [Option("list-structs", HelpText = "List all structs in the data.xml file.")]
        public bool ArgListStruct { get; set; }

        [Option("list-offsets", HelpText = "List all offsets in a structure in the data.xml file.")]
        public string ArgListOffsets{ get; set; }

      



        [HelpOption]
        public string GetUsage()
        {
            HelpText help = new HelpText
            {
                Heading = new HeadingInfo("gen3dataedior", "0.3"),
                Copyright = new CopyrightInfo("Aukie's Homebrew", 2017),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Usage: gen3dataeditor --rom-file <*.gba> --struct --index [--xml-file <*.xml>] [--get-value-string] [--get-value-int] [--set-value-string <string>] [--set-value-int <integer>]");

            help.AddOptions(this);

            return help;

        }

    }

 
}


using CommandLine;
using CommandLine.Text;
using System;
using System.IO;

namespace gen3dataeditor
{
    class gen3dataeditor
    {

        
        static int Main(string[] args)
        {
            Options opt = new Options();
            Parser p = new Parser();



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

            string game = "";
            RomEditor gamecoder = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);
            


            game = gamecoder.GetGameName();
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
                Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                Console.WriteLine("Value: {0}", line);
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
                    Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    Console.WriteLine("Value: {0}", write32);
                    romeditor = null;
                    return 0;
                }
                if (!romeditor.ConvertByteArrayToInt16(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex), out write16))
                {
                }
                else
                {
                    Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    Console.WriteLine("Value: {0}", write16);
                    romeditor = null;
                    return 0;
                }
                if (!romeditor.ConvertByteArrayToByte(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex), out writebyte))
                {
                    Console.WriteLine("Failed!");
                }
                else
                {
                    Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                    Console.WriteLine("Value: {0}", writebyte);
                    romeditor = null;
                    return 0;
                }

            }

            else if (opt.ArgSetValueString != string.Empty)
            {
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

                Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);

                Console.WriteLine("Value before: {0}", romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex)));
                romeditor.SetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex, romeditor.ConvertStringToByteArray(opt.ArgSetValueString));
                Console.WriteLine("Value after: {0}", romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex)));

                romeditor = null;
                return 0;
            }
            else if (opt.ArgSetValueInt > 0)
            {
                Console.WriteLine("Not implemented yet.");
                RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);

                Int16 write16 =0;
                Int32 write32 =0;
                byte writebyte =0;

                byte[] array = romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex);

                Console.WriteLine("Struct: {0}, Name: {1}, Index: {2}", opt.ArgStruct, opt.ArgName, opt.ArgIndex);
                if(!romeditor.ConvertByteArrayToInt32(array, out write32))
                {

                }
                else
                {
                    Console.Write("Value before: ", write16);
                }
                if (!romeditor.ConvertByteArrayToInt16(array, out write16))
                {

                }
                else
                {
                    Console.Write("Value before: ", write16);
                }
                if (!romeditor.ConvertByteArrayToByte(array, out writebyte))
                {

                }
                else
                {
                    Console.Write("Value before: ", writebyte);
                }

                romeditor.SetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex, romeditor.ConvertIntToByteArray(opt.ArgSetValueInt));


                if (!romeditor.ConvertByteArrayToInt32(array, out write32))
                {

                }
                else
                {
                    Console.Write("Value after: ", write16);
                }
                if (!romeditor.ConvertByteArrayToInt16(array, out write16))
                {

                }
                else
                {
                    Console.Write("Value after: ", write16);
                }
                if (!romeditor.ConvertByteArrayToByte(array, out writebyte))
                {

                }
                else
                {
                    Console.Write("Value after: ", writebyte);
                }




                return 0;
            }



            Console.WriteLine("Nothing done!");
            return 0;
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



        [Option("struct", HelpText = "Specify structname.", DefaultValue = "itemdatastruct" , Required = true)]
        public string ArgStruct { get; set; }

        [Option("offset", HelpText = "Specify offset name", DefaultValue = "name")]
        public string ArgName { get; set; }


        [Option("index", HelpText = "Specify index number.", DefaultValue = 1, Required = true)]
        public int ArgIndex { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HelpText help = new HelpText
            {
                Heading = new HeadingInfo("gen3dataedior", "0.1"),
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

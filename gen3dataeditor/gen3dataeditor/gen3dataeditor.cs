
using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
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
                return 0;
            if (!File.Exists(opt.ArgXmlFile))
                return 0;

            if(opt.ArgGetValue)
            {
                if(opt.ArgGetValueString)
                {
                    RomEditor romeditor = new RomEditor(opt.ArgRomFile, opt.ArgXmlFile);
                    Console.WriteLine(romeditor.ConvertByteArrayToString(romeditor.GetValueByteArray(opt.ArgStruct, opt.ArgName, opt.ArgIndex)));
                    romeditor = null;
                    return 0;
                }
                else if(opt.ArgGetValueInt)
                {
                    Console.WriteLine("Not implemented yet.");
                    return 0;
                }
            } else if(opt.ArgSetValue)
            {
                if(opt.ArgSetValueString != string.Empty)
                {
                    Console.WriteLine("Not implemented yet.");
                    return 0;
                }
                else if(opt.ArgSetValueString != string.Empty)
                {
                    Console.WriteLine("Not implemented yet.");
                    return 0;
                }
            }
            
         

            return 0;
        }
    }

    enum DataType
    {
        Int,
        String
    }

    class Options
    {
        [Option('f', "rom-file", HelpText = "Path to ROM file.", Required = true)]
        public string ArgRomFile { get; set; }

        [Option('d', "xml-file", HelpText = "Path to XML file.", DefaultValue = "data.xml")]
        public string ArgXmlFile { get; set; }

        [Option("set-value", HelpText = "Sets a value.", MutuallyExclusiveSet = "set")]
        public bool ArgSetValue { get; set; }

        [Option("get-value", HelpText = "Gets a value.", MutuallyExclusiveSet = "get")]
        public bool ArgGetValue { get; set; }

        [Option("get-value-string", HelpText = "Gets a value string.", MutuallyExclusiveSet = "get")]
        public bool ArgGetValueString { get; set; }

        [Option("get-value-int", HelpText = "Gets a value integer.", MutuallyExclusiveSet = "get")]
        public bool ArgGetValueInt { get; set; }

        [Option("set-value-int", HelpText = "Sets value to...", MutuallyExclusiveSet ="set")]
        public int ArgSetValueInt { get; set; }

        [Option("set-value-string", HelpText = "Sets value to...", MutuallyExclusiveSet = "set")]
        public string ArgSetValueString { get; set; }

        [Option("struct", HelpText = "Specify structname.", DefaultValue = "itemdatastruct" , Required = true)]
        public string ArgStruct { get; set; }

        [Option("name", HelpText = "Specify offset name", DefaultValue = "name")]
        public string ArgName { get; set; }


        [Option("index", HelpText = "Specify index number.", DefaultValue = 1, Required = true)]
        public int ArgIndex { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HelpText help = new HelpText
            {
                Heading = new HeadingInfo("gen3dataedior", "0.0.1"),
                Copyright = new CopyrightInfo("Aukie's Homebrew", 2017),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Usage: gen3dataeditor");
            help.AddOptions(this);

            return help;



        }

        

    }

 
}

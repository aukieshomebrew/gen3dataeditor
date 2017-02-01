# gen3dataeditor
Edit all kinds of data in a generation 3 Pokemon GBA ROM.

How to use:
        

        Usage: gen3dataeditor --rom-file <*.gba> --struct --index [--xml-file <*.xml>]
        [--get-value-string] [--get-value-int] [--set-value-string <string>]
        [--set-value-int <integer>]

                -f, --rom-file        Required. Path to ROM file.

                -d, --xml-file        (Default: data.xml) Path to XML file.

                --get-value-string    Gets a value string.

                --set-value-string    Sets value to string

                --get-value-int       Gets a value integer.

                --set-value-int       (Default: -1) Sets value to int

                --struct              (Default: itemdatastruct) Specify structname.
        
                --offset              (Default: name) Specify offset name
        
                --index               (Default: 1) Specify index number.

                -x, --print-hex       (Default: False) Print integer as hexnumber

                --list-structs        List all structs in the data.xml file.

                --list-offsets        List all offsets in a structure in the data.xml file.

                --help                Display this help screen.
    
  
How to compile:
  
    1. Clone this project in a directory.
    2. Go to the project directory.
    3. Use 'nuget restore' to download dependencies. (nuget download: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
    4. Use msbuild to compile binaries.
    5. Go to the ouput directory and you can run the program.
    
 About the data.xml file:
  
    1. The data.xml file defines all offsets and memory adresses of the games + supported gamecodes.
    2. It also defines the structnames used in the program.
    3. You can edit the data.xml file, but be careful: Setting wrong offsets in the rom could break the game.
    
    
    

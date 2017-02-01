# gen3dataeditor
Edit all kinds of data in a generation 3 Pokemon GBA ROM.

How to use:

gen3dataedior 0.1
Copyright (C) 2017 Aukie's Homebrew
Usage: gen3dataeditor --rom-file <*.gba> --struct --index [--xml-file <*.xml>]
[--get-value-string] [--get-value-int] [--set-value-string <string>]
[--set-value-int <integer>]

  -f, --rom-file        Required. Path to ROM file.

  -d, --xml-file        (Default: data.xml) Path to XML file.

  --get-value-string    Gets a value string.

  --set-value-string    Sets value to string

  --get-value-int       Gets a value integer.

  --set-value-int       (Default: -1) Sets value to int

  --struct              Required. (Default: itemdatastruct) Specify structname.

  --name                (Default: name) Specify offset name

  --index               Required. (Default: 1) Specify index number.

  --help                Display this help screen.
  
  How to compile:
  
    1. Clone this project in a directory.
    2. Go to the project directory.
    3. Use 'nuget restore' to download dependencies.
    4. Use msbuild to compile binaries.
    5. Go to the ouput directory and you can run the program.
    
 About the data.xml file:
  
    1. The data.xml file defines all offsets and memory adresses of the games.
    2. It also defines the supported gamecodes.
    
    

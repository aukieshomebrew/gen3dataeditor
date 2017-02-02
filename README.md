# gen3dataeditor

Edit all kinds of data in a generation 3 Pokemon GBA ROM.

## How to compile:


Requirements: You need the .Net Framework in your path: (example: "C\Windows\Microsoft.NET\Framework\v4.0.30319")


1. Clone this project in a directory.
2. Go to the project directory.
3. Use ```nuget restore``` to download dependencies. (nuget download: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
4. Use ```msbuild``` to compile binaries.
5. You'll find the compiled binaries at the bin directory ("[clone-directory] /gen3dataeditor/bin").

## How to use (GUI):
        
        
This is the main window.

![alt tag](http://i.imgur.com/ZEJ9BdF.png)
        
First of all you need to load a GBA Pokemon ROM file.
Note: It wont edit the ROM file yet.
        
![alt tag](http://i.imgur.com/p4ROIAQ.png)
        
This programs uses structs to find offsets of various values or strings. You can list your available struct
by clicking the "List Structs" button.
        
![alt tag](http://i.imgur.com/wYCHk7v.png)
        
You will see a list of structures in the console view:
        
![alt tag](http://i.imgur.com/BlTjRGr.png)
        
Copy the string into the "Struct name" textfield.
        
![alt tag](http://i.imgur.com/y053H8a.png)
        
You can now press "List offsets". This will list all offsets in the struct you just specified.
        
![alt tag](http://i.imgur.com/s6mJ3Zl.png)
        
![alt tag](http://i.imgur.com/Op8WTXF.png)
        
You can put the string you want into the textfield: "Offset name":
        
![alt tag](http://imgur.com/Gc2jVUP.png)
        
Now select the radio button get value. And if the value you want is a string, you can selet
the: "Value is a string" checkbox.
        
![alt tag](http://imgur.com/ALUb2d5.png)
![alt tag](http://imgur.com/OmKLK2a.png)
        
Finally put an index number into the "Index" field. You can find index numbers on Bulbapedia                 (http://bulbapedia.bulbagarden.net/).
        
![alt tag](http://imgur.com/FJfJo66.png)
        
On the console view, it outputs the game name, the data you entered and the value 
from the ROM file.
        
![alt tag](http://imgur.com/LuhCkja.png)
        
Now you have gotten the string. Lets change it!
        
Now select "Set value" radiobutton and enter a string at "Set value":
        
![alt tag](http://imgur.com/Wfz7RFy.png)
        
![alt tag](http://imgur.com/23gr2qk.png)
        
        
Run the program by pressing execute you'll see a value before and a value after.
        
![alt tag](http://imgur.com/XKeDZVi.png)
        
        
Now you edited the ROM. Open the ROM in an emulator and see the results!
        
![alt tag](http://i.imgur.com/bEAL7Sr.png)
        
        
        
        
        
        

 
  

    
## About the data.xml file:
  
1. The data.xml file defines all offsets and memory adresses of the games + supported gamecodes.
2. It also defines the structnames used in the program.
3. You can edit the data.xml file, but be careful: Setting wrong offsets in the rom could break the game.
    
    
    

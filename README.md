# FFMPEG-GUI-For-Godot
FFMPEG GUI for converting MP4 videos to ogg for Godot's VideoStreamPlayer node


This is written in C# with Godot 4.2.1.stable.mono.official [b09f793f5]
Windows 10 64 bit.

You need to download FFMPEG from FFMPEG. 
Working with FFmpeg 64 bit full build from gyan.dev
Version: 2024-03-25-git-ecdc94b97f-full_build-www.gyan.dev 


#How to use
Download and install/extract FFmpeg. 
Download the compiled version of FFmpeg GUI for Godot here: (Build not yet available)
Or compile the source code in Godot. 

Get the file path to your FFmpeg filepath. 
Example:
C:\Program Files\FFMPEG\ffmpeg-2024-03-25-git-ecdc94b97f-full_build\bin\
Remember the final slash.
You can click the "Update Executible Path" to save the file path so the next time you open the program, the filepath is already there.
Save file is in text format "config.dat" and is created when you save for the first time next to the executible. 

Find an MP4 file you want to use.
You can use the folder and/or the file text boxes. The code combines them.
I made a separate file text box so you can more easily convert multiple mp4 to ogg 
without messing up the containing folder.

Enter the file path WITH the file extension. (mp4.)


Specify the output folder and file name WITH file extension. (.ogg)

Click "Process File" button.
Wait for command prompt to finish executing.
Close command prompt, repeat for subsequent files.

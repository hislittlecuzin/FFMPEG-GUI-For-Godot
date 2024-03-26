using Godot;
using System;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Threading;

public partial class MainProcessScript : Control {


	[Export]
	Button processButton;

	[Export]
	LineEdit ffmpegExecutibleField;
	//C:\Program Files\FFMPEG\ffmpeg-2024-03-25-git-ecdc94b97f-full_build\bin\ffmpeg.exe

	[ExportGroup("Input Fields")]
	[Export]
	LineEdit inputFolder;
	[Export]
	LineEdit inputFile;

	[ExportGroup("Output Fields")]
	[Export]
	LineEdit outputFolder;
	[Export]
	LineEdit outputFile;
	//C:/Documents/Videos/

	const string dataFileName = "config.dat";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		if (Godot.FileAccess.FileExists(dataFileName)) {
			using var dataFile = Godot.FileAccess.Open(dataFileName, FileAccess.ModeFlags.Read);
			string dataFileContents = dataFile.GetAsText();
			ffmpegExecutibleField.Text = dataFileContents;
			dataFile.Close();
		}
	}

	public void SaveFFMPEGFilePath() {
		using var dataFile = Godot.FileAccess.Open(dataFileName, FileAccess.ModeFlags.Write);
		string dataFileContents = ffmpegExecutibleField.Text;
		dataFile.StoreString(dataFileContents);
		dataFile.Close();
	}

	public void ProcessVideo() {
		string inputFilePath = "\"" + inputFolder.Text + inputFile.Text + "\"";
		string outputFilePath = "\"" + outputFolder.Text + outputFile.Text + "\"";

		string arguments = "-i " + inputFilePath + " -q:v 6 -q:a 6 " + outputFilePath;

		//feign process
		if (false) {
			System.Diagnostics.Process foobarProc = new System.Diagnostics.Process();
			foobarProc.StartInfo.FileName = ffmpegExecutibleField.Text;
			foobarProc.Start();

			return;
		}

		//Runs FFMPEG in Command prompt. Moving to run FFMPEG directly may be better but... it takes 1 second per second to render so...
		{
			System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("cmd");

			processStartInfo.WorkingDirectory = ffmpegExecutibleField.Text;

			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;

			//Capturing output causes the program to not work. 
			//processStartInfo.RedirectStandardOutput = true;
			//processStartInfo.RedirectStandardError = true;

			var process = Process.Start(processStartInfo);

			process.StandardInput.WriteLine("ffmpeg " + arguments);
			process.StandardInput.WriteLine("exit");


			//Capturing output causes the program to not work. 
			//string s = process.StandardOutput.ReadToEnd();
			//GD.Print("Console output: ");
			//GD.Print(s);
		}



		//ffmpeg -i "C:\inputVideo.mp4" -q:v 6 -q:a 6 "C:\outputVideo.ogg"
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

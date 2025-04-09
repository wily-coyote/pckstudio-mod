﻿using PckStudio.Internal.App;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace PckStudio {
	static class Program {
		internal static readonly Uri ProjectUrl = new Uri("https://github.com/PhoenixARC/-PCK-Studio");
		internal static readonly Uri RawProjectUrl = new Uri("https://raw.githubusercontent.com/PhoenixARC/-PCK-Studio");
		internal static readonly string BaseAPIUrl = "http://api.pckstudio.xyz/api/pck";
		internal static readonly string BackUpAPIUrl = "https://raw.githubusercontent.com/PhoenixARC/pckstudio.tk/main/studio/PCK/api/";

		internal static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.ProductName);
		internal static readonly string AppDataCache = Path.Combine(AppData, "cache");

		internal static MainForm MainInstance { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Updater.Initialize(RawProjectUrl);

			ApplicationScope.Initialize();
			Trace.TraceInformation("Startup");
			MainInstance = new MainForm();
			Updater.SetOwner(MainInstance);
			if(args.Length > 0 && File.Exists(args[0]) && args[0].EndsWith(".pck"))
				MainInstance.InitPckFromFile(args[0]);
			//Application.ApplicationExit += (sender, e) => {  };
			MainInstance.FocusMe();
			Application.Run(MainInstance);
		}
	}
}
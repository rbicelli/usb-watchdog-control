/*
 * Created by SharpDevelop.
 * User: Riccardo Bicelli <r.bicelli@gmail.com>
 * Date: 07/05/2018
 * Time: 16:50
 *  
 */
using System;
using System.IO;

namespace USBWatchdogControl
{
	/// <summary>
	/// Global Class
	/// </summary>
	public static class Globals
	{
		public const string INI_FILE = "usbwatchdog-config.ini";
		private static string _appDataFolder;
		static Globals()
		{
			// Create Appdata folder id not exists
			_appDataFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\usbwatchdog";
			if (!Directory.Exists(_appDataFolder)) Directory.CreateDirectory(_appDataFolder);
		}
		public static string INI_FILENAME {
			get => _appDataFolder + @"\settings.ini";
		}
								
	}
}

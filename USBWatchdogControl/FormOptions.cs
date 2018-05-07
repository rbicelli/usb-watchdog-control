/*
 * Created by SharpDevelop.
 * User: Riccardo Bicelli <r.bicelli@gmail.com>
 * Date: 07/05/2018
 * Time: 11:59
 * 
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;

namespace USBWatchdogControl
{
	/// <summary>
	/// Description of FormOptions.
	/// </summary>
	public partial class FormOptions : Form
	{
		private IniData ini_data;
		private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		
		public FormOptions()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//Load Configuration			
    		//config.AppSettings.Settings.Add("YourKey", "YourValue");
    		//config.Save(ConfigurationSaveMode.Minimal);
    		_loadConfig();
		}
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Dispose();
		}
		void BtnOKClick(object sender, EventArgs e)
		{
			if (_saveConfig()) this.Dispose();
		}
		
		private void _loadConfig() {
			//Load configuration
			if (File.Exists(Globals.INI_FILENAME)) {
				var ini = new FileIniDataParser();
				ini_data = ini.ReadFile(Globals.INI_FILENAME);
				nUDHeartbeatTimeout.Value = int.Parse(ini_data["global"]["heartbeat_timeout"]);
			} else {
				ini_data = new IniData();
			}
			
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			
			if (rk.GetValue(Application.ProductName)==null)
				chkAutostart.Checked = false;
			else
				chkAutostart.Checked = true;							
		}
		
		private bool _saveConfig() {
			var ini = new FileIniDataParser();			
			ini_data["global"]["heartbeat_timeout"] = nUDHeartbeatTimeout.Value.ToString();
			ini.WriteFile(Globals.INI_FILENAME,ini_data,null);
			
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (chkAutostart.Checked)
            	rk.SetValue(Application.ProductName, Application.ExecutablePath);
        	else
            	rk.DeleteValue(Application.ProductName,false);            
			
			return true;
		}
		
	}
}

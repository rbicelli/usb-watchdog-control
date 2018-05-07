/*
 * Created by SharpDevelop.
 * User: Riccardo Bicelli <r.bicelli@gmail.com>
 * Date: 04/05/2018
 * Time: 15:45
 * 
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace USBWatchdogControl
{
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		private USBWatchdog UsbW = new USBWatchdog(180);
		private string prev_icon="OK";
		
		#region Initialize icon and menu		
		
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());			
			notifyIcon.DoubleClick += IconDoubleClick;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
			notifyIcon.Icon = (Icon)resources.GetObject("$this.IconOK");
			notifyIcon.ContextMenu = notificationMenu;									
			notifyIcon.Text="USB Watchdog Control";

			this.UsbW.StatusChanged += new USBWatchdog.StatusChangedHandler(WatchdogStatus);						
		}
		
		private MenuItem[] InitializeMenu()
		{
			MenuItem[] menu = new MenuItem[] {
				new MenuItem("About", menuAboutClick),
				new MenuItem("Reset System", menuResetClick),				
				new MenuItem("Configuration", menuConfigClick),
				new MenuItem("Exit", menuExitClick)
				
			};
			return menu;
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, "USBWatchdogControl", out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					notificationIcon.notifyIcon.Visible = true;
					notificationIcon._loadConfig();
					notificationIcon.UsbW.HeartbeatRun();
					Application.Run();
					notificationIcon.notifyIcon.Dispose();
				} else {
					// The application is already running
					// TODO: Display message box or change focus to existing application instance
				}
			} // releases the Mutex
		}
		#endregion
		
		#region Event Handlers
		private void menuAboutClick(object sender, EventArgs e)
		{			
			MessageBox.Show("USB Watchdog Control.\nWritten by Riccardo Bicelli <r.bicelli@gmail.com>", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);			
		}
		
		private void menuExitClick(object sender, EventArgs e)
		{
			UsbW.HeartbeatStop();
			Application.Exit();
		}
		
		private void menuResetClick(object sender, EventArgs e)
		{
			if ( MessageBox.Show("Do you really want to Reset System?", "Reset System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
				UsbW.reset();
		}
		
		private void menuConfigClick(object sender, EventArgs e)
		{
			Form f1 = new FormOptions();
			f1.ShowDialog();
			this._loadConfig();
		}
		
		private void IconDoubleClick(object sender, EventArgs e)
		{
			MessageBox.Show("The icon was double clicked");
		}
		
		private void WatchdogStatus(object sender, USBWatchdogEventArgs e) {
			string icon = "OK";
			switch (e.Status) {
				case USBWatchdog.W_STATUS_CONNECTED:
					Debug.Print("Watchdog Connected");					
					break;
					
				case USBWatchdog.W_STATUS_HEARTBEATSENT:
					Debug.Print("Watchdog Sent Heartbeat");
					break;
					
				case USBWatchdog.W_STATUS_HEARTBEATFAILED:
					Debug.Print("Watchdog Failed Heartbeat");
					icon = "KO";
					break;
				
				case USBWatchdog.W_STATUS_DISCONNECTED:
					Debug.Print("Watchdog Disconnected");
					icon = "KO";
					break;									
				
			}
			
			setIcon(icon);						
		}				
		#endregion
	
		private void setIcon(string sIcon){
			if ( prev_icon != sIcon) {
				Debug.Print("Setting Icon " + sIcon);
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
				this.notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon" + sIcon);
				this.notifyIcon.Visible=true;
				prev_icon = sIcon;				
			}
		}
		
		private void _loadConfig() {
			//Load configuration
			if (File.Exists(Globals.INI_FILENAME)) {
				IniData ini_data;
				var ini = new FileIniDataParser();
				ini_data = ini.ReadFile(Globals.INI_FILENAME);
				this.UsbW.setTimeout(int.Parse(ini_data["global"]["heartbeat_timeout"]));			
			}
		}
	}}

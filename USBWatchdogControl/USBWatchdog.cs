/*
 * Created by SharpDevelop.
 * User: Riccardo Bicelli <r.bicelli@gmail.com>
 * Date: 04/05/2018
 * Time: 15:45
 * 
 * USB Watchdog control class
 * 
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Threading;
using HidSharp.Reports;
using HidSharp.Reports.Encodings;


namespace USBWatchdogControl
{
	/// <summary>
	/// USB Watchdog Control Class. Send Heartbeat to USB Watchdog
	/// </summary>
	/// 
			
	public class USBWatchdog
	{
		public const int W_STATUS_CONNECTED = 101;
		public const int W_STATUS_DISCONNECTED = 102;
		public const int W_STATUS_HEARTBEATSENT = 103;
		public const int W_STATUS_HEARTBEATFAILED = 104;
				
		private bool deviceFound;
		private int myVendorID;
        private int myProductID;
        private byte heartbeatTimeout;        
        private bool hStop; //Start/Stop variable for heartbeat thread 
        private bool hStarted;
        private HidSharp.HidDevice _HidDev;
		
		public delegate void StatusChangedHandler(object sender, USBWatchdogEventArgs e);		
        public event StatusChangedHandler StatusChanged;

        public USBWatchdog(int timeoutInSeconds)
		{									
			this.setTimeout(timeoutInSeconds);
			//Todo: Load From INI File			
			this.myVendorID = 20785;
      		this.myProductID = 8199;
			this.deviceFound = _findDevice();
		}		
								
		private bool _writeMessage(byte[] message){
			HidSharp.HidStream stream;
			byte[] response;
			if (_HidDev == null) this._findDevice();
			if (_HidDev!=null) {
				if (_HidDev.TryOpen(out stream)) {
					stream.Write(message);
		  			response = stream.Read();					  			
		  			if (response[1]==message[1]) return true;
				}
			}
			return false;			
		}
		
		private void _heartbeatRun(){
			this.hStarted = true;
			while (hStop==false) {
				var message = new byte[2];
				message[0] = 24;
				message[1] = (byte)(this.heartbeatTimeout + 12);				
				if (_writeMessage(message)) {
					_StatusChanged(W_STATUS_HEARTBEATSENT);
				}else{
					_StatusChanged(W_STATUS_HEARTBEATFAILED);
				}
				Thread.Sleep(1000);
			}
			this.hStarted = false;
		}
		
		private bool _findDevice() {
			var list = HidSharp.DeviceList.Local;
			_HidDev = list.GetHidDeviceOrNull(myVendorID, myProductID, null, null);			
			
			if (_HidDev!=null) {
				this._StatusChanged(W_STATUS_CONNECTED);
				return true;
			}
			
			this._StatusChanged(W_STATUS_DISCONNECTED);
			return false;
		}		
		
		public bool reset(){			
			var message = new byte[2];
			bool r;
			message[0] = 128;
			message[1] = 0;
			r = _writeMessage(message);
			this._HidDev = null; //Force a reconnect
			return r;
		}
		
		public void HeartbeatRun(){						
			Thread t = new Thread(_heartbeatRun);
			if (this.hStarted == false) {
				t.Start();
			}
		}
		
		public void HeartbeatStop(){
			hStop = true;			
		}
		
		public void setTimeout(int timeoutInSeconds){
			this.heartbeatTimeout = (byte)(timeoutInSeconds/10);
		}
		
		public void _StatusChanged(int iStatus) {												        	        	
        	if (null != StatusChanged) {
        		StatusChanged(this,new USBWatchdogEventArgs(iStatus));        		
        	}
		}
					
	}
	
	public class USBWatchdogEventArgs : EventArgs
	{
	    private int i_Status;
	    public USBWatchdogEventArgs(int _iStatus)
	    {
	    	i_Status = _iStatus;
	    }
	
	    public int Status {get{return i_Status;}}
	}
}
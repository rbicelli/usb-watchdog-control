# USB Watchdog Control

This is the Opensource implementation of the USB watchdog program who comes with USB watchdog used in mining rigs.
Tried and tested with the USB_WDG_V3.1.

## Features
The program sits in System tray and sends heartbeat to USB device. The device detection is automatic. The only configurable options is the heartbeat timeout.  

##Requirements
USBWatchdogControl is written in C#, using Sharpdevelop.

I used these two libs taken directly from nuGet: 
[HidSharp](https://www.zer7.com/software/hidsharp)
[INIFileParser](https://github.com/rickyah/ini-parser)
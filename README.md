﻿[![Buy Me A Coffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/rbicelli)
 
 # USB Watchdog Control

This is the Opensource implementation of the USB watchdog program which comes with USB watchdog used in mining rigs.
Tried and tested with the USB_WDG_V3.1.

## Features
The program sits in System tray and sends heartbeat to USB device. The device detection is automatic. The only configurable options is the heartbeat timeout.  

## Installation
You can find the compiled version in [releases](https://github.com/rbicelli/usb-watchdog-control/releases)

## Requirements
USBWatchdogControl is written in C#, using Sharpdevelop.

Requires .NET Framework 3.5

I used these two libs taken directly from nuGet: 
* [HidSharp](https://www.zer7.com/software/hidsharp)
* [INIFileParser](https://github.com/rickyah/ini-parser)

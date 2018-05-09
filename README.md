# USB Watchdog Control

This is the Opensource implementation of the USB watchdog program which comes with USB watchdog used in mining rigs.
Tried and tested with the USB_WDG_V3.1.

## Features
The program sits in System tray and sends heartbeat to USB device. The device detection is automatic. The only configurable options is the heartbeat timeout.  

## Requirements
USBWatchdogControl is written in C#, using Sharpdevelop.

Requires .NET Framework 3.5

I used these two libs taken directly from nuGet: 
* [HidSharp](https://www.zer7.com/software/hidsharp)
* [INIFileParser](https://github.com/rickyah/ini-parser)

## Buy me a Beer ;)
If you want to buy me a beer my XMR address is: 46un6TXVK5NF4y8URSXmMLasH9D1dnn4R3bxKFxQALk63d1EUQtECanPE9JaMUTAS7Bste12BVqE72WpTbXmweJhFspKHMg
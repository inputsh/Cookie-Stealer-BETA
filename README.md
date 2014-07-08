Cookie-Stealer
==============

Works with Firefox, Chrome and Opera on Windows operating systems. Tested only on Windows 8.1.

The code is meant to move on an portable USB stick. Running .exe from debug folder will do the following:
* Detect the USB letter.
* Detect the default browser.
* Navigate to a folder where default browser stores cookie file.
* Copy cookie file to a USB stick in the Data folder.

NOTE: It's a console application so the job will be done automatically in a command prompt. User does not have to do anything except running the .exe file.

Things to do:
* Implement support for IE.
* Test it on older version of Windows operating system.
* Moving implementations for different browsers to a separate functions instead of Form.Load event where they are now.

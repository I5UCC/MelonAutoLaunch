# MelonAutoLaunch
A universal melonloader mod that automatically launches and closes specified external programs with the game. 
Useful if you for example have alot of OSC programs for VRChat that you would otherwise have to open and close manually every time.

### Please be aware that usage of mods breaks ToS of games like VRChat and can lead to ban. Use at your own risk.

# Known Issues

- Programs that are not closed when quit will cause Steam to think the game is still running.

# Usage
To add a program to your Autolaunch, you need to edit the [GameFolder]/UserData/AutoStartConfig.json file. This file is being generated right when you start the game with the mod installed for the first time. <br>
It looks as follows: 
```
{
  "ProgramList": [
    {
      "FilePath": "",
      "Arguments": "",
      "StartMinimized": false,
      "CloseOnQuit": false,
      "VROnly": true
    }
  ]
}
```
***"FilePath":*** You need to add the **full path** to executable (.exe file) <br>
***"Arguments":*** if you need any, can leave empty.  <br>
***"WorkingDirectory":*** is the directory of your executable by default, add a path here if needed.  <br>
***"CloseOnQuit":*** determines if the program should close whenever the game is closed. Values are either false or true.  <br>
***"VROnly":*** determines if the program should be autostarted only in VR or always. Values are either false or true.

### Example:

```
{
  "ProgramList": [
    {
      "FilePath": "path/to/executable1",
      "Arguments": "",
      "StartMinimized": false,
      "CloseOnQuit": false,
      "VROnly": true
    },
    {
      "FilePath": "path/to/executable2",
      "Arguments": "",
      "StartMinimized": true,
      "CloseOnQuit": true,
      "VROnly": false
    },
    {
      "FilePath": "path/to/executable3",
      "Arguments": "--debug",
      "StartMinimized": false,
      "CloseOnQuit": true,
      "VROnly": true
    }
  ]
}
```

### MelonLoader
Need to install MelonLoader?<br>
Click [this link](https://melonwiki.xyz/#/?id=automated-installation) to get started!

### Prerequisites
MelonLoader: v0.5.4<br>

# MelonAutoLaunch
A universal melonloader mod that automatically launches specified external programs on startup of the game.

Please be aware that usage of mods breaks ToS of games like VRChat and can lead to ban. Use at your own risk.

# Current Issues

- CloseOnQuit programs close every time Melonpreferences are saved instead of every time the application is closed. 
  - OnApplicationQuit() doesnt seem to be called when the application is closed.

# Usage
To add a program to your Autolaunch, you need to edit the [GameFolder]/UserData/AutoStartConfig.json file. This file is being generated right when you start the game with the mod installed for the first time. <br>
It looks as follows: 
```
{
  "ProgramList": [
    {
      "FilePath": "",
      "Arguments": "",
      "WorkingDirectory": "",
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
      "WorkingDirectory": "",
      "CloseOnQuit": false,
      "VROnly": true
    },
    {
      "FilePath": "path/to/executable2",
      "Arguments": "",
      "WorkingDirectory": "path/to/Working/Directory2",
      "CloseOnQuit": true,
      "VROnly": false
    },
    {
      "FilePath": "path/to/executable3",
      "Arguments": "--debug",
      "WorkingDirectory": "path/to/Working/Directory3",
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

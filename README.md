# MelonAutoLaunch
A universal melonloader mod that automatically launches specified external programs on startup of the game.

# Usage
To add a program to your Autolaunch, you need to edit the VRChat/UserData/AutoStartConfig.json file. This file is being generated right when you start VRChat with the mod installed for the first time.
It uses following syntax:
```
{
  "ProgramList": [
    {
      "FilePath": "",
      "Arguments": "",
      "WorkingDirectory": "",
      "CloseOnQuit": false
    }
  ]
}
```
You need to add the ***full path*** to executable (.exe file) to "FilePath" <br>
Arguments, if you have anyone, can leave empty.
WorkingDirectory is the directory of your executable by default, add a path here if needed.
CloseOnQuit determines if the program should close whenever the game is closed. Values are either false or true.

### Example:

```
{
  "ProgramList": [
    {
      "FilePath": "path/to/executable1",
      "Arguments": "",
      "WorkingDirectory": "",
      "CloseOnQuit": false
    },
    {
      "FilePath": "path/to/executable2",
      "Arguments": "",
      "WorkingDirectory": "path/to/Working/Directory2",
      "CloseOnQuit": true
    },
    {
      "FilePath": "path/to/executable3",
      "Arguments": "--debug",
      "WorkingDirectory": "path/to/Working/Directory3",
      "CloseOnQuit": true
    }
  ]
}
```

### MelonLoader
Need to install MelonLoader?<br>
Click [this link](https://melonwiki.xyz/#/?id=automated-installation) to get started!

### Prerequisites
MelonLoader: v0.5.4+<br>

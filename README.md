# MelonAutoLaunch
A universal melonloader mod that automatically launches specified external programs on startup of the game.

# Usage
To add a program to your Autolaunch, you need to edit the [GameFolder]/UserData/AutoStartConfig.json file. This file is being generated right when you start the game with the mod installed for the first time.
It looks as follows: <br>
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
***"FilePath":*** You need to add the **full path** to executable (.exe file) <br>
***"Arguments":*** if you need any, can leave empty.  <br>
***"WorkingDirectory":*** is the directory of your executable by default, add a path here if needed.  <br>
***"CloseOnQuit":*** determines if the program should close whenever the game is closed. Values are either false or true.  <br>

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

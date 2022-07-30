using MelonLoader;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using UnityEngine.XR;

namespace MelonAutoLaunch
{
    public class Main : MelonMod
    {
        internal static readonly MelonLogger.Instance mlog = new MelonLogger.Instance("MelonAutoLaunch", ConsoleColor.DarkGreen);
        private static readonly string ConfigPath = $"{Environment.CurrentDirectory}{System.IO.Path.DirectorySeparatorChar}UserData{System.IO.Path.DirectorySeparatorChar}AutoStartConfig.json";
        private List<Process> ProcessesCloseOnQuit = new List<Process>();

        public override void OnApplicationLateStart()
        {
            try { CheckIfConfigFileExists(); } catch (Exception e) { mlog.Error(e); }

            Programs programs = JsonConvert.DeserializeObject<Programs>(File.ReadAllText(ConfigPath));

            foreach (ProgramInfo p in programs.ProgramList)
            {
                Process current = null;
                if (p.VROnly && IsOnVR() || !p.VROnly)
                    current = RunProgram(p);
                else
                    mlog.Msg(ConsoleColor.Yellow, String.Format("not launching {0}, it is tagged VR Only.", p.FilePath));

                if (p.CloseOnQuit && current != null)
                    ProcessesCloseOnQuit.Add(current);
            }
        }

        public override void OnApplicationQuit()
        {
            if(ProcessesCloseOnQuit.Count != 0)
            {
                mlog.Msg("Application Quitting... Closing Programs...");
                foreach (Process p in ProcessesCloseOnQuit)
                    CloseProgram(p);
            }
        }

        private static void CheckIfConfigFileExists()
        {
            if (!File.Exists(ConfigPath))
            {
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new Programs
                {
                    ProgramList = new List<ProgramInfo> {
                        new ProgramInfo {
                            FilePath = string.Empty,
                            Arguments = string.Empty,
                            StartMinimized = false,
                            CloseOnQuit = false,
                            VROnly = true
                        }
                    }
                }, Formatting.Indented));
            }
        }

        private Process RunProgram(ProgramInfo pInfo)
        {
            ProcessStartInfo pSInfo;
            FileInfo fInfo;

            if (!File.Exists(pInfo.FilePath))
            {
                if (pInfo.FilePath == "")
                    mlog.Warning("MelonAutoLaunch hasnt been set up yet! Configure it in the [GameFolder]/UserData/AutoStartConfig.json file. For more info look into the Github Repository https://github.com/I5UCC/MelonAutoLaunch");
                else
                    mlog.Warning(String.Format("File '{0}' does not exist!", pInfo.FilePath));
            }
            else
            {
                fInfo = new FileInfo(pInfo.FilePath);
                pSInfo = new ProcessStartInfo
                {
                    Arguments = pInfo.Arguments,
                    WorkingDirectory = fInfo.Directory.ToString(),
                    FileName = fInfo.Name,
                    WindowStyle = pInfo.StartMinimized ? ProcessWindowStyle.Minimized : ProcessWindowStyle.Normal
                };

                mlog.Msg(String.Format("Launching {0} in {1}", pSInfo.FileName, pSInfo.WorkingDirectory));
                try { return Process.Start(pSInfo); } catch (Exception e) { mlog.Error(e); }
            }
            return null;
        }

        private void CloseProgram(Process p)
        {
            mlog.Msg("Closing " + p.ProcessName);
            try
            {
                foreach (Process process in Process.GetProcessesByName(p.ProcessName)) // Close all associated Processes
                    process.CloseMainWindow();
            }
            catch (InvalidOperationException)
            {
                mlog.Msg(ConsoleColor.Yellow, "Process already closed.");
            }
            catch (Exception e) { mlog.Error(e); }
        }

        private bool IsOnVR()
        {
            try
            {
                return !Environment.CommandLine.Contains("no-vr") || XRDevice.isPresent;
            }
            catch (Exception)
            {
                mlog.Msg(ConsoleColor.Yellow, "No VR Device Detected, assuming its a non-VR game.");
                return false;
            }
        }
    }

    public class Programs
    {
        public List<ProgramInfo> ProgramList { get; set; }
    }

    public class ProgramInfo
    {
        public string FilePath { get; set; }
        public string Arguments { get; set; }
        public bool StartMinimized { get; set; }
        public bool CloseOnQuit { get; set; }
        public bool VROnly { get; set; }
    }
}

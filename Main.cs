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
        private bool isOnVR;
        private bool isIntitialized;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (buildIndex != 0 && !isIntitialized)
            {
                isOnVR = XRDevice.isPresent;

                try { CheckIfConfigFileExists(); } catch (Exception e) { mlog.Error(e); }

                Programs programs = JsonConvert.DeserializeObject<Programs>(File.ReadAllText(ConfigPath));

                foreach (ProgramInfo p in programs.ProgramList)
                {
                    Process current = null;
                    if (p.VROnly && isOnVR || !p.VROnly)
                        current = RunProgram(p.FilePath.Replace("/", "\\"), p.Arguments, p.WorkingDirectory);
                    else
                        mlog.Msg(String.Format("not launching {0}, it is tagged VR Only.", p.FilePath));

                    if (p.CloseOnQuit && current != null)
                        ProcessesCloseOnQuit.Add(current);
                }
                isIntitialized = true;
            }
        }

        public override void OnPreferencesSaved()
        {
            mlog.Msg("Closing Programs...");
            foreach (Process p in ProcessesCloseOnQuit)
            {
                try {
                    mlog.Msg("Closing " + p.ProcessName);
                    p.CloseMainWindow();
                } catch (InvalidOperationException e) { mlog.Warning("Process already closed."); 
                } catch (Exception e) { mlog.Error(e); }
            }
        }

        public static void CheckIfConfigFileExists()
        {
            if (!File.Exists(ConfigPath))
            {
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new Programs
                {
                    ProgramList = new List<ProgramInfo> {
                        new ProgramInfo {
                            FilePath = "",
                            Arguments = "",
                            WorkingDirectory = "",
                            CloseOnQuit = false,
                            VROnly = true
                        }
                    }
                }, Formatting.Indented));
            }
        }

        private Process RunProgram(string filePath, string arguments, string workingDirectory)
        {
            ProcessStartInfo pInfo;
            FileInfo fInfo;


            if (!File.Exists(filePath))
            {
                mlog.Warning(String.Format("File '{0}' does not exist!", filePath));
            }
            else
            {
                fInfo = new FileInfo(filePath);
                pInfo = new ProcessStartInfo
                {
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory != "" ? workingDirectory : fInfo.Directory.ToString(),
                    FileName = fInfo.Name,
                    UseShellExecute = true
                };
                mlog.Msg(String.Format("Launching {0} in {1}", pInfo.FileName, pInfo.WorkingDirectory));
                try { return Process.Start(pInfo); } catch (Exception e) { mlog.Error(e); }
            }
            return null;
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
        public string WorkingDirectory { get; set; }
        public bool CloseOnQuit { get; set; }
        public bool VROnly { get; set; }
    }
}

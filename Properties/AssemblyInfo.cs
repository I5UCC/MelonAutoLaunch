using System.Reflection;
using MelonLoader;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("MelonAutoLaunch")]
[assembly: AssemblyDescription("Automatically launches specified External Programs on startup of the game.")]
[assembly: AssemblyProduct("MelonAutoLaunch")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: ComVisible(false)]
[assembly: Guid("3e346bcb-8bc0-407a-a43a-8cd14b2e312e")]
[assembly: AssemblyVersion("1.1.1")]
[assembly: AssemblyFileVersion("1.1.1")]
[assembly: MelonInfo(typeof(MelonAutoLaunch.Main), "MelonAutoLaunch", "1.1.1", "I5UCC")]
[assembly: MelonGame(null, null)]
[assembly: MelonOptionalDependencies("UnityEngine.VRModule")]
[assembly: MelonPriority(int.MinValue)]
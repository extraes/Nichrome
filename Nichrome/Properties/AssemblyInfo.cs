using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(Nichrome.NichromeBuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(Nichrome.NichromeBuildInfo.Company)]
[assembly: AssemblyProduct(Nichrome.NichromeBuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Nichrome.NichromeBuildInfo.Author)]
[assembly: AssemblyTrademark(Nichrome.NichromeBuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(Nichrome.NichromeBuildInfo.Version)]
[assembly: AssemblyFileVersion(Nichrome.NichromeBuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(Nichrome.NichromeMain), Nichrome.NichromeBuildInfo.Name, Nichrome.NichromeBuildInfo.Version, Nichrome.NichromeBuildInfo.Author, Nichrome.NichromeBuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
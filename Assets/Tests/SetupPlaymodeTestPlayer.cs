using System.IO;
using UnityEditor;
using UnityEditor.TestTools;
using UnityEngine.TestTools;

[assembly: TestPlayerBuildModifier(typeof(SetupPlaymodeTestPlayer))]

public class SetupPlaymodeTestPlayer : ITestPlayerBuildModifier
{
    public BuildPlayerOptions ModifyOptions(BuildPlayerOptions playerOptions)
    {
        playerOptions.options &= ~(BuildOptions.AutoRunPlayer | BuildOptions.ConnectToHost);

        var buildLocation = Path.GetFullPath("TestPlayers");
        var fileName = Path.GetFileName(playerOptions.locationPathName);
        if (!string.IsNullOrEmpty(fileName))
            buildLocation = Path.Combine(buildLocation, fileName);

        playerOptions.locationPathName = buildLocation;
        return playerOptions;
    }
}

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using ChillyRoom.UnityEditor.iOS.Xcode;

public class PostProcess: MonoBehaviour
{
    [PostProcessBuildAttribute(9999)]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        if (target == BuildTarget.iOS)
        {
            OnIOSBuild(target, path);
        }
    }

    private static void OnIOSBuild(BuildTarget target, string path)
    {
        NativeLocale.AddLocalizedStringsIOS(path, Path.Combine(Application.dataPath, "NativeLocale/iOS"));
    }
}

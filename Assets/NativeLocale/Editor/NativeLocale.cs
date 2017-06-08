using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using ChillyRoom.UnityEditor.iOS.Xcode;

public class NativeLocale
{
    public static void AddLocalizedStringsIOS(string projectPath, string localizedDirectoryPath)
    {        
        DirectoryInfo dir = new DirectoryInfo(localizedDirectoryPath);
        if(!dir.Exists)
            return;

        List<string> locales = new List<string>();
        var localeDirs = dir.GetDirectories("*.lproj", SearchOption.TopDirectoryOnly);

        foreach(var sub in localeDirs)
            locales.Add(Path.GetFileNameWithoutExtension(sub.Name));

        AddLocalizedStringsIOS(projectPath, localizedDirectoryPath, locales);
    }

    public static void AddLocalizedStringsIOS(string projectPath, string localizedDirectoryPath, List<string> validLocales)
    {
        string projPath = projectPath + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);

        foreach(var locale in validLocales)
        {
            // copy contents in the localization directory to project directory
            string src = Path.Combine(localizedDirectoryPath, locale + ".lproj");
            DirectoryCopy(src, Path.Combine(projectPath, "Unity-iPhone/" + locale + ".lproj"));

            string fileRelatvePath = string.Format("Unity-iPhone/{0}.lproj/InfoPlist.strings", locale);
            proj.AddLocalization("InfoPlist.strings", locale, fileRelatvePath);
        }

        proj.WriteToFile(projPath);
    }


    private static void DirectoryCopy(string sourceDirName, string destDirName)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
            return;

        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            // skip unity meta files
            if(file.FullName.EndsWith(".meta"))
                continue;
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            string temppath = Path.Combine(destDirName, subdir.Name);
            DirectoryCopy(subdir.FullName, temppath);
        }
    }
}

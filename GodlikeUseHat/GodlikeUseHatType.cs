﻿using Patchwork;
using Patchwork.AutoPatching;
using System.IO;
using System.Linq;


[assembly: PatchAssembly]
[PatchInfo]
public class GodlikeUseHatType : IPatchInfo
{

    public GodlikeUseHatType()
    {
    }

    public static string Combine(params string[] paths)
    {
        var current = paths.Aggregate(@"", Path.Combine);
        return current;
    }

    public FileInfo GetTargetFile(AppInfo app)
    {
        var file = Combine(app.BaseDirectory.FullName, "PillarsOfEternityII_Data", "Managed", "Assembly-CSharp.dll");
        FileInfo info = new FileInfo(file);
        return info;
    }

    public string CanPatch(AppInfo app)
    {
        return null;
    }

    public string PatchVersion { get { return "1.0.0"; } }
    public string Requirements { get { return "None"; } }
    public string PatchName { get { return "Allow Godlikes to use hats"; } }
}


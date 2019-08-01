

using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using UnityEditor.iOS.Xcode;
using System.IO;
 
// https://forum.unity.com/threads/how-to-disable-the-filtering-of-emoji-characters.399028/
public class XcodePostProcessSteps {
 
    // A post process step to modify the generated Xcode project.
    [PostProcessBuild]
    public static void DisableEmojiFilter(BuildTarget buildTarget, string pathToBuiltProject) {
 
        // Only continue if we're building for iOS
        if (buildTarget == BuildTarget.iOS) {
 
            // Get Xcode project
            string pbxprojPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
            PBXProject proj = new PBXProject();
            proj.ReadFromString(File.ReadAllText(pbxprojPath));
 
            string target = proj.TargetGuidByName("Unity-iPhone");
            proj.SetBuildProperty(target, "GCC_PREPROCESSOR_DEFINITIONS", "HAVE_INTTYPES_H HAVE_PKCRYPT HAVE_STDINT_H HAVE_WZAES HAVE_ZLIB MZ_ZIP_NO_SIGNING $(inherited)");
 
            proj.AddFrameworkToProject(target, "Security.framework", false);
            proj.AddFileToBuild(target, proj.AddFile ("usr/lib/libiconv.2.tbd", "libiconv.2.tbd", PBXSourceTree.Sdk));
            proj.AddFileToBuild(target, proj.AddFile("usr/lib/libz.tbd", "libz.tbd", PBXSourceTree.Sdk));
            proj.AddBuildProperty(target, "GCC_ENABLE_OBJC_EXCEPTIONS", "YES");
            
            // Write changes to the Xcode project
            File.WriteAllText(pbxprojPath, proj.WriteToString());
        }
    }
}
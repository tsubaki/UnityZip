using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;

public class ZipUtil
{
#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern void unzip (string zipFilePath, string location);

	[DllImport("__Internal")]
	private static extern void zip (string zipFilePath);

	[DllImport("__Internal")]
	private static extern void addZipFile (string addFile);

#endif

	public static void Unzip (string zipFilePath, string location)
	{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
        if (!location.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            location += Path.DirectorySeparatorChar;
        
        Directory.CreateDirectory(location);

        using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string fullPath = Path.Combine(location, entry.FullName);

                if (string.IsNullOrEmpty(entry.Name))
                    System.IO.Directory.CreateDirectory(fullPath);
                else
                    entry.ExtractToFile(fullPath, true);
            }
        }

#elif UNITY_ANDROID
		using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
			zipper.CallStatic ("unzip", zipFilePath, location);
		}
#elif UNITY_IPHONE
		unzip (zipFilePath, location);
#endif
	}

	public static void Zip (string zipFileName, params string[] files)
	{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
		string path = Path.GetDirectoryName(zipFileName);
		Directory.CreateDirectory (path);

        // todo
        // System.IO.Compression.ZipFile.ExtractToDirectory(srcPath, destPath);

        
		// using (ZipFile zip = new ZipFile()) {
		// 	foreach (string file in files) {
		// 		zip.AddFile(file, "");
		// 	}
		// 	zip.Save (zipFileName);
		// }
#elif UNITY_ANDROID
		using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
			{
				zipper.CallStatic ("zip", zipFileName, files);
			}
		}
#elif UNITY_IPHONE
		foreach (string file in files) {
			addZipFile (file);
		}
		zip (zipFileName);
#endif
	}
}

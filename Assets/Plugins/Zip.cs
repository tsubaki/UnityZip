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

        if (files.Length > 0)
        {
            if (File.Exists(files[0]))
            {
                // Get the first file in the list so we can get the root directory
                string strRootDirectory = Path.GetDirectoryName(files[0]);

                // Set up a temporary directory to save the files to (that we will eventually zip up)
                DirectoryInfo dirTemp = Directory.CreateDirectory(strRootDirectory + "/" + DateTime.Now.ToString("yyyyMMddhhmmss"));

                // Copy all files to the temporary directory
                foreach (string strFilePath in files)
                {
                    if (!File.Exists(strFilePath))
                    {
                        throw new Exception(string.Format("File {0} does not exist", strFilePath));
                    }
                    string strDestinationFilePath = Path.Combine(dirTemp.FullName, Path.GetFileName(strFilePath));
                    File.Copy(strFilePath, strDestinationFilePath);
                }

                // Create the zip file using the temporary directory
                if (!zipFileName.EndsWith(".zip")) { zipFileName += ".zip"; }
                string strZipPath = Path.Combine(strRootDirectory, zipFileName);
                if (File.Exists(strZipPath)) { File.Delete(strZipPath); }
                ZipFile.CreateFromDirectory(dirTemp.FullName, strZipPath, System.IO.Compression.CompressionLevel.Fastest, false);

                // Delete the temporary directory
                dirTemp.Delete(true);                
            }
            else
            {
                throw new Exception(string.Format("File {0} does not exist", files[0]));
            }
        }
        else
        {
            throw new Exception("You must specify at least one file to zip.");
        }

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

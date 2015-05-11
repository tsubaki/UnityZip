using UnityEngine;
using System.Collections;
using System.IO;

public class ZipUnzipSample : MonoBehaviour
{
	[SerializeField]
	string baseDirectryPath = "ZipPath";

	[SerializeField]
	string zipName = "zipfiles.zip";

	[SerializeField]
	string[] files =
	{
		"Images/twitter_icon1.png",
		"Images/twitter_icon2.png",
		"Images/twitter_icon3.png",
	};

	string zipPath {
		get {
			Directory.CreateDirectory (baseDirectryPath);
			return Path.Combine (baseDirectryPath, zipName);
		}
	}

	public void Zip ()
	{
		foreach( var file in files ){
			if( File.Exists( file ) == false ){
				Debug.LogError(file + "is not found!");
				System.Diagnostics.Process.Start(Path.GetDirectoryName(file));
				return;
			}
		}

		ZipUtil.Zip (zipPath, files);
		System.Diagnostics.Process.Start(Path.GetDirectoryName(zipPath));
	}
	
	public void Unzip ()
	{
		if( File.Exists( zipPath ) == false ){
			Debug.LogError(zipPath + "is not found!");
			System.Diagnostics.Process.Start(Path.GetDirectoryName(zipPath));
			return;
		}

		ZipUtil.Unzip (zipPath, baseDirectryPath);
		System.Diagnostics.Process.Start(Path.GetDirectoryName(zipPath));
	}

	public void OpenDir()
	{
		Directory.CreateDirectory(baseDirectryPath);
		System.Diagnostics.Process.Start(baseDirectryPath);
	}
}

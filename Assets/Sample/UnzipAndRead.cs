using UnityEngine;
using System.Collections;
using System.IO;

public class UnzipAndRead : MonoBehaviour {


	void OnGUI()
	{
		if( GUI.Button(new Rect(0, 0, 100, 100), "load") )
		{
			StartCoroutine(Load());
		}
	}

	IEnumerator Load()
	{
		WWW www = new WWW("https://dl.dropboxusercontent.com/u/56297224/twitter_icon.png.zip");

		yield return www;

		var data = www.bytes;
		string zipPath = Application.temporaryCachePath + "/tempZip.zip";
		string exportPath = Application.temporaryCachePath + "/unzip";
		File.WriteAllBytes(zipPath, data);

		ZipUtil.Unzip(zipPath, exportPath);


		var tex =  new Texture2D(1, 1);

	 	var imageData = File.ReadAllBytes(exportPath + "/twitter_icon.png");
		tex.LoadImage(imageData);

		GetComponent<UnityEngine.UI.RawImage>().texture = tex;
	}
}

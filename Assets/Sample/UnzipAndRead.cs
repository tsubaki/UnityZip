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
		string zipPath = Application.temporaryCachePath + "/tempZip.zip";
		string exportPath = Application.temporaryCachePath + "/unzip";
		string imagePath = exportPath + "/twitter_icon.png";

		WWW www = new WWW("https://dl.dropboxusercontent.com/u/56297224/twitter_icon.png.zip");

		yield return www;

		var data = www.bytes;
		File.WriteAllBytes(zipPath, data);
		ZipUtil.Unzip(zipPath, exportPath);

		var tex =  new Texture2D(1, 1);

	 	var imageData = File.ReadAllBytes(imagePath);
		tex.LoadImage(imageData);

		GetComponent<UnityEngine.UI.RawImage>().texture = tex;

		File.Delete(zipPath);
		Directory.Delete(exportPath, true);
	}
}

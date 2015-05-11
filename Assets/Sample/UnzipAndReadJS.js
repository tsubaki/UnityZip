#pragma strict
import  System.IO;

function OnGUI()
{
	if( GUI.Button(Rect(0, 0, 100, 100), "load") )
	{
		StartCoroutine(Load());
	}
}

function Load()
{
	var zipPath  = Application.temporaryCachePath + "/tempZip.zip";
	var exportPath = Application.temporaryCachePath + "/unzip";
	var imagePath = exportPath + "/twitter_icon.png";

	var www = new WWW("https://dl.dropboxusercontent.com/u/56297224/twitter_icon.png.zip");

	yield www;

	var data = www.bytes;
	File.WriteAllBytes(zipPath, data);
	ZipUtil.Unzip(zipPath, exportPath);

	var tex =  new Texture2D(1, 1);

 	var imageData = File.ReadAllBytes(imagePath);
	tex.LoadImage(imageData);

	GetComponent.<UnityEngine.UI.RawImage>().texture = tex;

	File.Delete(zipPath);
	Directory.Delete(exportPath, true);
}
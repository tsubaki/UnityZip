using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void Zip()
    {
        string exportZip = Application.temporaryCachePath + "/args.zip";
        string[] files = new string[] { Application.dataPath + "/Example/Resources/args.txt" };
        
        ZipUtil.Zip(exportZip, files);
    }
    
    public void Unzip()
    {
        string zipfilePath = Application.temporaryCachePath + "/args.zip";
        string exportLocation = Application.temporaryCachePath + "/dir";

        ZipUtil.Unzip(zipfilePath, exportLocation);
    }

}

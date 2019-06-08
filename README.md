# UniZip

UniZip is zipper for unity3d.

![unity zip](https://github.com/rumaniel/UnityZip/blob/master/logo.jpg)

## Getting Started

Copy all items from the Assets/Plugins folder to your Unity3d Assets/Plugins folder.

## supported

-  iOS.
-  Android.
-  Standalone(Includes Mac and Windows)

## example

### unzip

```C#
string zipfilePath = Application.temporaryCachePath + "/args.zip";
string exportLocation = Application.temporaryCachePath + "/dir";

ZipUtil.Unzip(zipfilePath, exportLocation);
```

### zip

```C#
string exportZip = Application.temporaryCachePath + "/args.zip";
string[] files = new string[] { Application.dataPath + "/Example/Resources/args.txt" };

ZipUtil.Zip(exportZip, files);
```

## TODO

- [ ] Support async zip/unzip
- [ ] Inform progress while async job
- [ ] Inform result
- [ ] Support password
- [ ] Submit assetstore
- [ ] Directory support

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* It's inspired of [SSZipArchive](https://github.com/ZipArchive/ZipArchive).


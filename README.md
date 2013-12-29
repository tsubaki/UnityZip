UnityZip
========

UnityZip is zipper for unity3d.

#supported

-  iOS
-  Android
-  Mac.

#required

- .NET 2.0.

#example

-unzip

```
string zipfilePath = Application.temporaryCachePath + "/args.zip"
string exportLocation = Application.temporaryCachePath + "/dir"

ZipUtil.Unzip ( zipfilePath, exportLocation);
```

-zip (android only yet)

```
string exportZip = Application.temporaryCachePath + "/dir/args.zip";
string[] files = new string[]{ Application.temporaryCachePath + "/dir/args.txt"}

ZipUtil.Zip (exportZip, files);
```
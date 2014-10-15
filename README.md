UniZip
========

UniZip is zipper for unity3d.

![unity zip](https://dl.dropboxusercontent.com/u/56297224/Images/unityzip%20rogo.jpg)

#supported

-  iOS.
-  Android.
-  Mac.and probably windows.

#iOS how to

1.  build project.
2.  add file "PluginsCode>iOS>ZipArchive" to xcode project.
3.  enjoy.

#example

-unzip

```
string zipfilePath = Application.temporaryCachePath + "/args.zip"
string exportLocation = Application.temporaryCachePath + "/dir"

ZipUtil.Unzip ( zipfilePath, exportLocation);
```

-zip

```
string exportZip = Application.temporaryCachePath + "/dir/args.zip";
string[] files = new string[]{ Application.temporaryCachePath + "/dir/args.txt"}

ZipUtil.Zip (exportZip, files);
```

#License

This software is released under the MIT License, see LICENSE.
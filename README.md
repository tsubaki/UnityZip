UniZip
========

UniZip is a zipper for unity3d.

![unity zip](https://githubcatw.github.io/unity_zip.jpg)

## Supported

-  iOS
-  Android
-  Mac
-  Probably Windows

## iOS how to

1.  Build project.
2.  Add file "PluginsCode>iOS>ZipArchive" to xcode project.
3.  enjoy.

## Example

Unzip:

```
string zipfilePath = Application.temporaryCachePath + "/args.zip"
string exportLocation = Application.temporaryCachePath + "/dir"

ZipUtil.Unzip ( zipfilePath, exportLocation);
```

Zip

```
string exportZip = Application.temporaryCachePath + "/dir/args.zip";
string[] files = new string[]{ Application.temporaryCachePath + "/dir/args.txt"}

ZipUtil.Zip (exportZip, files);
```

##  License

This software is released under the MIT License, see LICENSE.

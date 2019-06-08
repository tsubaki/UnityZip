UniZip
========

UniZip is zipper for unity3d.

![unity zip](https://github.com/rumaniel/UnityZip/blob/master/logo.jpg)

#supported

-  iOS.
-  Android.
-  Mac.and probably windows.

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
#TODO
- [ ] iOS zip
- [ ] support async zip/unzip
- [ ] inform progress while async job
- [ ] inform result
- [ ] support password
- [ ] submit assetstore
- [ ] Directry support

#License

This software is released under the MIT License, see LICENSE.

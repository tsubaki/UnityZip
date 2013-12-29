//
//  UnityZipFile.m
//  Unity-iPhone
//
//  Created by 山村 達彦 on 2013/12/29.
//
//
#import "ZipArchive.h"

extern "C"{
    void zip(const char*file) {
    }

    void addZipFile(const char*file)
    {
        
    }
    
    void unzip( char*file,  char* location)
    {
        NSString *zipPath =[NSString stringWithCString:file];
        NSString *destinationPath = [NSString stringWithCString:location];

        ZipArchive* za = [[ZipArchive alloc] init];
        if( [za UnzipOpenFile:zipPath] )
        {
            [za UnzipFileTo:destinationPath overWrite:YES];
            [za UnzipCloseFile];
        }
        [za release];
    }
    
}
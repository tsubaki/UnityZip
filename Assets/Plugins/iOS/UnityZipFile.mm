//
//  UnityZipFile.m
//  Unity-iPhone
//
//  Created by 山村 達彦 on 2013/12/29.
//  Modified by Ruman on 2019/06/07
//
#import "ZipArchive.h"

static NSMutableArray* list = nil;

extern "C"
{    
    void zip(const char*file) 
    {
        // todo
        // NSString *zipPath =[NSString stringWithUTF8String:file];
        
        // ZipArchive* zip = [[ZipArchive alloc] init];
        
        
        // [zip CreateZipFile2:zipPath];
        
        // for(int i=0; i<list.count; i++)
        // {
            
        //     NSString* filePath = [list objectAtIndex:i];
        //     NSString* fileName = [filePath lastPathComponent];
        //     [zip addFileToZip:filePath newname:fileName];
        // }
        
        // [zip CloseZipFile2];
        // [zip release];
        
        // [list removeAllObjects];
        // [list release];
        // list = nil;
    }
    
    void addZipFile(const char*file)
    {
        NSString *zipPath =[NSString stringWithUTF8String:file];
        
        if( list == nil){
            list = [[NSMutableArray alloc] init];
        }
        [list addObject: zipPath];
    }
    
    void unzip( char*file,  char* location)
    {
        NSString *zipPath =[NSString stringWithUTF8String:file];
        NSString *destinationPath = [NSString stringWithUTF8String:location];
        
        [SSZipArchive unzipFileAtPath:zipPath
                        toDestination:destinationPath
                    preserveAttributes:YES
                            overwrite:YES
                        nestedZipLevel:0
                            password:nil
                                error:nil
                            delegate:nil
                        progressHandler:nil
                    completionHandler:nil];

    }
}
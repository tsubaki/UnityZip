//
//  UnityZipFile.m
//  Unity-iPhone
//
//  Created by 山村 達彦 on 2013/12/29.
//
//
#import "ZipArchive.h"

static NSMutableArray* list = nil;

extern "C"{
    
    
    void zip(const char*file) {
        NSString *zipPath =[NSString stringWithCString:file];
        
        ZipArchive* zip = [[ZipArchive alloc] init];
        
        
        [zip CreateZipFile2:zipPath];
        
        for(int i=0; i<list.count; i++)
        {
            
            NSString* filePath = [list objectAtIndex:i];
            NSString* fileName = [filePath lastPathComponent];
            [zip addFileToZip:filePath newname:fileName];
        }
        
        [zip CloseZipFile2];
        [zip release];
        
        [list removeAllObjects];
        [list release];
        list = nil;
    }
    
    void addZipFile(const char*file)
    {
        NSString *zipPath =[NSString stringWithCString:file];
        
        if( list == nil){
            list = [[NSMutableArray alloc] init];
        }
        [list addObject: zipPath];
    }
    
    void unzip( char*file,  char* location)
    {
        NSString *zipPath =[NSString stringWithCString:file];
        NSString *destinationPath = [NSString stringWithCString:location];
        
        ZipArchive* zip = [[ZipArchive alloc] init];
        if( [zip UnzipOpenFile:zipPath] )
        {
            [zip UnzipFileTo:destinationPath overWrite:YES];
            [zip UnzipCloseFile];
        }
        [zip CloseZipFile2];
        [zip release];
    }
}
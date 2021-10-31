using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MyLab.CoreDTO.Models;

namespace MyLab.Core.Services
{
    public class FilesService : IFilesService
    {
        public FilesService()
        {
        }

        public async Task<List<MyFile>> ListFiles(string path)
        {
            List<MyFile> myFiles = new List<MyFile>();
            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles();
            //might take a while with large folder list
            await Task.Run(() =>
            {
                foreach (var file in files)
                {
                    //skip hidden files
                    if (file.Attributes.HasFlag(FileAttributes.Hidden)) continue;
                    MyFile myFile = new MyFile
                    {
                        CreationDate = file.CreationTimeUtc,
                        FileName = file.Name,
                        LastModifiedDate = file.LastAccessTimeUtc,
                        FileSize = file.Length
                    };
                    myFiles.Add(myFile);
                }
            });
            return myFiles;
        }
    }
}
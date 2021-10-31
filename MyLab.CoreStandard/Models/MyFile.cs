using System;
namespace MyLab.CoreDTO.Models
{
    public class MyFile
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}

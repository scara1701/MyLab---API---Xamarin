using System.Collections.Generic;
using System.Threading.Tasks;
using MyLab.CoreDTO.Models;

namespace MyLab.Core.Services
{
    public interface IFilesService
    {
        Task<List<MyFile>> ListFiles(string path);
    }
}
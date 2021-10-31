using System.Collections.Generic;
using System.Threading.Tasks;
using MyLab.CoreDTO.Models;

namespace MyLab.MobileClient.Services
{
    public interface IRestService
    {
        Task<List<MyFile>> GetFilesListAsync();
    }
}
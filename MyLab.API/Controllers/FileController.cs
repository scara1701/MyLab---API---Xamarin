using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyLab.Core.Services;
using MyLab.CoreDTO.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IFilesService _filesService;
        private readonly IConfiguration _configuration;

        public FileController(IFilesService filesService, IConfiguration configuration)
        {
            _filesService = filesService;
            _configuration = configuration;
        }
        // GET: /<controller>/
        public async Task<List<MyFile>> Index()
        {
            return await _filesService.ListFiles(_configuration["ListDirectory"]);
        }
    }
}

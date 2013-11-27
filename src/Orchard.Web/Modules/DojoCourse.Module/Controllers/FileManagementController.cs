using Orchard.FileSystems.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoCourse.Module.Controllers
{
    public class FileManagementController : Controller
    {
        private readonly IStorageProvider _storageProvider;


        public FileManagementController(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }


        public string Index()
        {
            //var file = _storageProvider.CreateFile("DojoCourse/textfile.txt");

            //using (var stream = file.OpenWrite())
            //using (var streamWriter = new StreamWriter(stream))
            //{
            //    streamWriter.Write("Hello file!");
            //}


            if (_storageProvider.FileExists("DojoCourse/textfile.txt"))
            {
                var file = _storageProvider.GetFile("DojoCourse/textfile.txt");

                using (var stream = file.OpenRead())
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }

            return "OK, but the file was not there";
        }
    }
}
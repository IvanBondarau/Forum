using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    interface IFileService
    {
        void SaveImage(File file, string path);
    }
}

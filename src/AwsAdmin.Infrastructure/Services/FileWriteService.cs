using AwsAdmin.Application.Common.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace AwsAdmin.Infrastructure.Services
{
    public class FileWriteService : IFileWriteService
    {
        public void AppendAllLines(string path, string fileName, IEnumerable<string> contents)
        {
            var pathCombine = PathCombine(path, fileName);
            File.AppendAllLines(pathCombine, contents);
        }

        public void AppendAllText(string path, string fileName, string contents)
        {
            var pathCombine = PathCombine(path, fileName);
            File.AppendAllText(pathCombine, contents);
        }

        private static string PathCombine(string path, string fileName)
        {
            return Path.Combine(path, fileName);
        }
    }
}

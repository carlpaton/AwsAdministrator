using Common.Interface;
using System;

namespace Common
{
    public class DirectoryService : IDirectoryService
    {
        public string BaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}

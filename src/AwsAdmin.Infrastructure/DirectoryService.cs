using AwsAdmin.Infrastructure.Interface;
using System;

namespace AwsAdmin.Infrastructure
{
    public class DirectoryService : IDirectoryService
    {
        public string BaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}

using AwsAdmin.Application.Common.Interfaces;
using System;

namespace AwsAdmin.Infrastructure.Services
{
    public class DirectoryService : IDirectoryService
    {
        public string BaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}

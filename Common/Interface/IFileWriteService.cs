﻿using System.Collections.Generic;

namespace Common.Interface
{
    public interface IFileWriteService
    {
        void AppendAllLines(string path, string fileName, IEnumerable<string> contents);
        void AppendAllText(string path, string fileName, string contents);
    }
}

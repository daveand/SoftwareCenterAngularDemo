using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareCenterWebApp.Models
{
    public class BlobModel
    {
        public BlobDetails File { get; set; }
        public BlobDetails Directory { get; set; }
    }

    public class BlobDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Length { get; set; }
        public string Parent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BlobServiceTest
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
        public string Length { get; set; }
        public string Parent { get; set; }
    }
}

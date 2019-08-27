using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;

namespace BlobServiceTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Azure Blob test");

            var blobs = ListFiles("");

            foreach (var blob in blobs)
            {
                if (blob.Directory != null)
                {
                    Console.WriteLine("Dir: " + blob.Directory.Name);
                    //Console.WriteLine("Dirpath: " + blob.Directory.Path);
                }
                if (blob.File != null)
                {
                    Console.WriteLine("File: " + blob.File.Name);
                    //Console.WriteLine("Filepath: " + blob.File.Path);


                }

            }
            Console.WriteLine();

        }

        static List<BlobModel> ListFiles(string path)
        {
            string _storageConnection = "DefaultEndpointsProtocol=https;AccountName=softwarecenter;AccountKey=5wng9uU71JnSWm6G7tkIXdfkIr4G+vyGouUl5r50Y3VSGDTUowiFFwhd/3VGkRlh+6BFOF3D3DqPDHcXfxOIzg==;EndpointSuffix=core.windows.net";
            string _container = "files";

            List<BlobModel> blobs = new List<BlobModel>();
            try
            {
                if (CloudStorageAccount.TryParse(_storageConnection, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(_container);
                    //Console.WriteLine("Path: " + path);

                    CloudBlobDirectory blobDirectory = container.GetDirectoryReference(path);

                    BlobResultSegment resultSegment = blobDirectory.ListBlobsSegmented(null);



                    foreach (IListBlobItem item in resultSegment.Results)
                    {
                        if (item.GetType() == typeof(CloudBlockBlob))
                        {
                            CloudBlockBlob blob = (CloudBlockBlob)item;
                            if( blob.Parent.Parent != null)
                            {
                                blobs.Add(new BlobModel
                                {
                                    File = new BlobDetails
                                    {
                                        Name = blob.Uri.Segments.Last(),
                                        Path = blob.Name,
                                        Parent = blob.Parent.Parent.Prefix
                                    }
                                });                              
                            } else
                            {
                                blobs.Add(new BlobModel
                                {
                                    File = new BlobDetails
                                    {
                                        Name = blob.Uri.Segments.Last(),
                                        Path = blob.Name,
                                        Parent = ""
                                    }
                                });

                            }
                        }
                        else if (item.GetType() == typeof(CloudPageBlob))
                        {
                            CloudPageBlob blob = (CloudPageBlob)item;
                            //blobs.Add(blob.Name);
                        }
                        else if (item.GetType() == typeof(CloudBlobDirectory))
                        {
                            CloudBlobDirectory dir = (CloudBlobDirectory)item;

                            if (dir.Parent.Parent != null)
                            {
                                blobs.Add(new BlobModel
                                {
                                    Directory = new BlobDetails
                                    {
                                        Name = System.Uri.UnescapeDataString(dir.Uri.Segments.Last()),
                                        Path = dir.Prefix,
                                        Parent = dir.Parent.Parent.Prefix
                                    }
                                });
                            } else
                            {
                                blobs.Add(new BlobModel
                                {
                                    Directory = new BlobDetails
                                    {
                                        Name = System.Uri.UnescapeDataString(dir.Uri.Segments.Last()),
                                        Path = dir.Prefix,
                                        Parent = ""
                                    }
                                });

                            }

                        }
                    }
                }
            }
            catch
            {
            }
            return blobs;
        }


    }
}

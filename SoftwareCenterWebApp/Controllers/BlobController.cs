using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Models;

namespace SoftwareCenterWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IOptions<AzureConfigModel> config;


        public BlobController(IOptions<AzureConfigModel> config)
        {
            this.config = config;
        }


        [HttpGet("ListFiles/{path}")]
        public async Task<List<BlobModel>> ListFiles(string path)
        {

            if (path == "null")
            {
                path = "";
            }
            else
            {
                path = path.Replace("^", "/");
            }

            List<BlobModel> blobs = new List<BlobModel>();
            try
            {
                if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(config.Value.Container);
                    //Console.WriteLine("Path: " + path);

                    CloudBlobDirectory blobDirectory = container.GetDirectoryReference(path);

                    BlobResultSegment resultSegment = await blobDirectory.ListBlobsSegmentedAsync(null);

                    foreach (IListBlobItem item in resultSegment.Results)
                    {
                        if (item.GetType() == typeof(CloudBlockBlob))
                        {
                            CloudBlockBlob blob = (CloudBlockBlob)item;
                            if (blob.Parent.Parent != null)
                            {
                                blobs.Add(new BlobModel
                                {
                                    File = new BlobDetails
                                    {
                                        Name = blob.Uri.Segments.Last(),
                                        Path = blob.Name,
                                        Length = blob.Properties.Length,
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
                                        Length = blob.Properties.Length,
                                        Parent = "null"
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
                                        Parent = "null"
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

        [HttpPost("InsertFile"), DisableRequestSizeLimit]
        public async Task<bool> InsertFile(IFormFile asset)
        {
            var files = Request.Form.Files;
            
            try
            {
                if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
                {

                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(config.Value.Container);

                    foreach (var file in files)
                    {
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                        await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            fileName = fileName.Replace("^", "/");

            MemoryStream ms = new MemoryStream();
            if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = BlobClient.GetContainerReference(config.Value.Container);

                if (await container.ExistsAsync())
                {
                    CloudBlob file = container.GetBlobReference(fileName);

                    if (await file.ExistsAsync())
                    {
                        await file.DownloadToStreamAsync(ms);
                        Stream blobStream = file.OpenReadAsync().Result;
                        return File(blobStream, file.Properties.ContentType, file.Name);
                    }
                    else
                    {
                        return Content("File does not exist");
                    }
                }
                else
                {
                    return Content("Container does not exist");
                }
            }
            else
            {
                return Content("Error opening storage");
            }
        }


        [Route("DeleteFile/{fileName}")]
        [HttpGet]
        public async Task<bool> DeleteFile(string fileName)
        {
            fileName = fileName.Replace("^", "/");

            try
            {
                if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = BlobClient.GetContainerReference(config.Value.Container);

                    if (await container.ExistsAsync())
                    {
                        CloudBlob file = container.GetBlobReference(fileName);

                        if (await file.ExistsAsync())
                        {
                            await file.DeleteAsync();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
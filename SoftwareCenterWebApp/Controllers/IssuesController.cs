using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Models;

namespace SoftwareCenterWebApp.Controllers
{

    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IMongoCollection<IssueModel> _issue;

        public IssuesController(IConfiguration configuration)
        {
            string host = "softwarecenterdb.documents.azure.com";
            string dbName = "swcenterdb";
            string userName = "softwarecenterdb";
            string password = "4UVtUt0XEKNT5juey97j96nCrmtAqK0KEQt2YRDBqIgHy6AxWULHDGBYp5rzF1ADiforuAT2leAzHjKRZbKzBw==";

            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            MongoClient client = new MongoClient(settings);


            //_issue = database.GetCollection<IssueModel>(configuration.GetValue<string>("MySettings:IssuesCollectionName"));


        }

        [HttpGet("[action]")]
        public List<IssueModel> Issues()
        {
            var result = _issue.Find(issue => true).ToList();
            Console.WriteLine(result);
            return result;
        }

    }

}
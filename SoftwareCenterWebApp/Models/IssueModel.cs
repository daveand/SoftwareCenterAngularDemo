using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Entities;

namespace SoftwareCenterWebApp.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Responsible { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
    }
}

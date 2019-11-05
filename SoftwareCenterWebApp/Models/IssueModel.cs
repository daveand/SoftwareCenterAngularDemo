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
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int? AgreementId { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Remedy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }

        public UserModel User { get; set; }
        public CustomerModel Customer { get; set; }
        public AgreementModel Agreement { get; set; }
        public ProductModel Product { get; set; }
    }
}

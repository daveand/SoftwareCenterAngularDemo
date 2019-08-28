using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCenterWebApp.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? AgreementId { get; set; }
        public int? ProductId { get; set; }
        public int? IssueId { get; set; }
        public int? KnowledgeId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Uploaded { get; set; }


        public CustomerModel Customer { get; set; }
        public AgreementModel Agreement { get; set; }
        public ProductModel Product { get; set; }
        public IssueModel Issue { get; set; }
        public KnowledgeModel Knowledge { get; set; }
        public UserModel User { get; set; }
    }
}

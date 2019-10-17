using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Files
    {
        public Files()
        {
            FavFiles = new HashSet<FavFiles>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? AgreementId { get; set; }
        public int? ProductId { get; set; }
        public int? IssueId { get; set; }
        public int? KnowledgeId { get; set; }
        public int UserId { get; set; }
        public DateTime Uploaded { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }

        public virtual Agreements Agreement { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Issues Issue { get; set; }
        public virtual Knowledges Knowledge { get; set; }
        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<FavFiles> FavFiles { get; set; }
    }
}

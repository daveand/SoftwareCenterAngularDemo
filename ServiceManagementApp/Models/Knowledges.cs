using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Knowledges
    {
        public Knowledges()
        {
            Files = new HashSet<Files>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? CustomerId { get; set; }
        public int? AgreementId { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
        public string Remedy { get; set; }
        public int? UserId { get; set; }

        public virtual Agreements Agreement { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Files> Files { get; set; }
    }
}

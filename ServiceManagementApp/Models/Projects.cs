using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Projects
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ProjectNumber { get; set; }
        public int UserId { get; set; }
        public string ProjectLeader { get; set; }
        public string SalesRep { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Status { get; set; }

        public virtual Users User { get; set; }
        public virtual Customers Customer { get; set; }

    }
}

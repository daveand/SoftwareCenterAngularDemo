using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCenterWebApp.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectNumber { get; set; }
        public string RespTech { get; set; }
        public string ProjectLeader { get; set; }
        public string SalesRep { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Files { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCenterWebApp.Models
{
    public class ActionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Responsible { get; set; }
        public int CustomerId { get; set; }
        public int AgreementId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DoneDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }

        public CustomerModel Customer { get; set; }
        public AgreementModel Agreement { get; set; }
        public ProductModel Product { get; set; }


    }
}

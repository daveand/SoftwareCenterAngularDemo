using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Actions = new HashSet<Actions>();
            CustomerContacts = new HashSet<CustomerContacts>();
            Files = new HashSet<Files>();
            Issues = new HashSet<Issues>();
            Knowledges = new HashSet<Knowledges>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Actions> Actions { get; set; }
        public virtual ICollection<CustomerContacts> CustomerContacts { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<Issues> Issues { get; set; }
        public virtual ICollection<Knowledges> Knowledges { get; set; }
    }
}

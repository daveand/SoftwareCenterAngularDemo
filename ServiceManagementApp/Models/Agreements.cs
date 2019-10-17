using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Agreements
    {
        public Agreements()
        {
            Actions = new HashSet<Actions>();
            Files = new HashSet<Files>();
            Issues = new HashSet<Issues>();
            Knowledges = new HashSet<Knowledges>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Actions> Actions { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<Issues> Issues { get; set; }
        public virtual ICollection<Knowledges> Knowledges { get; set; }
    }
}

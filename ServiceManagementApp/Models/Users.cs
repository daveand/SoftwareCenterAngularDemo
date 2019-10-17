using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class Users
    {
        public Users()
        {
            FavFiles = new HashSet<FavFiles>();
            Files = new HashSet<Files>();
            Issues = new HashSet<Issues>();
            Knowledges = new HashSet<Knowledges>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }

        public virtual ICollection<FavFiles> FavFiles { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<Issues> Issues { get; set; }
        public virtual ICollection<Knowledges> Knowledges { get; set; }
    }
}

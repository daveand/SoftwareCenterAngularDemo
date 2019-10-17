using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class FavFiles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FileId { get; set; }

        public virtual Files File { get; set; }
        public virtual Users User { get; set; }
    }
}

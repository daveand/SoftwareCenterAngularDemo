using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCenterWebApp.Models
{
    public class FavFilesModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FileId { get; set; }

        public UserModel User { get; set; }
        public FileModel File { get; set; }
    }
}

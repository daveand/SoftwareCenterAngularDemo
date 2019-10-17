using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceManagementApp.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<Issues> Issues { get; set; }
        public List<Actions> Actions { get; set; }
        public List<Projects> Projects { get; set; }

    }
}

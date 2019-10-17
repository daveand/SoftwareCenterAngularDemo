using System;
using System.Collections.Generic;

namespace ServiceManagementApp.Models
{
    public partial class CustomerContacts
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Customers Customer { get; set; }
    }
}

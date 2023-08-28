using System;
using System.Collections.Generic;

namespace CRUD_Project.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class ContactInformations
    {
        public int ContactInformationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

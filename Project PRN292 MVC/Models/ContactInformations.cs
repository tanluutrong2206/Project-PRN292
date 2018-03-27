using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN292_MVC.Models
{
    public partial class ContactInformations
    {
        public int ContactInformationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

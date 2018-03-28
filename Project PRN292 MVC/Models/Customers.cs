using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN292_MVC.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Blogs = new HashSet<Blogs>();
            Reviews = new HashSet<Reviews>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required, MaxLength(32), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public string DateCreated { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}

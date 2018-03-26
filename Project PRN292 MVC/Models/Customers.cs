using System;
using System.Collections.Generic;

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
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public string DateCreated { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}

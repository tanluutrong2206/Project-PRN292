using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class Blogs
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }
        public string ImageName
        {
            get { return ImageName; }
            set
            {
                ImageName = $"images/{value}";
            }
        }

        public Customers Author { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PRN292_MVC.Models
{
    public partial class Blogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }
        public string ImageName { get; set; }

        public Customers Author { get; set; }
    }
}

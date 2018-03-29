using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class About
    {
        public string Description { get; set; }
        public string ImageName {
            get { return ImageName; }
            set
            {
                ImageName = $"images/{value}";
            }
        }
        public int AboutId { get; set; }
    }
}

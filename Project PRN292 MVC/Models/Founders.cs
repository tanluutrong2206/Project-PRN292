using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class Founders
    {
        public string Name { get; set; }
        public string Quote { get; set; }
        public string ImageName {
            get { return ImageName; }
            set
            {
                ImageName = $"images/{value}";
            }
        }
        public string ContactLink { get; set; }
        public int FounderId { get; set; }
    }
}

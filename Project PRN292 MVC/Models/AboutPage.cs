using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN292_MVC.Models
{
    public class AboutPage
    {
        public About Abouts { get; set; }
        public IEnumerable<Founders> Founders { get; set; }
    }
}

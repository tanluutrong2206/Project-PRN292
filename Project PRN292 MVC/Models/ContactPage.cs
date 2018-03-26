using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN292_MVC.Models
{
    public class ContactPage
    {
        public IEnumerable<OpeningHours> OpeningHours { get; set; }
        public IEnumerable<ShopInformation> ShopInformation { get; set; }
        public ContactInformations ContactInformation { get; set; }
    }
}

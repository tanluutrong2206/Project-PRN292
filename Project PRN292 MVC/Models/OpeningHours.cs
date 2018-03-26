using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class OpeningHours
    {
        public string WeekDays { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public int Id { get; set; }
    }
}

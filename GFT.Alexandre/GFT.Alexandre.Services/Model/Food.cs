using GFT.Alexandre.Services.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.Alexandre.Services.Model
{
    public class Food
    {
        public string TimeOfDay { get; set; }
        public string FoodName { get; set; }
        public decimal CountOrder { get; set; }

        public bool MoreThanOne { get; set; }
    }
}

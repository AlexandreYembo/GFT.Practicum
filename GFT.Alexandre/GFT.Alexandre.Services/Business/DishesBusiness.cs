using GFT.Alexandre.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.Alexandre.Services.Business
{
    public class DishesBusiness
    {
        public List<Dishes> CreateOrder(List<Dishes> list)
        {
            list = list.OrderBy(p => Convert.ToInt32(p.Type)).ToList();
            foreach (var item in list)
            {
                item.AddList();
            }
            list = list.Distinct(new DishesTypeDistinct()).ToList();
            return list;
        }
    }
}

using GFT.Alexandre.Services.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.Alexandre.Services.Model
{
    public class Dishes
    {
        public EnumDishesType Type { get; set; }

        public List<Food> Foods
        {
            get;
            set;
        }

        public void AddList()
        {
            if (Foods == null)
            {
                Foods = new List<Food>();
            }
            switch (Type)
            {
                case EnumDishesType.entree:
                    Foods.Add(new Food
                    {
                        TimeOfDay = "morning",
                        FoodName = "eggs",
                        CountOrder = 1,
                    });
                    Foods.Add(new Food
                    {
                        TimeOfDay = "night",
                        FoodName = "steak",
                        CountOrder = 1,
                    });
                    break;

                case EnumDishesType.side:
                    Foods.Add(new Food
                    {
                        TimeOfDay = "morning",
                        FoodName = "Toast",
                        CountOrder = 1,
                    });
                    Foods.Add(new Food
                    {
                        TimeOfDay = "night",
                        FoodName = "potato",
                        CountOrder = 1,
                        MoreThanOne = true
                    });
                    break;
                case EnumDishesType.drink:
                    Foods.Add(new Food
                    {
                        TimeOfDay = "morning",
                        FoodName = "coffee",
                        CountOrder = 1,
                        MoreThanOne = true
                    });
                    Foods.Add(new Food
                    {
                        TimeOfDay = "night",
                        FoodName = "wine",
                        CountOrder = 1,
                    });
                    break;
                case EnumDishesType.dessert:
                    Foods.Add(new Food
                    {
                        TimeOfDay = "morning",
                        FoodName = "Error",
                        CountOrder = 1,
                    });
                    Foods.Add(new Food
                    {
                        TimeOfDay = "night",
                        FoodName = "cake",
                        CountOrder = 1,
                    });
                    break;
                default:
                    break;
            }
        }
    }

    public class DishesTypeDistinct : IEqualityComparer<Dishes>
    {
        public bool Equals(Dishes x, Dishes y)
        {
            if (x.Type == y.Type)
            {
                foreach (var item in x.Foods)
                {
                    if (item.MoreThanOne)
                    {
                        item.CountOrder += 1;
                    }
                }
            }
            return x.Type == y.Type;
        }

        public int GetHashCode(Dishes obj)
        {
            return obj.Type.GetHashCode();
        }
    }

}

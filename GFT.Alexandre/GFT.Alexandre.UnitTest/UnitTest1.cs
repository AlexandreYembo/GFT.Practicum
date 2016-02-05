using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFT.Alexandre.Services.Business;
using GFT.Alexandre.Services.Model;
using GFT.Alexandre.Services.Enumerables;
using System.Collections.Generic;
using System.Linq;


namespace GFT.Alexandre.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateOrder()
        {
            DishesBusiness business = new DishesBusiness();
            string valuesPar = "night,1,2,2";

            List<Dishes> listDishes = new List<Dishes>();

            string[] args = valuesPar.Split(',');
            for (int i = 1; i < args.Length; i++)
            {
                EnumDishesType result;
                Enum.TryParse(args[i].ToString().ToLower(), out result);
                if (result == EnumDishesType.dessert || result == EnumDishesType.drink || result == EnumDishesType.entree || result == EnumDishesType.side)
                {
                    listDishes.Add(new Dishes { Type = result });
                }
                else
                {
                    if (result != 0)
                    {
                        Assert.IsNull(listDishes, "Dados errados");
                    }
                }
            }
            listDishes = business.CreateOrder(listDishes);
            foreach (var item in listDishes)
            {
                if (item.Foods != null && item.Foods.Count > 0)
                {
                    foreach (var food in item.Foods.Where(p => p.TimeOfDay == args[0].ToString().ToLower()))
                    {
                        string message = food.FoodName;
                        if (food.CountOrder > 1)
                        {
                            message += string.Format("(x{0})", food.CountOrder);
                        }
                        Console.WriteLine(message);
                    }
                }
            }
        }
    }
}

using GFT.Alexandre.Services.Business;
using GFT.Alexandre.Services.Enumerables;
using GFT.Alexandre.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.Alexandre.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DishesBusiness business = new DishesBusiness();
                Console.WriteLine("Informe o seu pedido:");
                string valuesPar = Console.ReadLine();

                List<Dishes> listDishes = new List<Dishes>();

                string[] valuesSplit = valuesPar.Split(',');
                for (int i = 0; i < valuesSplit.Length; i++)
                {
                    EnumDishesType result;
                    Enum.TryParse(valuesSplit[i].ToString().ToLower(), out result);
                    if (result == EnumDishesType.dessert || result == EnumDishesType.drink || result == EnumDishesType.entree || result == EnumDishesType.side)
                    {
                        listDishes.Add(new Dishes { Type = result });
                    }
                    else
                    {
                        if (result != 0)
                        {
                            Console.WriteLine("Dados errados");
                        }
                    }
                }

                listDishes = business.CreateOrder(listDishes);
                Console.WriteLine("Resultado:");
                
                foreach (var item in listDishes)
                {
                    if (item.Foods != null && item.Foods.Count > 0)
                    {
                        foreach (var food in item.Foods.Where(p => p.TimeOfDay == valuesSplit[0].ToString().ToLower()))
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
                Main(args);
                System.Threading.Thread.Sleep(100000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main(args);
            }
        }
    }
}

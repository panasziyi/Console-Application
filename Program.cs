using System;
using System.Collections.Generic;

namespace oder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();

            AddNewDrink(drinks);

            DisplayDrinkMenu(drinks);

            PlaceOrder(orders, drinks);

            CalculatePrice(orders);
        }

        private static void CalculatePrice(List<OrderItem> myOrders)
        {
            double total = 0.0;
            double sellPrice = 0.0;
            string message = "";

            foreach (var orderitem in myOrders) total += orderitem.SubTotal;

            if (total >= 500)
            {
                message = "滿500元以上打8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "滿300元以上打85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "滿200元以上打9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "未滿200元不打折";
                sellPrice = total;
            }
            Console.WriteLine();
            Console.WriteLine($"總共訂購{myOrders.Count}項飲料，總計{total}元。{message}，合計需付款{Math.Round(sellPrice, 0, MidpointRounding.AwayFromZero)}元");
        }

        private static void PlaceOrder(List<OrderItem> myOrders, List<Drink> myDrinks)
        {
            Console.WriteLine("開始訂購飲料...輸入end結束訂購");
            string s;
            int index, quantity, subtotal;
            while (true)
            {
                Console.Write("請輸入所要訂購的品項編號: ");
                s = Console.ReadLine();
                if (s == "end") break;
                else index = Convert.ToInt32(s);

                Console.Write("請輸入所要的杯數: ");
                s = Console.ReadLine();
                if (s == "end") break;
                else quantity = Convert.ToInt32(s);

                Drink drink = myDrinks[index];
                subtotal = drink.Price * quantity;

                myOrders.Add(new OrderItem() { Index = index, Quantity = quantity, SubTotal = subtotal });

                Console.WriteLine($"訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元。");
            }
        }

        private static void DisplayDrinkMenu(List<Drink> myDrinks)
        {
            Console.WriteLine("DRINKS MENU");
            Console.WriteLine("**************************");
            Console.WriteLine(String.Format("{0,-5}{1,-5}{2,-5}{3,-5}", "編號", "品名", "大小", "價格"));


            int i = 0;
            foreach (Drink drink in myDrinks)
            {
                Console.WriteLine($"{i,-7}{drink.Name,-5}{drink.Size,-5}{drink.Price,-5:C0}");
                i++;
            }
            Console.WriteLine("**************************");
        }

        private static void AddNewDrink(List<Drink> myDrinks)
        {
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "中杯", Price = 50 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "中杯", Price = 20 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 25 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "中杯", Price = 20 });
        }
    }
}

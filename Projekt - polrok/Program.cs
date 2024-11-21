using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> store = new List<string>();

            bool isEnd = false;
            while (!isEnd)
            {
                PrintMenu();
                var answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        foreach (var item in store)
                        {
                            Console.WriteLine(item);
                        }
                        break;


                    case "2":
                        Console.WriteLine("Zadajte názov knihy na pridanie:");
                        var newItemName = Console.ReadLine();
                        Console.WriteLine("Zadajte na koľko dní chcete knihu pridať:");
                        var newItemCount = Console.ReadLine();
                        AddItem(store, newItemName, Int32.Parse(newItemCount));
                        break;


                    case "3":
                        isEnd = true;
                        break;

                    default:
                        Console.WriteLine("Nesprávna akcia!");
                        break;
                }
            }
        }
        public static void AddItem(List<string> itemList, string itemName, int itemCount)
        {
            string foundedItem = null;
            foreach (var item in itemList)
            {
                if (item.Contains(itemName))
                {
                    foundedItem = item;
                }
            }
            if (foundedItem == null)
            {
                var newCreatedItem = $"{itemName}||{itemCount}";
                itemList.Add(newCreatedItem);
                Console.WriteLine($"Kniha {itemName.ToUpper()} bola pridaná do poličky.");
            }
            else
            {
                var splittedItem = foundedItem.Split("||");
                var foundedItemName = splittedItem[0];
                var foundedItemCount = Int32.Parse(splittedItem[1]);
                var newItemCount = foundedItemCount + itemCount;

                var indexOfItem = foundedItem.IndexOf(foundedItem);
                itemList[indexOfItem] = $"{itemName}||{newItemCount}";
                Console.WriteLine($"Kniha {foundedItemName.ToUpper()} bola zaktualizovaná do zoznamu");
            }
        }
        public static void PrintMenu()
        {
            Thread.Sleep(3000);
            ; Console.Clear();
            Console.WriteLine("1.Vypis kníh");
            Console.WriteLine("2.Pridanie knihy");
            Console.WriteLine("3.Exit");
            Console.Write("Vyberte akciu:");
        }
    }
}
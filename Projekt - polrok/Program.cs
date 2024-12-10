using System;
using System.Collections.Generic;
using System.Threading;

public enum Role
{
    Student,
    Admin
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public User(string username, string password, Role role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public bool CanBorrowBook()
    {
        return Role == Role.Student || Role == Role.Admin;
    }

    public bool CanAccessAllAreas()
    {
        return Role == Role.Admin;
    }
}

public class Program
{
    static List<User> users = new List<User>();
    static List<string> store = new List<string>();
    
    public static void Main()
    {
        VypisInfo();
        


        while (true)
        {
            Console.WriteLine("Vyberte možnosť:");
            Console.WriteLine("1. Registrácia");
            Console.WriteLine("2. Prihlásenie");
            Console.WriteLine("3. Ukončenie");
            Console.Write("Vaša voľba: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                RegisterUser(users);
            }
            else if (choice == "2")
            {
                LoginUser(users);
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Neplatná voľba. Skúste znova.");
            }
        }
    }

    public static void RegisterUser(List<User> users)
    {
        Console.Write("Zadajte používateľské meno: ");
        string username = Console.ReadLine();
        Console.Write("Zadajte heslo: ");
        string password = Console.ReadLine();
        Console.Write("Vyberte rolu (1-Student, 2-Admin): ");
        Role role = (Console.ReadLine() == "1") ? Role.Student : Role.Admin;

        users.Add(new User(username, password, role));
        Console.WriteLine("Registrácia úspešná!\n");
    }

    public static void LoginUser(List<User> users)
    {
        Console.Write("Používateľské meno: ");
        string username = Console.ReadLine();
        Console.Write("Heslo: ");
        string password = Console.ReadLine();

        User loggedInUser = users.Find(user => user.Username == username && user.Password == password);

        if (loggedInUser != null)
        {
            Console.WriteLine($"\nPrihlásený používateľ: {loggedInUser.Username}");
            DisplayMenu(loggedInUser);
        }
        else
        {
            Console.WriteLine("Nesprávne používateľské meno alebo heslo.");
        }
    }

    public static void DisplayMenu(User loggedInUser)
    {
        bool isEnd = false;
        while (!isEnd)
        {
            PrintMenu();
            Console.WriteLine();
            var answer = Console.ReadLine();
            

            switch (answer)
            {
                case "1":
                    DisplayBooks();
                    break;
                case "2":
                    if (loggedInUser.CanAccessAllAreas())
                    {
                        Console.WriteLine("Zadajte názov knihy na pridanie:");
                        var newItemName = Console.ReadLine();
                        Console.WriteLine("Zadajte na koľko dní chcete knihu pridať:");
                        var newItemCount = Console.ReadLine();
                        AddItem(store, newItemName, Int32.Parse(newItemCount));
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na pridávanie kníh.");
                    }
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
        string foundItem = null;
        foreach (var item in itemList)
        {
            if (item.Contains(itemName))
            {
                foundItem = item;
            }
        }

        if (foundItem == null)
        {
            var newCreatedItem = $"{itemName}|{itemCount}";
            itemList.Add(newCreatedItem);
            Console.WriteLine($"Kniha {itemName.ToUpper()} bola pridaná do knižnice.");
        }
        else
        {
            var splittedItem = foundItem.Split('|');
            var foundItemName = splittedItem[0];
            var foundItemCount = Int32.Parse(splittedItem[1]);
            var newItemCount = foundItemCount + itemCount;

            var indexOfItem = itemList.IndexOf(foundItem);
            itemList[indexOfItem] = $"{itemName}|{newItemCount}";
            Console.WriteLine($"Kniha {foundItemName.ToUpper()} bola zaktualizovaná v zozname.");
        }
    }

    public static void PrintMenu()
    {
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
        Console.WriteLine("1. Výpis kníh");
        Console.WriteLine("2. Pridanie knihy");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Vyberte akciu:");
    }

    public static void DisplayBooks()
    {
        Console.WriteLine("Zoznam kníh:");
        foreach (var item in store)
        {
            Console.WriteLine(item);
        }
    }
    public static void VypisInfo()
    {
        Thread.Sleep(1500);
        Console.Clear();
        Console.WriteLine("                           ____");
        Console.WriteLine("                           \\__/");
        Console.WriteLine(" __  ___  __   ___  ___  ________   __   __   __    ______     ___");
        Console.WriteLine("|  |/  / |  \\ |  | |  | |       /  |  \\ |  | |  |  /      |   /   \\     ");
        Console.WriteLine("|  '  /  |   \\|  | |  | `---/  /   |   \\|  | |  | |  ,----'  /  ^  \\    ");
        Console.WriteLine("|    <   |  . `  | |  |    /  /    |  . `  | |  | |  |      /  /_\\  \\   ");
        Console.WriteLine("|  .  \\  |  |\\   | |  |   /  /----.|  |\\   | |  | |  `----./  _____  \\");
        Console.WriteLine("|__|\\__\\ |__| \\__| |__|  /________||__| \\__| |__|  \\______/__/     \\__\\");
    }
    public static void Menu()
    {
        Console.WriteLine("                           ____");
        Console.WriteLine("                           \\__/");
        Console.WriteLine(" __  ___  __   ___  ___  ________   __   __   __    ______     ___");
        Console.WriteLine("|  |/  / |  \\ |  | |  | |       /  |  \\ |  | |  |  /      |   /   \\     ");
        Console.WriteLine("|  '  /  |   \\|  | |  | `---/  /   |   \\|  | |  | |  ,----'  /  ^  \\    ");
        Console.WriteLine("|    <   |  . `  | |  |    /  /    |  . `  | |  | |  |      /  /_\\  \\   ");
        Console.WriteLine("|  .  \\  |  |\\   | |  |   /  /----.|  |\\   | |  | |  `----./  _____  \\");
        Console.WriteLine("|__|\\__\\ |__| \\__| |__|  /________||__| \\__| |__|  \\______/__/     \\__\\");
    }
}

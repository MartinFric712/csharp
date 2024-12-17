using Projekt___polrok;
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
    public override string ToString()
    {
        return $"{Username}, {Password}, {Role}";
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
    static List<string> store = new List<string>
    {
        
    };

    static List<string> borrowedBooks = new List<string>();
    //Výpis menu
    public static void Main()
    {
        VypisInfo();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("VITAJTE V KNIŽNICI");
            Console.WriteLine();
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
        var kniha = new Kniha("Pan prstenov", 1995, "Romanticky", "Roman Besny");
    }

    //Registrácia / kontrola hesla
    public static void RegisterUser(List<User> users)
    {
        string username;
        while (true)
        {
            Console.Write("Zadajte používateľské meno: ");
            username = Console.ReadLine();

            if (username.Length >= 3 && username.Length <= 15)
            {
                break;
            }
            else
            {
                Console.WriteLine("Používateľské meno musí byť dlhé aspoň 3 a najviac 15 znakov. Skúste znova.");
            }
        }

        string password;
        while (true)
        {
            Console.Write("Zadajte heslo: ");
            password = Console.ReadLine();

            if (password.Length >= 5 && password.Length <= 10)
            {
                break;
            }
            else
            {
                Console.WriteLine("Heslo musí byť dlhé aspoň 5 a najviac 10 znakov. Skúste znova.");
            }
        }

        Console.Write("Vyberte rolu (1-Student, 2-Admin): ");
        Role role = (Console.ReadLine() == "1") ? Role.Student : Role.Admin;

        users.Add(new User(username, password, role));
        Console.WriteLine("Registrácia úspešná!\n");
        Thread.Sleep(3000);
        Console.Clear();
        VypisInfo();
    }


    //Prihlasovanie

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

    //Prístup k funkciam ako študent/admin
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
                        Console.WriteLine("Zadajte názov knihy na pridanie (alebo 0 pre návrat):");
                        var newItemName = Console.ReadLine();
                        if (newItemName != "0")
                        {
                            AddItem(store, newItemName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na pridávanie kníh.");
                    }
                    break;
                case "3":
                    if (loggedInUser.CanAccessAllAreas())
                    {
                        Console.WriteLine("Zadajte názov knihy na odobratie (alebo 0 pre návrat):");
                        var itemName = Console.ReadLine();
                        if (itemName != "0")
                        {
                            RemoveItem(store, itemName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na odoberanie kníh.");
                    }
                    break;
                case "4":
                    if (loggedInUser.CanBorrowBook())
                    {
                        Console.WriteLine("Zadajte názov knihy na požičiavanie (alebo 0 pre návrat):");
                        var bookName = Console.ReadLine();
                        if (bookName != "0")
                        {
                            BorrowBook(store, borrowedBooks, bookName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na požičiavanie kníh.");
                    }
                    break;
                case "5":
                    PrintBibliography();
                    break;
                case "6":
                    isEnd = true;
                    break;
                default:
                    Console.WriteLine("Nesprávna akcia!");
                    break;
            }
        }
    }


    //Pridávanie kníh
    public static void AddItem(List<string> itemList, string itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            Console.WriteLine($"Kniha {itemName.ToUpper()} bola pridaná do knižnice.");
        }
        else
        {
            Console.WriteLine($"Kniha {itemName.ToUpper()} už existuje v knižnici.");
        }
        Console.WriteLine("\nStlačte Enter, aby ste sa vrátili do menu.");
        Console.ReadLine();
    }

    //Odtraňovanie kníh
    public static void RemoveItem(List<string> itemList, string itemName)
    {
        if (itemList.Contains(itemName))
        {
            itemList.Remove(itemName);
            Console.WriteLine($"Kniha {itemName.ToUpper()} bola odstránená z knižnice.");
        }
        else
        {
            Console.WriteLine($"Kniha {itemName.ToUpper()} nebola nájdená v knižnici.");
        }
        Console.WriteLine("\nStlačte Enter, aby ste sa vrátili do menu.");
        Console.ReadLine();
    }

    //Požičiavanie kníh

    public static void BorrowBook(List<string> itemList, List<string> borrowedList, string itemName)
    {
        if (itemList.Contains(itemName))
        {
            itemList.Remove(itemName);
            borrowedList.Add(itemName);
            Console.WriteLine($"Kniha {itemName.ToUpper()} bola požičaná.");
        }
        else
        {
            Console.WriteLine($"Kniha {itemName.ToUpper()} nebola nájdená v knižnici.");
        }
        Console.WriteLine("\nStlačte Enter, aby ste sa vrátili do menu.");
        Console.ReadLine();
    }

    //Výpis menu
    public static void PrintMenu()
    {
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
        Console.WriteLine("\n1. Výpis kníh");
        Console.WriteLine("2. Pridanie knihy");
        Console.WriteLine("3. Odobratie knihy");
        Console.WriteLine("4. Požičiavanie knihy");
        Console.WriteLine("5. Vypísať bibliografiu");
        Console.WriteLine("6. Odhlásiť sa");
        Console.WriteLine("Vyberte akciu:");
    }
    public static void SaveUsers()
    {
        using (StreamWriter writer = new StreamWriter("users.txt"))
        {
            foreach (var user in users)
            {
                writer.WriteLine(user.ToString());
            }
        }
        Console.WriteLine("Používatelia boli uložený.");
    }

    public static void LoadUsers()
    {
        if (File.Exists("users.txt"))
        {
            using (StreamReader reader = new StreamReader("users.txt"))
            {
                string line; while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        var username = parts[0];
                        var password = parts[1];
                        var role = (Role)Enum.Parse(typeof(Role), parts[2]);
                        users.Add(new User(username, password, role));
                    }
                }
            }
            Console.WriteLine("Používatelia boli načítaní.");
        }
        else
        {
            Console.WriteLine("Žiadny uložený používateľ nebol nájdený.");
        }
    }
        //Výpis kníh
        public static void DisplayBooks()
    {
        Console.WriteLine("Zoznam kníh:");
        foreach (var item in store)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nStlačte Enter, aby ste sa vrátili do menu.");
        Console.ReadLine();
    }


    //Bibliografický výpis
    public static void PrintBibliography()
    {
        Console.WriteLine("Bibliografia kníh:");
        foreach (var item in store)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nStlačte Enter, aby ste sa vrátili do menu.");
        Console.ReadLine();
    }


    //Nadpis menu 1
    public static void VypisInfo()
    {
        Console.Clear();
        Console.WriteLine("                                                ____");
        Console.WriteLine("                                                \\__/");
        Console.WriteLine("                      __  ___  __   ___  ___  ________   __   __   __    ______     ___");
        Console.WriteLine("                     |  |/  / |  \\ |  | |  | |       /  |  \\ |  | |  |  /      |   /   \\     ");
        Console.WriteLine("                     |  '  /  |   \\|  | |  | `---/  /   |   \\|  | |  | |  ,----'  /  ^  \\    ");
        Console.WriteLine("                     |    <   |  . `  | |  |    /  /    |  . `  | |  | |  |      /  /_\\  \\   ");
        Console.WriteLine("                     |  .  \\  |  |\\   | |  |   /  /----.|  |\\   | |  | |  `----./  _____  \\");
        Console.WriteLine("                     |__|\\__\\ |__| \\__| |__|  /________||__| \\__| |__|  \\______/__/     \\__\\");
    }

    //Nadpis menu 2

    public static void Menu()
    {
        Console.WriteLine("                                                ____");
        Console.WriteLine("                                                \\__/");
        Console.WriteLine("                      __  ___  __   ___  ___  ________   __   __   __    ______     ___");
        Console.WriteLine("                     |  |/  / |  \\ |  | |  | |       /  |  \\ |  | |  |  /      |   /   \\     ");
        Console.WriteLine("                     |  '  /  |   \\|  | |  | `---/  /   |   \\|  | |  | |  ,----'  /  ^  \\    ");
        Console.WriteLine("                     |    <   |  . `  | |  |    /  /    |  . `  | |  | |  |      /  /_\\  \\   ");
        Console.WriteLine("                     |  .  \\  |  |\\   | |  |   /  /----.|  |\\   | |  | |  `----./  _____  \\");
        Console.WriteLine("                     |__|\\__\\ |__| \\__| |__|  /________||__| \\__| |__|  \\______/__/     \\__\\");
    }
}
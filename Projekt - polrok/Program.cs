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
    static List<string> store = new List<string>
    {
        "1. A Tale of Two Cities, 1859, História, Charles Dickens",
        "2. 1984, 1949, Sci-fi/Dystopický román, George Orwell",
        "3. Brave New World, 1932, Sci-fi/Dystopický román, Aldous Huxley",
        "4. Crime and Punishment, 1866, Psychologický román, Fyodor Dostoevsky",
        "5. Don Quixote, 1605, Román, Miguel de Cervantes",
        "6. Dracula, 1897, Horor, Bram Stoker",
        "7. Emma, 1815, Román, Jane Austen",
        "8. Frankenstein, 1818, Sci-fi/Horor, Mary Shelley",
        "9. Great Expectations, 1861, Román, Charles Dickens",
        "10. Harry Potter and the Philosopher's Stone, 1997, Fantasy, J.K. Rowling",
        "11. Jane Eyre, 1847, Román, Charlotte Brontë",
        "12. Moby-Dick, 1851, Román, Herman Melville",
        "13. Pride and Prejudice, 1813, Román, Jane Austen",
        "14. The Catcher in the Rye, 1951, Román, J.D. Salinger",
        "15. The Great Gatsby, 1925, Román, F. Scott Fitzgerald",
        "16. The Hobbit, 1937, Fantasy, J.R.R. Tolkien",
        "17. The Lord of the Rings, 1954-1955, Fantasy, J.R.R. Tolkien",
        "18. To Kill a Mockingbird, 1960, Román, Harper Lee",
        "19. War and Peace, 1869, Román, Leo Tolstoy",
        "20. Wuthering Heights, 1847, Román, Emily Brontë",
        "21. A Clockwork Orange, 1962, Sci-fi/Dystopický román, Anthony Burgess",
        "22. Anna Karenina, 1877, Román, Leo Tolstoy",
        "23. Catch-22, 1961, Satirický román, Joseph Heller",
        "24. Dune, 1965, Sci-fi, Frank Herbert",
        "25. Gone with the Wind, 1936, Historický román, Margaret Mitchell",
        "26. Heart of Darkness, 1899, Novela, Joseph Conrad",
        "27. Les Misérables, 1862, Historický román, Victor Hugo",
        "28. Lolita, 1955, Román, Vladimir Nabokov",
        "29. Madame Bovary, 1857, Román, Gustave Flaubert",
        "30. One Hundred Years of Solitude, 1967, Magický realizmus, Gabriel García Márquez",
        "31. Rebecca, 1938, Gotický román, Daphne du Maurier",
        "32. Sense and Sensibility, 1811, Román, Jane Austen",
        "33. Slaughterhouse-Five, 1969, Sci-fi/Anti-vojnový román, Kurt Vonnegut",
        "34. The Adventures of Huckleberry Finn, 1884, Dobrodružný román, Mark Twain",
        "35. The Alchemist, 1988, Filozofický román, Paulo Coelho",
        "36. Animal Farm, 1945, Satira, George Orwell",
        "37. Beloved, 1987, Román, Toni Morrison",
        "38. Charlotte's Web, 1952, Detský román, E.B. White",
        "39. Cloud Atlas, 2004, Sci-fi, David Mitchell",
        "40. Diary of a Young Girl, 1947, Memoár, Anne Frank",
        "41. East of Eden, 1952, Román, John Steinbeck",
        "42. Fahrenheit 451, 1953, Sci-fi/Dystopický román, Ray Bradbury",
        "43. Gone Girl, 2012, Thriller, Gillian Flynn",
        "44. Gulliver's Travels, 1726, Satira, Jonathan Swift",
        "45. Little Women, 1868, Román, Louisa May Alcott",
        "47. Memoirs of a Geisha, 1997, Historický román, Arthur Golden",
        "48. Middlemarch, 1871, Román, George Eliot",
        "49. Norwegian Wood, 1987, Román, Haruki Murakami",
        "50. Of Mice and Men, 1937, Román, John Steinbeck",
        "51. On the Road, 1957, Beat generation, Jack Kerouac",
        "52. Persuasion, 1817, Román, Jane Austen",
        "53. The Big Sleep, 1939, Detektívka, Raymond Chandler",
        "54. The Brothers Karamazov, 1880, Román, Fyodor Dostoevsky",
        "55. The Goldfinch, 2013, Román, Donna Tartt",
        "56. The Road, 2006, Post-apokalyptický román, Cormac McCarthy",
        "57. The Secret Garden, 1911, Detský román, Frances Hodgson Burnett",
    };

    static List<string> borrowedBooks = new List<string>();

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
        Thread.Sleep(3000);
        Console.Clear();
        VypisInfo();
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
                        AddItem(store, newItemName);
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na pridávanie kníh.");
                    }
                    break;
                case "3":
                    if (loggedInUser.CanAccessAllAreas())
                    {
                        Console.WriteLine("Zadajte názov knihy na odobratie:");
                        var itemName = Console.ReadLine();
                        RemoveItem(store, itemName);
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na odoberanie kníh.");
                    }
                    break;
                case "4":
                    if (loggedInUser.CanBorrowBook())
                    {
                        Console.WriteLine("Zadajte názov knihy na požičiavanie:");
                        var bookName = Console.ReadLine();
                        BorrowBook(store, borrowedBooks, bookName);
                    }
                    else
                    {
                        Console.WriteLine("Nemáte povolenie na požičiavanie kníh.");
                    }
                    break;
                case "5":
                    isEnd = true;
                    break;
                default:
                    Console.WriteLine("Nesprávna akcia!");
                    break;
            }
        }
    }

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
    }

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
    }

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
    }

    public static void PrintMenu()
    {
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
        Console.WriteLine();
        Console.WriteLine("1. Výpis kníh");
        Console.WriteLine("2. Pridanie knihy");
        Console.WriteLine("3. Odobratie knihy");
        Console.WriteLine("4. Požičiavanie knihy");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Vyberte akciu:");
    }

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

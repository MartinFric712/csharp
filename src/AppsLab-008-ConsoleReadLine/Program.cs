Console.WriteLine("Ako sa voláš?");
string? meno = Console.ReadLine();
Console.WriteLine("Ahoj, " + meno + "\n");

Console.WriteLine("Koľko máš rokov? " + meno);
string vstup = Console.ReadLine() ?? "0";
int vek = int.Parse(vstup);
Console.WriteLine("Máš " + vek + " rokov." + "\n");

Console.WriteLine("Aké je tvoje obľúbené jedlo?");
string? jedlo = Console.ReadLine();
Console.WriteLine($"Hmm,  {jedlo}  znie skvele !" + "\n");
Console.WriteLine($"Volám sa {meno}, mám {vek} rokov a moje obľúbené jedlo je {jedlo}.");
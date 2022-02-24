using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Xml.Serialization;
using NewJson = System.Text.Json.JsonSerializer;

Console.OutputEncoding = Encoding.UTF8;

TestSerializeJSON();

static void TestSerializeJSON()
{
    void SerializeAnimals(List<Animal> animals) 
    {
        // Création du fichier de sortie
        string jsonPath = Path.Combine(Environment.CurrentDirectory, "animals.json");
        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
            // Création d'un objet se chargeant de la sérialisation en JSON
            Newtonsoft.Json.JsonSerializer jss = new();
            // Sérialisation en tant que string
            jss.Serialize(jsonStream, animals);
        }
        Console.WriteLine();
        Console.WriteLine($"Written {new FileInfo(jsonPath).Length:N0} bytes of JSON to: {jsonPath}");
        // Display de l'objet sérialisé
        Console.WriteLine(File.ReadAllText(jsonPath));
    }

    async void DeserializeAnimals(string path)
    {
        using (FileStream jsonLoad = File.Open(path, FileMode.Open))
        {
            // Désérialisation en tant que Liste d'animaux
            List<Animal>? loadedAnimals = await NewJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Animal>)) as List<Animal>;

            if (loadedAnimals is not null)
            {
                foreach (Animal a in loadedAnimals)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }

    void TestJSONPolicies(Book book)
    {
        JsonSerializerOptions options = new()
        {
            //IncludeFields = true, // Inclure tous les champs
            PropertyNameCaseInsensitive = true, // Respect de la casse
            WriteIndented = true, // Prettified
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Pour l'utilisation dans des navigateurs de façon plus aisée
        };
        string filePath = Path.Combine(Environment.CurrentDirectory, "book.json");

        using (Stream fileStream = File.Create(filePath))
        {
            JsonSerializer.Serialize<Book>(utf8Json: fileStream, value: book, options);
        }

        Console.WriteLine($"Written {new FileInfo(filePath).Length:N0} bytes of JSON to {filePath}");
        Console.WriteLine();

        // Display de l'objet en JSON
        Console.WriteLine(File.ReadAllText(filePath));
    }

    List<Animal> animals = new()
    {
        new Animal("Hector", "Grosminet", CollarColor.Green | CollarColor.Purple, 10),
        new Animal("Bernard", "Rex", CollarColor.Red, 7),
        new Animal("Jules", "Titi", CollarColor.Blue | CollarColor.White, 4),
    };

    SerializeAnimals(animals);

    Console.WriteLine();
    DeserializeAnimals(Path.Combine(Environment.CurrentDirectory, "animals.json"));

    Book csharp10 = new(title: "C# 10 and .NET 6 - Modern Cross-platform Development")
    {
        Author = "Mark J Price",
        PublishDate = new(year: 2021, month: 11, day: 9),
        Pages = 823,
        Created = DateTimeOffset.UtcNow,
    };

    Console.WriteLine();
    TestJSONPolicies(csharp10);

}

static void TestSerializeXML()
{
    void DeserializeAnimals(string path)
    {
        XmlSerializer xs = new(typeof(List<Animal>));

        using (FileStream xmlLoad = File.Open(path, FileMode.Open))
        {
            // Désérialisation et Casting en une liste d'animaux
            List<Animal>? loadedAnimals =
              xs.Deserialize(xmlLoad) as List<Animal>;
            if (loadedAnimals is not null)
            {
                foreach (Animal a in loadedAnimals)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }

    void SerializeAnimals(List<Animal> animals)
    {
        XmlSerializer xs = new(animals.GetType());

        // Création du fichier pour l'export
        string path = Path.Combine(Environment.CurrentDirectory, "animals.xml");
        
        // Utilisation de Using pour automatiquement .Dispose() le stream
        using (FileStream stream = File.Create(path))
        {
            // Sérialization de l'objet dans le stream
            xs.Serialize(stream, animals); // Besoin d'un constructeur par défaut
        }

        Console.WriteLine($"Written {new FileInfo(path).Length:N0} bytes of XML to {path}");
        Console.WriteLine();

        // Display de l'objet sérialisé
        Console.WriteLine(File.ReadAllText(path));
    }

    List<Animal> animals = new()
    {
        new Animal("Hector", "Grosminet", CollarColor.Green | CollarColor.Purple, 10),
        new Animal("Bernard", "Rex", CollarColor.Red, 7),
        new Animal("Jules", "Titi", CollarColor.Blue | CollarColor.White, 4),
    };

    SerializeAnimals(animals);

    Console.WriteLine();
    DeserializeAnimals(Path.Combine(Environment.CurrentDirectory, "animals.xml"));

}

static void OutputFileSystemInfo()
{
    Console.WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",
      arg1: Path.PathSeparator);
    Console.WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",
      arg1: Path.DirectorySeparatorChar);
    Console.WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
      arg1: Directory.GetCurrentDirectory());
    Console.WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
      arg1: Environment.CurrentDirectory);
    Console.WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
      arg1: Environment.SystemDirectory);
    Console.WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
      arg1: Path.GetTempPath());
    Console.WriteLine("GetFolderPath(SpecialFolder");
    Console.WriteLine("{0,-33} {1}", arg0: " .System)",
      arg1: Environment.GetFolderPath(Environment.SpecialFolder.System));
    Console.WriteLine("{0,-33} {1}", arg0: " .ApplicationData)",
      arg1: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
    Console.WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",
      arg1: Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
    Console.WriteLine("{0,-33} {1}", arg0: " .Personal)",
      arg1: Environment.GetFolderPath(Environment.SpecialFolder.Personal));
}

static void WorkWithDirectories()
{
    // Définir un chemin pour le nouveau dossier
    // Démarrage dans le dossier utilisateur
    string newFolder = Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.Personal),
      "Code", "Packt", "NewFolder");
    Console.WriteLine($"Chemin du dossier : {newFolder}");
    
    // Vérif existance
    Console.WriteLine($"Vérification : {Directory.Exists(newFolder)}");
    
    // Création du dossier 
    Console.WriteLine("Création...");
    Directory.CreateDirectory(newFolder);
    Console.WriteLine($"Vérification : {Directory.Exists(newFolder)}");
    Console.Write("Vérifiez l'existance du dossier, puis appuyez sur ENTRÉE: ");
    Console.ReadLine();

    // Suppression du dossier
    Console.WriteLine("Suppression...");
    Directory.Delete(newFolder, recursive: true);
    Console.WriteLine($"Vérification : {Directory.Exists(newFolder)}");
}

static void TestURIs()
{
    void PrintURI(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            input = "https://stackoverflow.com/search?q=securestring";
        }
        Uri uri = new(input);

        Console.WriteLine($"URL: {input}");
        Console.WriteLine($"Scheme: {uri.Scheme}");
        Console.WriteLine($"Port: {uri.Port}");
        Console.WriteLine($"Host: {uri.Host}");
        Console.WriteLine($"Path: {uri.AbsolutePath}");
        Console.WriteLine($"Query: {uri.Query}");

        IPHostEntry entry = Dns.GetHostEntry(uri.Host);
        Console.WriteLine($"{entry.HostName} a cette adresse IP :");
        foreach (IPAddress address in entry.AddressList)
        {
            Console.WriteLine($"  {address} ({address.AddressFamily})");
        }
    }

    void PingServer(string input)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "https://stackoverflow.com/search?q=securestring";
            }
            Uri uri = new(input);

            Ping ping = new();
            Console.WriteLine("Pinging du serveur, veuilliez patienter...");
            PingReply reply = ping.Send(uri.Host);
            Console.WriteLine($"{uri.Host} a été ping et a répondu : {reply.Status}.");
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("La réponse de {0} a pris {1:N0}ms",
                  arg0: reply.Address,
                  arg1: reply.RoundtripTime);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
        }
    }


    Console.Write("Entrez une adresse valide : ");
    string? url = Console.ReadLine();

    PrintURI(url);
    Console.WriteLine();
    PingServer(url);
}

static void TestIndexesSpansRange()
{
    void TestIndexes(string input)
    {
        // Deux façon de définir un index, l'une par le début, l'autre par la fin
        Index i1 = new(value: 3); // Compte depuis le début
        Index i2 = 3; // Utilisation de la conversion implicite en Index

        Console.WriteLine(input[i2]);
    }
    
    void TestRanges(string input)
    {
        // Deux façon de définir l'index, l'une par le début l'autre par la fin
        Index i3 = new(value: 5, fromEnd: true);
        Index i4 = ^5; // En utilisant la notation "Carrot"

        Range r1 = new(start: new Index(3), end: new Index(7));

        Range r2 = new(start: 3, end: 7); // Utilisation de la conversion implicite des int en Index
        Range r3 = 3..7; // Utilisation de la syntaxe C# 8.0 +

        Range r4 = Range.StartAt(3); // De 3 à l'index final
        Range r5 = 3..; // De 3 à l'index final

        Range r6 = Range.EndAt(3); // De l'index 0 à l'index 3
        Range r7 = ..3; // De l'index 0 à l'index 3

        string modifiedA = input[r3];
        string modifiedB = input[r5];
        string modifiedC = input[r7];

        Console.WriteLine(modifiedA);
        Console.WriteLine(modifiedB);
        Console.WriteLine(modifiedC);
    }
    
    void TestSpans(string input)
    {
        // Utilisation des Substrings
        Console.WriteLine("=== SUBSTRINGS ===");
        int lengthOfFirst = input.IndexOf(' ');
        int lengthOfLast = input.Length - lengthOfFirst - 1;
        string firstName = input.Substring(startIndex: 0, length: lengthOfFirst);
        string lastName = input.Substring(startIndex: input.Length - lengthOfLast, length: lengthOfLast);
        Console.WriteLine($"Prénom : {firstName}, Nom : {lastName}");


        // En utilisant des Spans
        Console.WriteLine();
        Console.WriteLine("=== SPANS ===");
        ReadOnlySpan<char> nameAsSpan = input.AsSpan();
        ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
        ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..^0];
        Console.WriteLine($"Prénom : {firstNameSpan.ToString()}, Nom : {lastNameSpan.ToString()}");
    }

    string name = "Arnorld SWARTZENEGER";

    Person[] people =
    {
        new Person("John SMITH", DateTime.Now),
        new Person("Sarah CONNOR", new(day: 25, month: 12, year: 1967)),
        new Person("Nathan DRAKE", new(day: 17, month: 06, year: 1979))
    };

    int index = 2;
    Person p = people[index]; // 3ème personne du tableau
    char letter = name[index]; // 4ème lettre du nom

    TestIndexes(name);

    TestRanges(name);

    TestSpans(name);
}

static void TestEvents()
{
    void RoarBadly()
    {
        Console.WriteLine("ROAR !");
    }

    Person john = new Person();
    john.Shout += RoarBadly;

    for (int i = 0; i < 10; i++)
    {
        john.Poke();
    }
}

static void TestRegexp()
{
    void TestAge()
    {
        Console.Write("Quel est votre âge : ");
        string? input = Console.ReadLine();
        //Regex ageChecker = new(@"\d"); Accepte un nombre placé n'importe comment
        //Regex ageChecker = new(@"^\d$"); Accepte un unique chiffre sans rien devant ni derrière 
        Regex ageChecker = new(@"^\d+$"); // Accepte un nombre sans rien devant ni derrière 
        if (ageChecker.IsMatch(input))
        {
            Console.WriteLine("Merci !");
        }
        else
        {
            Console.WriteLine($"Cet âge est invalide : {input}");
        }
    }

    TestAge();

}

static void TestPassingParameters()
{
    Person person = new Person("John", DateTime.Now);

    int a = 10;
    int b = 20;
    int c = 30;
    int d = 10;
    int e = 20;

    Console.WriteLine($"Avant: a = {a}, b = {b}, c = {c}");
    person.PassingParameters(a, ref b, out c);
    // Depuis C#7.0, on peut créer les variables 
    person.PassingParameters(d, ref e, out int f);
    Console.WriteLine($"Après: a = {a}, b = {b}, c = {c}");
    Console.WriteLine($"Après: a = {d}, b = {e}, c = {f}");
}

static void TestDeconstructor()
{
    Person johnSmith = new("John Smith", new DateTime(day: 07, month: 11, year: 1984));
    johnSmith.FavoriteWonders = FavoriteWonders.StatueOfZeusAtOlympia | FavoriteWonders.TempleOfArtemisAtEphesus;

    var (name, date) = johnSmith; // Utilise le public void Deconstruct() de Person

    Console.WriteLine($"{name} est né le {date.ToString("d")}");

    var (name2, date2, favorites) = johnSmith;

    Console.WriteLine($"{name2} est né le {date2.ToString("d")} et ses merveilles préférées sont : {favorites}");
}

static void TestMultipleValueEnums()
{
    Person john = new Person("John Smith", new DateTime(day: 27, month: 02, year: 1993));
    john.FavoriteWonders = FavoriteWonders.TempleOfArtemisAtEphesus | FavoriteWonders.ColossusOfRhodes;

    Console.WriteLine($"Les catégories de {john.Name} sont : {john.FavoriteWonders}");
}

static void LogTest()
{
    // write to a text file in the project folder
    Trace.Listeners.Add(new TextWriterTraceListener(
      File.CreateText(Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
    // text writer is buffered, so this option calls
    // Flush() on all listeners after writing
    Trace.AutoFlush = true;
    Debug.WriteLine("Debug says, I am watching!");
    Trace.WriteLine("Trace says, I am watching!");
}

static void TestRefValues()
{
    int MultiplyAndAdd(int firstNbr, int secondNbr)
    {
        firstNbr++;
        secondNbr++;

        Console.WriteLine($"Dans la méthode, A vaut {firstNbr} et B vaut {secondNbr}...");

        return firstNbr + secondNbr;
    }

    int MultiplyAndAddWithRef(ref int firstNbr, ref int secondNbr)
    {
        firstNbr++;
        secondNbr++;

        Console.WriteLine($"Dans la méthode, A vaut {firstNbr} et B vaut {secondNbr}...");

        return firstNbr + secondNbr;
    }

    int nbA = 2;
    int nbB = 5;

    Console.WriteLine("Sans valeurs références : ");
    Console.WriteLine($"Avant la méthode, A vaut {nbA} et B vaut {nbB}...");
    MultiplyAndAdd(nbA, nbB);
    Console.WriteLine($"Après la méthode, A vaut {nbA} et B vaut {nbB}...");

    nbA = 2;
    nbB = 5;

    Console.WriteLine();
    Console.WriteLine("Avec valeurs références : ");
    Console.WriteLine($"Avant la méthode, A vaut {nbA} et B vaut {nbB}...");
    int resultat = MultiplyAndAddWithRef(ref nbA, ref nbB);
    Console.WriteLine($"Après la méthode, A vaut {nbA} et B vaut {nbB}...");
    Console.WriteLine();
    Console.WriteLine($"La somme des deux nombres vaut {resultat}");
}

static void RunTuple()
{
    Tuple<string, decimal, decimal> CalcNewPriceOldSchool(Product product, decimal taxRate)
    {
        Console.WriteLine();
        Console.WriteLine("=== CalcNewPriceOldSchool ===");
        Console.WriteLine($"Votre produit : {product.Name}");

        Console.WriteLine("Votre valeur de T.V.A : {0:P2}",
            arg0: taxRate);

        return Tuple.Create(product.Name, product.Price, product.Price + product.Price * (taxRate / 100M));
    }

    (string name, decimal basePrice, decimal taxedPrice) CalcNewPrice(Product product, decimal taxRate)
    {
        Console.WriteLine();
        Console.WriteLine("=== CalcNewPrice ===");
        Console.WriteLine($"Votre produit : {product.Name}");

        Console.WriteLine("Votre valeur de T.V.A : {0:P2}",
            arg0: taxRate);

        return (product.Name, product.Price, product.Price + product.Price * (taxRate / 100M));
    }

    Product pomme = new("Pomme", "Fruit classique utilisé par les sorcières de contes de fées", 0.89M, 30);

    Tuple<string, decimal, decimal> oldSchoolTuple = CalcNewPriceOldSchool(pomme, 0.18M); 
    Console.WriteLine($"OLD SCHOOL : Après la méthode, j'ai {oldSchoolTuple.Item1} qui a comme prix de base {oldSchoolTuple.Item2:C2} et comme prix T.T.C. {oldSchoolTuple.Item3:C2}");

    var (nom, prix, prixTTC) = CalcNewPrice(pomme, 0.20M);
    Console.WriteLine($"NEW AGE : Après la méthode, j'ai {nom} qui a comme prix de base {prix:C2} et comme prix T.T.C. {prixTTC:C2}");
}

static void RunFactorial()
{
    int Factorial(int number)
    {
        if (number < 1)
        {
            return 0;
        }
        else if (number == 1)
        {
            return 1;
        }
        else
        {
            checked // Pour le dépassement
            {
                return number * Factorial(number - 1);
            }
        }
    }

    for (int i = 1; i < 15; i++)
    {
        try
        {
            Console.WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (System.OverflowException)
        {
            Console.WriteLine($"{i}! est trop grand pour un Int32.");
        }
    }
}

/// <summary>
/// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
/// </summary>
/// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
/// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11: // Cas spécifique pour 11, 12 et 13
        case 12:
        case 13:
            return $"{number}th";
        default:
            int lastDigit = number % 10;
            string suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
            return $"{number}{suffix}";
    }
}

static void RunFibImperative()
{
    int FibImperative(int term)
    {
        if (term == 1)
        {
            return 0;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }

    for (int i = 1; i <= 30; i++)
    {
        Console.WriteLine("Le {0} terme de la suite de Fibonacci est {1:N0}",
          arg0: CardinalToOrdinal(i),
          arg1: FibImperative(term: i));
    }
}

static void RunFibFunctional()
{
    int FibFunctional(int term) => term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2)
        };

    for (int i = 1; i <= 30; i++)
    {
        Console.WriteLine("Le {0} terme de la suite de Fibonacci est {1:N0}.",
          arg0: CardinalToOrdinal(i),
          arg1: FibFunctional(term: i));
    }
}

static void RunCardinalToOrdinal()
{
    for (int number = 1; number <= 40; number++)
    {
        Console.Write($"{CardinalToOrdinal(number)} ");
    }
    Console.WriteLine();
}

static void BinaryToString()
{
    int tableLength;

    Console.Write("Longueur du tableau de bytes : ");
    int.TryParse(Console.ReadLine(), out tableLength);

    byte[] binaryObject = new byte[tableLength]; // Allouer un tableau de bytes
    
    new Random().NextBytes(binaryObject); // Ajout de valeurs aléatoires au tableau

    Console.WriteLine("Object en bytes :");
    for (int index = 0; index < binaryObject.Length; index++)
    {
        Console.Write($"{binaryObject[index]:X} ");
    }
    Console.WriteLine();
    Console.WriteLine();
    
    string encoded = Convert.ToBase64String(binaryObject); // Conversion en String de base 64 et écriture dans la console
    Console.WriteLine("Objet en string :");
    Console.WriteLine(encoded);
}

static void ControlRounding()
{
    Console.WriteLine("=== ARRONDIR DES VALEURS ===");
    Console.WriteLine();

    double[] doubles = { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };


    Console.WriteLine("- Sans modifications");
    foreach (double n in doubles)
    {
        Console.WriteLine($"Convert.ToInt32({n}) donne {Convert.ToInt32(n)}");
    }

    Console.WriteLine();
    Console.WriteLine("- Avec modifications");
    foreach (double n in doubles)
    {
        Console.WriteLine(format: "Math.Round({0}, 0, MidpointRounding.AwayFromZero) donne {1}",
          arg0: n,
          arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
    }
}

static void BitwiseOperators()
{
    string ToBinaryString(int value)
    {
        return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
    }

    int a = 10; // 00001010
    int b = 6;  // 00000110
    Console.WriteLine($"a = {a}");
    Console.WriteLine($"b = {b}");
    Console.WriteLine($"a & b = {a & b}"); // 2-bit column only 
    Console.WriteLine($"a | b = {a | b}"); // 8, 4, and 2-bit columns 
    Console.WriteLine($"a ^ b = {a ^ b}"); // 8 and 4-bit columns

    Console.WriteLine();
    Console.WriteLine("En Binaire :");
    Console.WriteLine($"a =     {ToBinaryString(a)}");
    Console.WriteLine($"b =     {ToBinaryString(b)}");
    Console.WriteLine($"a & b = {ToBinaryString(a & b)}");
    Console.WriteLine($"a | b = {ToBinaryString(a | b)}");
    Console.WriteLine($"a ^ b = {ToBinaryString(a ^ b)}");

    Console.WriteLine();

    // 01010000 left-shift a by three bit columns
    Console.WriteLine($"a << 3 = {a << 3}");
    // multiply a by 8
    Console.WriteLine($"a * 8 = {a * 8}");
    // 00000011 right-shift b by one bit column
    Console.WriteLine($"b >> 1 = {b >> 1}");
}

static void SwitchExpressionTest()
{
    int value;
    Console.Write("Veuilliez donner un nombre : ");
    int.TryParse(Console.ReadLine(), out value);

    string message = value switch
    {
        666 => "Vous aimez Satan !?",
        > 18 => "Vous auriez la majorité s'sil s'agissait d'un âge !",
        _ => "Ce nombre ne me dit rien..."
    };

    Console.WriteLine(message);

}

static void TruthTable()
{
    bool DoStuff()
    {
        Console.WriteLine("Je fais des trucs.");
        return true;
    }

    Console.WriteLine("=== TABLE VERITE ===");
    Console.WriteLine();

    bool a = true;
    bool b = false;
    Console.WriteLine($"AND  | a     | b    ");
    Console.WriteLine($"a    | {a & a,-5} | {a & b,-5} ");
    Console.WriteLine($"b    | {b & a,-5} | {b & b,-5} ");
    Console.WriteLine();
    Console.WriteLine($"OR   | a     | b    ");
    Console.WriteLine($"a    | {a | a,-5} | {a | b,-5} ");
    Console.WriteLine($"b    | {b | a,-5} | {b | b,-5} ");
    Console.WriteLine();
    Console.WriteLine($"XOR  | a     | b    ");
    Console.WriteLine($"a    | {a ^ a,-5} | {a ^ b,-5} ");
    Console.WriteLine($"b    | {b ^ a,-5} | {b ^ b,-5} ");
    Console.WriteLine();

    Console.WriteLine("=== TYPES D'OPERATEURS LOGIQUES ===");
    Console.WriteLine();

    Console.WriteLine("- Le Simple & : Non stoppant");
    Console.WriteLine($"a & DoStuff() = {a & DoStuff()}"); // DoStuff() est executé
    Console.WriteLine($"b & DoStuff() = {b & DoStuff()}"); // DoStuff() est executé malgré le False de b


    Console.WriteLine();
    Console.WriteLine("- Le Double && : Stoppant");
    Console.WriteLine($"a && DoStuff() = {a && DoStuff()}"); // DoStuff() est executé
    Console.WriteLine($"b && DoStuff() = {b && DoStuff()}"); // DoStuff() n'est pas executé car b est False
}

static void TestEqualityDoubleDecimal()
{
    double doubleA, doubleB, doubleC;
    decimal decimalA, decimalB, decimalC;

    Console.WriteLine("=== TEST DECIMAL ===");
    Console.WriteLine();

    decimalA = 0.1M;
    decimalB = 0.2M;
    decimalC = 0.3M;

    Console.WriteLine($"{decimalA:N2} + {decimalB:N2} = {decimalC:N2} ? {(decimalA + decimalB == decimalC ? "Oui" : "Non")}");

    Console.WriteLine();
    Console.WriteLine("=== TEST DOUBLE ===");
    Console.WriteLine();

    doubleA = 0.1;
    doubleB = 0.2;
    doubleC = 0.3;

    Console.WriteLine($"{doubleA:N2} + {doubleB:N2} = {doubleC:N2} ? {(doubleA + doubleB == doubleC ? "Oui" : "Non")}");
}

static void AlignmentTest()
{
    int[] stocks = { 14_259, 2_547 };
    decimal[] prices = { 0.89M, 1.09M };
    string[] names = { "Apple", "Banana" };

    Console.WriteLine("=== LISTE PRODUITS ===");
    Console.WriteLine();

    Console.WriteLine($"{"Produit",-10} {"Prix", 10} {"Stock", 10}");
    Console.WriteLine();
    for(int i = 0; i < 2; i++) Console.WriteLine($"{names[i], -10} {prices[i],10:C2} {stocks[i], 10:N0}");
}

static void TestKey()
{
    Console.Write("Appuyez sur une touche : ");
    ConsoleKeyInfo key = Console.ReadKey();
    Console.WriteLine();
    Console.WriteLine($"Vous avez appuyé sur la touche {key.Key}, de valeur {key.KeyChar} avec comme modificateurs : {(key.Modifiers == 0 ? "Aucun" : key.Modifiers)}");
}
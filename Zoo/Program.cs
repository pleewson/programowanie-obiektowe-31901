using Zoo.Models;
using Zoo.Services;

namespace Zoo;

class Program
{
    private static ZooManager zooManager = new ZooManager();

    static void Main(string[] args)
    {
        Console.WriteLine("=================================");
        Console.WriteLine("   WITAJ W SYMULATORZE ZOO!");
        Console.WriteLine("=================================");

        zooManager.LoadFromJson();

        bool running = true;
        while (running)
        {
            DisplayMainMenu();
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Nieprawidlowy wybor. Sprobuj ponownie.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddAnimal();
                    break;
                case 2:
                    DisplayAnimalsMenu();
                    break;
                case 3:
                    FeedAnimalMenu();
                    break;
                case 4:
                    zooManager.FeedAllAnimals();
                    break;
                case 0:
                    zooManager.SaveToJson();
                    Console.WriteLine("Do zobaczenia kolejnym razem!");
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Nieprawidlowy wybor. Sprobuj ponownie.");
                    continue;
            }

            zooManager.IncrementAllHunger();
            zooManager.CheckAnimalStatus();
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("\n--- ZOO ---");
        Console.WriteLine("1. Dodaj zwierze");
        Console.WriteLine("2. Wyswietl zwierzeta");
        Console.WriteLine("3. Nakarm zwierze");
        Console.WriteLine("4. Nakarm wszystkie zwierzeta");
        Console.WriteLine("0. Wyjscie");
        Console.Write("Wybierz opcje: ");
    }

    static void AddAnimal()
    {
        Console.WriteLine("\n--- Wybierz typ zwierzecia ---");
        Console.WriteLine("1. Slon");
        Console.WriteLine("2. Zebra");
        Console.WriteLine("3. Zyrafa");
        Console.WriteLine("4. Lew");
        Console.WriteLine("5. Pingwin");
        Console.WriteLine("6. Malpa");
        Console.WriteLine("7. Krokodyl");
        Console.Write("Wybor: ");

        string? typeInput = Console.ReadLine();
        if (!int.TryParse(typeInput, out int type) || type < 1 || type > 7)
        {
            Console.WriteLine("Nieprawidlowy typ zwierzecia.");
            return;
        }

        Console.Write("Podaj imie zwierzecia: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Imie nie moze byc puste.");
            return;
        }

        Console.Write("Podaj wiek zwierzecia: ");
        string? ageInput = Console.ReadLine();
        if (!int.TryParse(ageInput, out int age) || age < 0)
        {
            Console.WriteLine("Nieprawidlowy wiek.");
            return;
        }

        try
        {
            var animal = ZooManager.CreateAnimal(type, name, age);
            zooManager.AddAnimal(animal);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void DisplayAnimalsMenu()
    {
        zooManager.DisplayAnimals();

        if (zooManager.Animals.Count == 0)
        {
            return;
        }

        Console.Write("\nWybierz numer zwierzecia (0 - powrot): ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int index) || index == 0)
            return;

        var animal = zooManager.GetAnimal(index - 1);
        if (animal == null)
        {
            Console.WriteLine("Nieprawidlowy numer zwierzecia.");
            return;
        }

        AnimalSubMenu(animal);
    }

    static void AnimalSubMenu(Animal animal)
    {
        bool inSubMenu = true;
        while (inSubMenu)
        {
            Console.WriteLine($"\n--- {animal.Name} ({animal.AnimalType}) ---");
            Console.WriteLine("1. Nakarm zwierze");
            Console.WriteLine("2. Uslysz dzwiek zwierzecia");
            Console.WriteLine("0. Powrot");
            Console.Write("Wybor: ");

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Nieprawidlowy wybor.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    animal.Feed();
                    break;
                case 2:
                    animal.MakeSound();
                    break;
                case 0:
                    inSubMenu = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidlowy wybor.");
                    break;
            }
        }
    }

    static void FeedAnimalMenu()
    {
        zooManager.DisplayAnimals();

        if (zooManager.Animals.Count == 0)
            return;

        Console.Write("\nWybierz numer zwierzecia do nakarmienia: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int index))
        {
            Console.WriteLine("Nieprawidlowy numer.");
            return;
        }

        zooManager.FeedAnimal(index - 1);
    }
}
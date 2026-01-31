using System.Text.Json;
using Zoo.Models;

namespace Zoo.Services;

public class ZooManager
{
    private List<Animal> animals;
    private string saveFilePath;
    private JsonSerializerOptions jsonOptions;

    public ZooManager(string saveFilePath = "zoo.json")
    {
        this.saveFilePath = saveFilePath;
        animals = new List<Animal>();
        jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
    }

    public List<Animal> Animals
    {
        get { return animals; }
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine($"\nDodano: {animal}");
    }

    public void DisplayAnimals()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("\nBrak zwierzat w zoo.");
            return;
        }

        Console.WriteLine("\n--- Lista zwierzat ---");
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {animals[i]}");
        }
    }

    public Animal? GetAnimal(int index)
    {
        if (index >= 0 && index < animals.Count)
        {
            return animals[index];
        }
        return null;
    }

    public void FeedAnimal(int index)
    {
        var animal = GetAnimal(index);
        if (animal != null)
        {
            animal.Feed();
        }
        else
        {
            Console.WriteLine("Nieprawidlowy numer zwierzecia.");
        }
    }

    public void FeedAllAnimals()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("\nBrak zwierzat do nakarmienia.");
            return;
        }

        Console.WriteLine("\n--- Karmienie wszystkich zwierzat ---");
        foreach (var animal in animals)
        {
            animal.Feed();
        }
    }

    public void IncrementAllHunger()
    {
        foreach (var animal in animals)
        {
            animal.IncreaseHunger(5);
        }
    }

    public void CheckAnimalStatus()
    {
        foreach (var animal in animals)
        {
            if (animal.HungerLevel == 100)
            {
                Console.WriteLine($"UWAGA! {animal.Name} ({animal.AnimalType}) umiera z glodu!");
            }
            else if (animal.HungerLevel > 80)
            {
                Console.WriteLine($"Ostrzezenie: {animal.Name} ({animal.AnimalType}) jest bardzo glodne!");
            }
        }
    }

    public void SaveToJson()
    {
        try
        {
            string json = JsonSerializer.Serialize(animals, jsonOptions);
            File.WriteAllText(saveFilePath, json);
            Console.WriteLine($"\nStan zoo zapisany do pliku {saveFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nBlad podczas zapisu: {ex.Message}");
        }
    }

    public void LoadFromJson()
    {
        try
        {
            if (File.Exists(saveFilePath))
            {
                string json = File.ReadAllText(saveFilePath);
                var loadedAnimals = JsonSerializer.Deserialize<List<Animal>>(json, jsonOptions);

                if (loadedAnimals != null)
                {
                    animals.Clear();
                    animals.AddRange(loadedAnimals);
                    Console.WriteLine($"Wczytano {animals.Count} zwierzat z pliku {saveFilePath}");
                }
            }
            else
            {
                Console.WriteLine("Brak zapisanego stanu zoo.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Blad podczas wczytywania: {ex.Message}");
            Console.WriteLine("Rozpoczynamy z pustym zoo.");
        }
    }

    public static Animal CreateAnimal(int type, string name, int age)
    {
        return type switch
        {
            1 => new Elephant(name, age),
            2 => new Zebra(name, age),
            3 => new Giraffe(name, age),
            4 => new Lion(name, age),
            5 => new Penguin(name, age),
            6 => new Monkey(name, age),
            7 => new Crocodile(name, age),
            _ => throw new ArgumentException("Nieprawidlowy typ zwierzecia")
        };
    }
}
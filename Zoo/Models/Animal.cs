using System.Text.Json.Serialization;

namespace Zoo.Models;

[JsonDerivedType(typeof(Elephant), "Elephant")]
[JsonDerivedType(typeof(Zebra), "Zebra")]
[JsonDerivedType(typeof(Giraffe), "Giraffe")]
[JsonDerivedType(typeof(Lion), "Lion")]
[JsonDerivedType(typeof(Penguin), "Penguin")]
[JsonDerivedType(typeof(Monkey), "Monkey")]
[JsonDerivedType(typeof(Crocodile), "Crocodile")]
public abstract class Animal
{
    private string name;
    private int age;
    private int hungerLevel;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value > 0 ? value : 0;
    }

    public int HungerLevel
    {
        get => hungerLevel;
        set => hungerLevel = Math.Clamp(value, 0, 100);
    }

    public string AnimalType => GetType().Name;

    protected Animal()
    {
    }

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
        HungerLevel = 50;
    }

    public abstract void MakeSound();
    public abstract void Feed();

    public void IncreaseHunger(int amount = 5)
    {
        HungerLevel += amount;
    }

    public string GetHungerStatus()
    {
        if (HungerLevel == 100)
            return "CHORE - zwierze umiera";
        if (HungerLevel > 80)
            return "Bardzo glodne";
        if (HungerLevel > 50)
            return "Glodne";
        if (HungerLevel > 20)
            return "W normie";
        else
        {
            return "Najedzone";
        }
    }

    public override string ToString()
    {
        return $"{AnimalType}: {Name}, Wiek: {Age}, Glod: {HungerLevel}/100 ({GetHungerStatus()})";
    }
}
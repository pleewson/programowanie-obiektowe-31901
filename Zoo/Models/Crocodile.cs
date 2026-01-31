namespace Zoo.Models;

public class Crocodile : Animal
{
    public Crocodile(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} HSSSSS!");
    }

    public override void Feed()
    {
        int reduction = 35;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadl kurczaka. Glod: {oldLevel} -> {HungerLevel}");
    }
}

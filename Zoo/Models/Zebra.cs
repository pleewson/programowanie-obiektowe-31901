namespace Zoo.Models;

public class Zebra : Animal
{
    public Zebra(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} IIIIHAAAA!");
    }

    public override void Feed()
    {
        int reduction = 20;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadla trawe. Glod: {oldLevel} -> {HungerLevel}");
    }
}

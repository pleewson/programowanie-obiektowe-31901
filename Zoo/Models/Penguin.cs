namespace Zoo.Models;

public class Penguin : Animal
{
    public Penguin(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} KWEK KWEK!");
    }

    public override void Feed()
    {
        int reduction = 15;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadl ryby. Glod: {oldLevel} -> {HungerLevel}");
    }
}

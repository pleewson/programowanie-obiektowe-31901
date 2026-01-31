namespace Zoo.Models;

public class Lion : Animal
{
    public Lion(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} ROAAARRRR!");
    }

    public override void Feed()
    {
        int reduction = 30;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadl mieso. Glod: {oldLevel} -> {HungerLevel}");
    }
}

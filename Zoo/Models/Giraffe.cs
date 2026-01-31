namespace Zoo.Models;

public class Giraffe : Animal
{
    public Giraffe(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} mmmm...");
    }

    public override void Feed()
    {
        int reduction = 22;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadla liscie. Glod: {oldLevel} -> {HungerLevel}");
    }
}

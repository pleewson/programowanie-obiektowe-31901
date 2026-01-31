namespace Zoo.Models;

public class Elephant : Animal
{
    public Elephant(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} TRUUUUUUU!");
    }

    public override void Feed()
    {
        int reduction = 25;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadl siano i owoce. Glod: {oldLevel} -> {HungerLevel}");
    }
}

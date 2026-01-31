namespace Zoo.Models;

public class Monkey : Animal
{
    public Monkey(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} UU UU AA AA!");
    }

    public override void Feed()
    {
        int reduction = 18;
        int oldLevel = HungerLevel;
        HungerLevel -= reduction;
        Console.WriteLine($"{Name} zjadla banany. Glod: {oldLevel} -> {HungerLevel}");
    }
}

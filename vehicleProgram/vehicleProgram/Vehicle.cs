namespace vehicleProgram;

public class Vehicle
{
    public Vehicle(double Capacity, string Model, int Year)
    {
        this.Capacity = Capacity;
        this.Model = Model;
        this.Year = Year;
    }

    public double Capacity { get; protected set; }
    public string Model { get; protected set; }
    public int Year { get; protected set; }
}
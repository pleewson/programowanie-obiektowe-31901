namespace vehicleProgram;

public class Database
{
    public static List<Vehicle> Vehicles { get; set; } =
    [
        new Bike(0.6,"Yamaha",2025),
        new Bike(0.6,"BMW",1999),
        new Bike(0.9,"Audi",2015),
        
        new Car(3.6,"Toyota",2012),
        new Car(4.6,"Suzuki",2011),
        new Car(5.0,"Jaguar",2004)
    ];
}
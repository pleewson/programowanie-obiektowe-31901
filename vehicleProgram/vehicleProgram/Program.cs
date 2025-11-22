using vehicleProgram;

bool run = true;

do
{
    Console.WriteLine();
    Console.WriteLine("CAR SHOP");
    Console.WriteLine("[1] Show all, " +
                      "[2] Search by year, " +
                      "[3] Search By Model, " +
                      "[4] Search by engine capacity, " +
                      "[5] Add car, " +
                      "[0] exit");

    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (input)
    {
        case '1':
            DisplayVehicleModel();
            break;
        case '2':
            SearchByYear();
            break;
        case '3':
            SearchByModel();
            break;
        case '4':
            SearchByCapacity();
            break;
        case '5':
            AddNeVehicle();
            break;
        case '0':
            run = false;
            break;
        default:
            Console.WriteLine("Invalid menu option");
            break;
    }
} while (run);

Console.WriteLine("Goodbye.. o/");


//1
////==========================================////
void DisplayVehicleModel()
{
    Console.WriteLine("Our vehicles: ");
    foreach (var vehicle in Database.Vehicles)
    {
        Console.WriteLine(vehicle.Model);
    }
}


//2
////==========================================////
void SearchByYear()
{
    Console.Write("Enter year :");
    var success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine(("Invalid year"));
        SearchByYear();
        return;
    }
    
    var vehicles = Database.Vehicles.Where(v => v.Year == year);

    if (!vehicles.Any())
    {
        Console.WriteLine("no vechicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}



//3
////==========================================////
void SearchByModel()
{
    Console.Write("Enter model :");
    string? model = Console.ReadLine().ToLower();
    
    var vehicles = Database.Vehicles.Where(v => v.Model.ToLower() == model);

    if (!vehicles.Any())
    {
        Console.WriteLine("no vechicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}



//4
////==========================================////
void SearchByCapacity()
{
    Console.Write("Enter capacity :");
    var success = double.TryParse(Console.ReadLine(), out double capacity);
    if (!success)
    {
        Console.WriteLine(("Invalid capacity value"));
        SearchByCapacity();
        return;
    }
    
    var vehicles = Database.Vehicles.Where(v => v.Capacity == capacity);

    if (!vehicles.Any())
    {
        Console.WriteLine("no vechicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Capacity);
        }
    }
}


//5
////==========================================////
void AddNeVehicle()
{
    Console.WriteLine("b for bike, c for car");
    var input = Console.ReadKey().KeyChar;

    if (input.ToString().ToLower() is not ("b" or "c"))
    {
        Console.WriteLine(("Invalid vehicle type"));
        return;
    }
    
    Console.WriteLine("Enter engine capacity");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine(("Invalid engine capacity"));
        return;
    }

    

    Console.Write("Enter model: ");
    string? model = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    
    Console.Write("Enter year: ");
    success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine(("Invalid year"));
        return;
    }

    Vehicle v;

    if (input == 'C')
    {
        v = new Car(engineCapacity, model, year);
    }
    else
    {
        v = new Bike(engineCapacity, model, year);
    }
    
    Database.Vehicles.Add(v);
    
    Console.WriteLine("vehicle added successfully5");
}
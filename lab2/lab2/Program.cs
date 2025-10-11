// Car car1 = new Car("audi", 1999);
// Car car2 = new Car("toyota", 2005);
// Car car3 = new Car("bmw", 2011);
//
// car1.showMe();
//
// var bike1 = new Bike();
// Vehicle v1;
//
// v1 = bike1;
// v1 = car1;
//
// StartAnyVehicle(bike1);
//
// void StartAnyVehicle(Vehicle vehicle)
// {
//     vehicle.Start();
// }
//
// class Vehicle
// {
//     public double EngineCapacity { get; protected set; }
//
//     public void Start()
//     {
//         
//     }
//     
//     public void Stop()
//     {
//         
//     }
// }
//
//
// class Bike : Vehicle
// {
// }
//
// class Car : Vehicle
// {
//     public Car(String model, int year)
//     {
//         this.model = model;
//         this.year = year;
//     }
//
//
//     private String model;
//     private int year;
//
//
// //getter
//     public string Model
//     {
//         get { return model; }
//     }
//
//     public void showMe()
//     {
//         Console.WriteLine(model + " " + year);
//     }
// }


//ZADANIE 5

// class KontoBankowe
// {
//     private double saldo;
//
//     public void Wplata(double kwota)
//     {
//         saldo += kwota;
//     }
//
//     public double PobierzSaldo()
//     {
//         return saldo;
//     }
//
//     public void Wyplata(double kwota)
//     {
//         if (kwota >= saldo)
//         {
//             saldo = saldo - kwota;
//             Console.WriteLine("Wyplacono " + kwota);
//         }
//         else
//         {
//             Console.WriteLine("Masz za male saldo");
//         }
//     }
// }




//ZADANIE 6

Kot kot = new Kot();
kot.Miaucz();
class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je");
}

class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("Hau hau!");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau miau!!");
}

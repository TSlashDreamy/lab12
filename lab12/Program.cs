using lab12;

// creating objects and showing info about them
try
{
    Ship ship = new Ship(2000, 90, 1941, 40, "La manche");
    Car car = new Car(4000, 120, 1702);
    Plain plain = new Plain(12000, 340, 1920, 500, 50);

    Console.WriteLine(ship.GetInfo());
    Console.WriteLine("New cost: " + ship.CalculateCost());

    Console.WriteLine(plain.GetInfo());
    Console.WriteLine("New cost: " + plain.CalculateCost());

    Console.WriteLine(car.GetInfo());
    Console.WriteLine("New cost: " + car.CalculateCost());
}
catch (Exception exc)
{
    Console.WriteLine("Wrong object creation: " + exc);
}

void showArray(Car[] carArray)
{
    foreach (Car car in carArray)
    {
        Console.WriteLine($"{car.MakeName()}");
    }
}

// Creating array of car objects and copies of these objects
Car[] cars = new Car[10];

for (int i = 0; i < cars.Length / 2; i++)
{
    try
    {
        cars[i] = new Car(7000 * i, 120, 2010 + i);
    }
    catch (Exception exc)
    {
        Console.WriteLine("Wrong object creation: " + exc);
    }
}

for (int i = cars.Length / 2; i < cars.Length; i++)
{
    try
    {
        cars[i] = (Car)cars[i - cars.Length / 2].Clone();
    }
    catch (Exception exc)
    {
        Console.WriteLine("Error while trying to clone: " + exc);
    }
}

Console.WriteLine("\n\nBefore sorting:");
showArray(cars);

// sorting cars array
Array.Sort(cars);

Console.WriteLine("\n\nAfter sorting:");
showArray(cars);

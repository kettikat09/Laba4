//Завдання 2. Транспорт. Визначити ієрархію рухомого складу залізничного транспорту. Створити пасажирський поїзд.
//Підрахувати загальну чисельність пасажирів і багажу. Провести сортування вагонів поїзда на основі рівня комфортності.
//Знайти в поїзді вагони, відповідні заданому діапазону параметрів числа пасажирів.
using Newtonsoft.Json;
using System;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        Train t = new Train(5);
        t.All();
        Console.WriteLine();
        t.SortByComfort();
        t.All();
        //   t.ShowAllVagonsBellowX(15);
        Console.WriteLine("Total pasangers: " + Train.TotalPassengers);
        Console.WriteLine("Total bags: " + Train.TotalBags);
    }
}
public class Train
{
    public Vagon[] vagons;
    public static int TotalPassengers;
    public static int TotalBags;
    public Train(int Amount_Of_Vagons)
    {
        vagons = new Vagon[Amount_Of_Vagons];
        Random r = new Random();
        for (int i = 0; i < vagons.Length; i++)
        {
            vagons[i] = new Vagon(r.Next(1, 3), r.Next(1, 40), r.Next(1, 40));
        }
        for (int i = 0; i < vagons.Length; i++)
        {
            TotalBags += vagons[i].Bags;
            TotalPassengers += vagons[i].Passengers;
        }

    }
    public void SortByComfort()
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            for (int j = 0; j < vagons.Length; j++)
            {
                if (vagons[i].ComfLvl < vagons[j].ComfLvl)
                {
                    (vagons[i], vagons[j]) = (vagons[j], vagons[i]);
                }
            }
        }
    }

    public void ShowAllVagonsBellowX(int X)
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            if (vagons[i].Passengers < X)
            {
                Console.WriteLine(vagons[i].Info());
            }
        }
    }

    public void All()
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            Console.WriteLine(vagons[i].Info());
        }
    }
}
public class Vagon
{
    public int ComfLvl;
    public int Passengers;
    public int Bags;
    public Vagon(int comfLvl, int passengers, int bags)
    {
        ComfLvl = comfLvl;
        Passengers = passengers;
        Bags = bags;
    }
    public string Info() => $"Comfort LVL: {ComfLvl}, Passangers: {Passengers}, Bags: {Bags}";
}


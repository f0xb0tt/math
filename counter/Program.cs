using System.Numerics;

class Program
{
    static void Main()
    {
        Console.Write("count to:");
        int input = int.Parse(Console.ReadLine());
        BigInteger count = (BigInteger)Math.Pow(10,input);
        DateTime dateTime = DateTime.Now;
        for (BigInteger i = 0; i <= count; i++)
        {
            Console.WriteLine($"{i.ToString()}");
        }
        Console.WriteLine($"counted to {count} in {(DateTime.Now - dateTime).TotalHours} hours");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }       
}
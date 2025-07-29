using System.Numerics;
while (true)
{
    Console.Clear();
    Console.Write("Enter a number:");
    BigInteger inputNumber = BigInteger.Parse(Console.ReadLine()!);
    Dictionary<BigInteger, BigInteger> numberList = new Dictionary<BigInteger, BigInteger>();

    DateTime startOptimized = DateTime.Now;
    for (BigInteger currentNumber = 1; currentNumber <= inputNumber; currentNumber++)
    {
        double percentage = (double)((double)currentNumber / (double)inputNumber);
        percentage *= 100;
        int percentageInt = (int)Math.Floor(percentage);
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"[{new String('|', percentageInt)}{new String(' ', 100 - percentageInt)}]");
        BigInteger number = currentNumber;
        while (!numberList.ContainsKey(number))
        {
            BigInteger newNumber;
            if (number % 2 == 0)
            {
                newNumber = number / 2;
            }
            else
            {
                newNumber = (3 * number) + 1;
            }
            numberList[number] = newNumber;
            number = newNumber;
        }
    }

    Console.WriteLine($"\nOptimized version took: {(DateTime.Now - startOptimized).TotalSeconds}s");

    DateTime startUnoptimized = DateTime.Now;
    Dictionary<BigInteger, List<BigInteger>> unoptimizedList = new Dictionary<BigInteger, List<BigInteger>>();
    for (BigInteger i = 1; i < inputNumber; i++)
    {
        unoptimizedList[i] = new List<BigInteger>();
    }
    for (BigInteger currentNumber = 1; currentNumber <= inputNumber; currentNumber++)
    {
        double percentage = (double)((double)currentNumber / (double)inputNumber);
        percentage *= 100;
        int percentageInt = (int)Math.Floor(percentage);
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"[{new String('|', percentageInt)}{new String(' ', 100 - percentageInt)}]");
        BigInteger calcNum = currentNumber;
        while (calcNum != 1)
        {
            unoptimizedList[currentNumber].Add(calcNum);
            if (calcNum % 2 == 0)
            {
                calcNum /= 2;
            }
            else
            {
                calcNum = 3 * calcNum + 1;
            }
        }
    }

    Console.WriteLine($"\nUnoptimized version took: {(DateTime.Now - startUnoptimized).TotalSeconds}s");
    Console.WriteLine($"Optimized version saved {((DateTime.Now - startUnoptimized) - (startUnoptimized - startOptimized)).TotalSeconds}s");


    //for (BigInteger i = 1; i < inputNumber; i++)
    //{
    //    Console.WriteLine($"{i} => {numberList[i]}");
    //}

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey(true);
}
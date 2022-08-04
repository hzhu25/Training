namespace ConsoleApp1;

public class LoopsAndOperators
{
    public void FizzBuzz(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            if (i % 15 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine($"{i}");
            }
        }
    }

    public void PrintAPyramid(int nums)
    {
        for (int i = 0; i <= nums; i++) 
        { 
            for (int j = 1; j <= nums - i; j++) 
            {  
                Console.Write(" ");  
            } 
            for (int j = 1; j <= i * 2 - 1; j++) 
            {  
                Console.Write("*");  
            } 
            Console.WriteLine(); 
        }
    }

    public void GuessNumber()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number: "); 
        int guessedNumber = int.Parse(Console.ReadLine()); 
        if (guessedNumber == correctNumber) 
        { 
            Console.WriteLine("Correct!"); 
        } 
        if (guessedNumber < 1 || guessedNumber > 3) 
        { 
            Console.WriteLine("Non-Valid Guess!"); 
        } 
        if (guessedNumber < correctNumber) 
        { 
            Console.Write("Enter a larger number: "); 
            guessedNumber = int.Parse(Console.ReadLine()); 
            if (guessedNumber < correctNumber) 
            { 
                Console.Write("Enter a larger number: "); 
                guessedNumber = int.Parse(Console.ReadLine()); 
            } 
            else 
            { 
                Console.WriteLine("Correct!"); 
            } 
        } 
        if (guessedNumber > correctNumber) 
        { 
            Console.Write("Enter a smaller number: "); 
            guessedNumber = int.Parse(Console.ReadLine()); 
            if (guessedNumber > correctNumber) 
            { 
                Console.Write("Enter a larger number: "); 
                guessedNumber = int.Parse(Console.ReadLine()); 
            } 
            else 
            { 
                Console.WriteLine("Correct!"); 
            } 
        } 
    }


    public void DaysOld()
    {
        Console.WriteLine("Enter the year of your birth date: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the month of your birth date: ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the day of your birth date: ");
        int day = Convert.ToInt32(Console.ReadLine());
        DateTime DateOfBirth = new DateTime(year, month, day);
        double days = (DateTime.Today - DateOfBirth).TotalDays;
        Console.WriteLine($"you are {days} days old!");
        int daysToNextAnniversary = Convert.ToInt32(10000 - (days % 10000));
        Console.WriteLine($"The days until the next anniversary is {daysToNextAnniversary}");
    }
    
    
    public void Greetings(int hour)
    {
        if (hour < 12)
        {
            Console.WriteLine("Good Morning");
        } 
        else if (hour >= 12 && hour < 18)
        {
            Console.WriteLine("Good Afternoon");
        } 
        else if (hour >= 18 && hour < 20)
        {
            Console.WriteLine("Good Evening");
        } 
        else
        {
            Console.WriteLine("Good Night!");
        }
    }


    public void CountByIncrements()
    {    for (int i = 0; i <= 24; i++) 
        { 
            if (i != 24) 
            { 
                Console.Write($"{i}, "); 
            } 
            else 
            { 
                Console.Write($"{i}"); 
            } 
        } 
        Console.WriteLine(); 
        for (int i = 0; i <= 24; i+=2) 
        { 
            if (i != 24) 
            { 
                Console.Write($"{i}, "); 
            } 
            else 
            { 
                Console.Write($"{i}"); 
            } 
        } 
        Console.WriteLine();
        for (int i = 0; i <= 24; i += 3)
        {
            if (i != 24)
            {
                Console.Write($"{i}, ");
            }else 
            { 
                Console.Write($"{i}"); 
            } 
        } 
        Console.WriteLine(); 
        for (int i = 0; i <= 24; i += 4) 
        { 
            if (i != 24) 
            { 
                Console.Write($"{i}, "); 
            } 
            else 
            { 
                Console.Write($"{i}"); 
            }
        }
    }
}


namespace ConsoleApp3;

public class WorkWithMethods
{
    public static int[] GenerateNumbers(int n)
    {

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    public static int[] Reverse(int[] nums)
    {
        int[] result = new int[nums.Length];
        int j = nums.Length - 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[j];
            j--;
        }
        return result;
    }

    public static void PrintNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write($"{nums[i]} ");
        }
    }
    
    public static int Fibonacci(int num)
    {
        int firstNum = 1;
        int secondNum = 1;
        if (num == 1)
        {
            return firstNum;
        }
        if (num == 2)
        {
            return secondNum;
        }
        return Fibonacci(num - 1) + Fibonacci(num - 2);
    }
    
    
}
namespace ConsoleApp2;

public class PracticeArrays
{
    public void CopyAnArray(int[] arr)
    {
        int[] NewArr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            NewArr[i] = arr[i];
        }
    }

    public void ManageListOfElements()
    {
        List<string> list = new List<string>(); 
        string input; 
        while (true) 
        { 
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):"); 
            input = Console.ReadLine(); 
            string act = input.Substring(0, 2); 
            switch (act) 
            { 
                case "+ ": 
                    list.Add(input.Substring(2)); 
                    break; 
                case "- ": 
                    list.Remove(input.Substring(2)); 
                    break; 
                case "--": 
                    if (input.Length == 2) 
                    { 
                        list.Clear(); 
                        break; 
                    } 
                    else 
                    { 
                        Console.WriteLine("If trying to clear list, please use exactly '--'"); 
                        break; 
                    } 
                default: 
                    Console.WriteLine("Please enter a valid command."); 
                    break; 
            } 
            Console.WriteLine("List Contents: "); 
            for (int i = 0; i < list.Count; i++) 
            { 
                Console.WriteLine(list[i]); 
            } 
        } 
    }

    static bool IsPrime(int n) 
    { 
        if (n == 2 || n == 3) 
            return true; 
        if (n <= 1 || n % 2 == 0 || n % 3 == 0) 
            return false; 
        for (int i = 5; i * i <= n; i += 6) 
        { 
            if (n % i == 0 || n % (i + 2) == 0) 
                return false; 
        } 
        return true; 
    } 
    static int[] FindPrimesInRange(int startNum, int endNum) 
    { 
        List<int> primes = new List<int>(); 
        for (int i = startNum; i <= endNum; i++) 
        { 
            if (IsPrime(i)) 
            { 
                primes.Add(i); 
            } 
        } 
        return primes.ToArray(); 
    } 
    
    public int[] RotateArray(string input, int k)
    {
        string[] input_arr = input.Split(' ');
        int size = input_arr.Length;
        int[] input_int = input_arr.Select(input => int.Parse(input)).ToArray();
        int[] sum = new int[size];
        
        for (int i = 1; i <= k; i++)
        {
            int starter = size - i;
            for (int j = 0; j < size; j++)
            {
                sum[j] += input_int[(starter + j) % size];
            }
        }

        foreach (int i in sum)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        return sum;
    }
    
    public void LongestSequence(int[] arr)
    {
        int size = 0;
        int item = 0;
        int i = 0;
        int j = 0;
        while (j < arr.Length)
        {
            while (j < arr.Length - 1 && arr[j + 1] == arr[j])
            {
                j++;
            }
            if (j - i + 1 > size)
            {
                size = j - i + 1;
                item = arr[i];
            }
            j++;
            i = j;
        }
        for (int x = 0; x < size; x++)
        {
            Console.Write(item + " ");
        }
    }
    
    public void MostFrequentNum(string input)
    {
        // sorry I really don't know how to implement this question
    }
}

    
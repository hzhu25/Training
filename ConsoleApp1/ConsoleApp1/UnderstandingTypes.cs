namespace ConsoleApp1;

public class UnderstandingTypes
{   
    public void SizesAndRanges()
    {
        Console.WriteLine($"Number of bytes for sbyte is {sizeof(sbyte)}");
        Console.WriteLine($"Minimum value for sbyte is {sbyte.MinValue}");
        Console.WriteLine($"Maximum value for sbyte is {sbyte.MaxValue}");
        
        Console.WriteLine($"Number of bytes for byte is {sizeof(byte)}");
        Console.WriteLine($"Minimum value for byte is {byte.MinValue}");
        Console.WriteLine($"Maximum value for byte is {byte.MaxValue}");
        
        Console.WriteLine($"Number of bytes for short is {sizeof(short)}");
        Console.WriteLine($"Minimum value for short is {short.MinValue}");
        Console.WriteLine($"Maximum value for short is {short.MaxValue}");
        
        Console.WriteLine($"Number of bytes for ushort is {sizeof(ushort)}");
        Console.WriteLine($"Minimum value for ushort is {ushort.MinValue}");
        Console.WriteLine($"Maximum value for ushort is {ushort.MaxValue}");
        
        Console.WriteLine($"Number of bytes for int is {sizeof(int)}");
        Console.WriteLine($"Minimum value for int is {int.MinValue}");
        Console.WriteLine($"Maximum value for int is {int.MaxValue}");
        
        Console.WriteLine($"Number of bytes for uint is {sizeof(uint)}");
        Console.WriteLine($"Minimum value for uint is {uint.MinValue}");
        Console.WriteLine($"Maximum value for uint is {uint.MaxValue}");
        
        Console.WriteLine($"Number of bytes for long is {sizeof(long)}");
        Console.WriteLine($"Minimum value for long is {long.MinValue}");
        Console.WriteLine($"Maximum value for long is {long.MaxValue}");
        
        Console.WriteLine($"Number of bytes for ulong is {sizeof(ulong)}");
        Console.WriteLine($"Minimum value for ulong is {ulong.MinValue}");
        Console.WriteLine($"Maximum value for ulong is {ulong.MaxValue}");
        
        Console.WriteLine($"Number of bytes for float is {sizeof(float)}");
        Console.WriteLine($"Minimum value for float is {float.MinValue}");
        Console.WriteLine($"Maximum value for float is {float.MaxValue}");
        
        Console.WriteLine($"Number of bytes for double is {sizeof(double)}");
        Console.WriteLine($"Minimum value for double is {double.MinValue}");
        Console.WriteLine($"Maximum value for double is {double.MaxValue}");
        
        Console.WriteLine($"Number of bytes for decimal is {sizeof(decimal)}");
        Console.WriteLine($"Minimum value for decimal is {decimal.MinValue}");
        Console.WriteLine($"Maximum value for decimal is {decimal.MaxValue}");
        
    }

    public void CenturyConvertion(uint century)
    {
        uint years = century * 100;
        uint days = years * 365;
        uint hours = days * 24;
        uint minutes = hours * 60;
        uint seconds = minutes * 60;
        ulong milliseconds = seconds * 1000;
        ulong microseconds = milliseconds * 1000;
        ulong nanoseconds = microseconds * 1000;
        Console.WriteLine(
            $"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}
    

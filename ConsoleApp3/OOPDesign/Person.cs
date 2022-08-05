namespace OOPDesign;

public abstract class Person : IPersonService
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Address(string address)
    {
        return address;
    }

    public int Age(int year)
    {
        int currYear = DateTime.Now.Year;
        return currYear - year;
    }

    public decimal Salary(decimal hourlyPay)
    {
        decimal result = (hourlyPay * 8) * 5 * 4;
        return result;
    }
}
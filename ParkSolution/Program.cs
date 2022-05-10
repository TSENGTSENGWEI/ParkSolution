using ParkSolution;

var test = new TestCase();
Console.WriteLine(test.Test(new DateTime(2022, 5, 2, 23, 48, 0), new DateTime(2022, 5, 3, 0, 0, 0), new SolutionC()).TotalFee);

public class TestCase
{
    public ParkingFee Test(DateTime start, DateTime end, ICalcFee Solution)
    {
        return new ParkingFee(start, end, Solution);
    }
}

public class TestData
{
    public int CaseID { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int ExceptDay { get; set; }
    public int ExceptFee { get; set; }
}
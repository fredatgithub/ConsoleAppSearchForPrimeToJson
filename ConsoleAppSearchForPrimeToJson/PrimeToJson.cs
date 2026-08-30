namespace ConsoleAppSearchForPrimeToJson
{
  public class PrimeToJson
  {
    public DateTime StartCalculationDate { get; set; }
    public DateTime EndCalculationDate { get; set; }
    public TimeSpan CalculationDuration { get; set; }

    public ulong NumberOfPrimes { get; set; } = 0;
    public ulong FirstPrime { get; set; } = 0;
    public ulong LastPrime { get; set; } = 0;
    public List<ulong> Primes { get; set; } = new List<ulong>();

    public PrimeToJson() { }
  }
}

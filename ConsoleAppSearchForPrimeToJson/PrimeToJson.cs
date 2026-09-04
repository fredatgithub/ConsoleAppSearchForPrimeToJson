using System.Text.Json;

namespace ConsoleAppSearchForPrimeToJson
{
  public class PrimeToJson
  {
    public string FileVersion { get; set; } = "1.0";
    public DateTime StartCalculationDate { get; set; } = DateTime.Now;
    public DateTime EndCalculationDate { get; set; } = DateTime.Now;
    public Enumerations.CalculationType CalculationType { get; set; } = Enumerations.CalculationType.Ulong;

    public TimeSpan CalculationDuration { get; set; } = TimeSpan.Zero;
    public ulong NumberOfPrimes { get; set; } = 0;
    public ulong FirstPrime { get; set; } = 1;
    public ulong LastPrime { get; set; } = 1;
    public List<ulong> Primes { get; set; } = new List<ulong>();

    public string PreviousFileName { get; set; } = string.Empty;
    public string NextFileName { get; set; } = string.Empty;

    public override string ToString()
    {
      return $"FileVersion: {FileVersion}\n" +
             $"StartCalculationDate: {StartCalculationDate}\n" +
             $"EndCalculationDate: {EndCalculationDate}\n" +
             $"CalculationDuration: {CalculationDuration}\n" +
             $"NumberOfPrimes: {NumberOfPrimes}\n" +
             $"FirstPrime: {FirstPrime}\n" +
             $"LastPrime: {LastPrime}\n" +
             $"Primes: [{string.Join(", ", Primes)}]";
    }

    public string ToStringShort()
    {
      return $"FileVersion: {FileVersion}\n" +
             $"StartCalculationDate: {StartCalculationDate}\n" +
             $"EndCalculationDate: {EndCalculationDate}\n" +
             $"CalculationDuration: {CalculationDuration}\n" +
             $"NumberOfPrimes: {NumberOfPrimes}\n" +
             $"FirstPrime: {FirstPrime}\n" +
             $"LastPrime: {LastPrime}";
    }

    public string ToJson()
    {
      return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    public static PrimeToJson FromJson(string json)
    {
      if (string.IsNullOrWhiteSpace(json))
      {
        return new PrimeToJson();
      }

#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
      return JsonSerializer.Deserialize<PrimeToJson>(json);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    public PrimeToJson() { }
  }
}

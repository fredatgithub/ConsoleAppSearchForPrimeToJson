using System.Text.Json;

namespace ConsoleAppSearchForPrimeToJson
{
  internal class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("Calcul des nombres premiers et enregistrement dans un fichier JSON");
      const string fileName = "primes_2.json";
      const string filenameTemplate = "primes_{0}.json";
      string json = File.Exists(fileName) ? File.ReadAllText(fileName) : string.Empty;
      const string currentFileNameTextFile = "primes-current-Filename.txt";
      string currentFileName = File.Exists(currentFileNameTextFile) ? File.ReadAllText(currentFileNameTextFile) : string.Empty;
      if (string.IsNullOrEmpty(currentFileName))
      {
        try
        {
          File.WriteAllText(currentFileNameTextFile, fileName);
        }
        catch (Exception exception)
        {
          Console.WriteLine($"Error writing to file {currentFileNameTextFile}: {exception.Message}");
        }
      }

      bool firstTime = string.IsNullOrEmpty(json);
      var primes = new PrimeToJson();
      if (!firstTime)
      {
        primes = JsonSerializer.Deserialize<PrimeToJson>(json);
      }
      else
      {
        primes.FirstPrime = 1;
        primes.LastPrime = 1;
        primes.StartCalculationDate = DateTime.Now;
        primes.PreviousFileName = fileName;
      }

      const ulong maxcounter = 5_000;
      if (primes.LastPrime == 1)
      {
        primes.LastPrime = 2;
        primes.FirstPrime = 2;
      }
      else if ((primes.LastPrime) % 2 != 0)
      {
        primes.LastPrime += 1;
      }

      ulong startNumber = primes.LastPrime;
      primes.LastPrime = startNumber;
      primes.StartCalculationDate = DateTime.Now;
      primes.FirstPrime = startNumber;
      for (ulong number = startNumber; number < startNumber + maxcounter; number++)
      {
        if (IsPrime(number))
        {
          primes.Primes.Add(number);
          primes.LastPrime = number;
        }
      }

      primes.EndCalculationDate = DateTime.Now;
      primes.CalculationDuration = primes.EndCalculationDate - primes.StartCalculationDate;
      primes.NumberOfPrimes = (ulong)primes.Primes.Count;
      primes.PreviousFileName = currentFileName;
      primes.NextFileName = string.Format(filenameTemplate, primes.LastPrime);
      primes.CalculationType = nameof(Enumerations.CalculationType.Ulong);
      // Save the updated primes to the JSON file
      try
      {
        string updatedJson = JsonSerializer.Serialize(primes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, updatedJson);
        display($"Primes saved to {fileName}");
      }
      catch (Exception exception)
      {
        display($"Error writing to file {fileName}: {exception.Message}");
      }

      display("Press any key to exit:");
      Console.ReadKey();
    }

    private static bool IsPrime(ulong number)
    {
      if (number < 2) return false;
      if (number == 2) return true;
      if (number % 2 == 0) return false;
      for (ulong i = 3; i <= Math.Sqrt(number); i += 2)
      {
        if (number % i == 0) return false;
      }

      return true;
    }
  }
}

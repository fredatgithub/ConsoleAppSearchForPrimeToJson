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
      Console.WriteLine($"Starting prime calculation from {startNumber} for {maxcounter} numbers...");
      Console.WriteLine("Calculating primes...");

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
      double squareRoot = Math.Sqrt(number);
      for (ulong i = 3; i <= squareRoot; i += 2)
      {
        if (number % i == 0) return false;
      }

      return true;
    }

    private static string GetNextFileName(string currentFileName)
    {
      if (string.IsNullOrEmpty(currentFileName))
      {
        return "primes_2.json";
      }

      string[] parts = currentFileName.Split('_', '.');
      if (parts.Length < 2 || !ulong.TryParse(parts[1], out ulong lastPrime))
      {
        return "primes_2.json";
      }

      ulong nextLastPrime = lastPrime + 1;
      return $"primes_{nextLastPrime}.json";
    }

    private static string GetPreviousFileName(string currentFileName)
    {
      if (string.IsNullOrEmpty(currentFileName))
      {
        return string.Empty;
      }

      string[] parts = currentFileName.Split('_', '.');
      if (parts.Length < 2 || !ulong.TryParse(parts[1], out ulong lastPrime))
      {
        return string.Empty;
      }

      ulong previousLastPrime = lastPrime > 2 ? lastPrime - 1 : 2;
      return $"primes_{previousLastPrime}.json";
    }

    private static void SaveCurrentFileName(string currentFileName)
    {
      const string currentFileNameTextFile = "primes-current-Filename.txt";
      try
      {
        File.WriteAllText(currentFileNameTextFile, currentFileName);
      }
      catch (Exception exception)
      {
        Console.WriteLine($"Error writing to file {currentFileNameTextFile}: {exception.Message}");
      }
    }

    private static string LoadCurrentFileName()
    {
      const string currentFileNameTextFile = "primes-current-Filename.txt";
      try
      {
        return File.Exists(currentFileNameTextFile) ? File.ReadAllText(currentFileNameTextFile) : string.Empty;
      }
      catch (Exception exception)
      {
        Console.WriteLine($"Error reading from file {currentFileNameTextFile}: {exception.Message}");
        return string.Empty;
      }
    }

    private static void DisplayPrimes(PrimeToJson primes)
    {
      Console.WriteLine($"First Prime: {primes.FirstPrime}");
      Console.WriteLine($"Last Prime: {primes.LastPrime}");
      Console.WriteLine($"Number of Primes: {primes.NumberOfPrimes}");
      Console.WriteLine($"Calculation Duration: {primes.CalculationDuration}");
      Console.WriteLine($"Start Calculation Date: {primes.StartCalculationDate}");
      Console.WriteLine($"End Calculation Date: {primes.EndCalculationDate}");
      Console.WriteLine($"Previous File Name: {primes.PreviousFileName}");
      Console.WriteLine($"Next File Name: {primes.NextFileName}");
      Console.WriteLine($"Calculation Type: {primes.CalculationType}");
    }

    private static void DisplayPrimesList(PrimeToJson primes)
    {
      Console.WriteLine("Primes List:");
      foreach (var prime in primes.Primes)
      {
        Console.WriteLine(prime);
      }
    }

    private static void DisplayPrimesSummary(PrimeToJson primes)
    {
      Console.WriteLine($"First Prime: {primes.FirstPrime}, Last Prime: {primes.LastPrime}, Number of Primes: {primes.NumberOfPrimes}");
    }

    private static void DisplayPrimesDetails(PrimeToJson primes)
    {
      Console.WriteLine($"First Prime: {primes.FirstPrime}");
      Console.WriteLine($"Last Prime: {primes.LastPrime}");
      Console.WriteLine($"Number of Primes: {primes.NumberOfPrimes}");
      Console.WriteLine($"Calculation Duration: {primes.CalculationDuration}");
      Console.WriteLine($"Start Calculation Date: {primes.StartCalculationDate}");
      Console.WriteLine($"End Calculation Date: {primes.EndCalculationDate}");
      Console.WriteLine($"Previous File Name: {primes.PreviousFileName}");
      Console.WriteLine($"Next File Name: {primes.NextFileName}");
      Console.WriteLine($"Calculation Type: {primes.CalculationType}");
    }

    private static string[] GetAllJsonFilesInDirectory()
    {
      string[] jsonFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json");
      return jsonFiles;
    }

    private static string[] RemoveNonPrimeJsonFiles(string[] jsonFiles)
    {
      List<string> primeJsonFiles = new List<string>();
      foreach (var file in jsonFiles)
      {
        if (file.Contains("primes_"))
        {
          primeJsonFiles.Add(file);
        }
      }
      return [.. primeJsonFiles];
    }

    private static PrimeToJson GetLatestPrimesFromJsonFiles(string[] jsonFiles)
    {
      PrimeToJson latestPrimes = null;
      DateTime latestDate = DateTime.MinValue;
      foreach (var file in jsonFiles)
      {
        string json = File.ReadAllText(file);
        var primes = JsonSerializer.Deserialize<PrimeToJson>(json);
        if (primes != null && primes.EndCalculationDate > latestDate)
        {
          latestDate = primes.EndCalculationDate;
          latestPrimes = primes;
        }
      }

      return latestPrimes;
    }
  }
}

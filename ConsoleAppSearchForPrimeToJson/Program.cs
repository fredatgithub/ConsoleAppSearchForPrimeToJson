namespace ConsoleAppSearchForPrimeToJson
{
  internal class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("Calcul des nombres premiers et enregistrement dans un fichier JSON");
      string fileName = "primes.json";
      string json = File.Exists(fileName) ? File.ReadAllText(fileName) : string.Empty;
      string currentFileName = "primes1.json";

      display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}

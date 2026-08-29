namespace ConsoleAppSearchForPrimeToJson
{
  internal class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("Calcul des nombres premiers et enregistrement dans un fichier JSON");


      display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}

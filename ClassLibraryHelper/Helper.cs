namespace ClassLibraryHelper
{
  public static class Helper
  {
    public static bool IsPrime(ulong number)
    {
      if (number < 2) return false;
      if (number == 2 || number == 3 || number == 5 || number == 7) return true;
      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0) return false;
      double squareRoot = Math.Sqrt(number);
      for (ulong i = 11; i <= squareRoot; i += 2)
      {
        if (number % i == 0) return false;
      }

      return true;
    }
  }
}

namespace TestProjectHelper
{
  [TestClass]
  public sealed class TestPrimes
  {
    [TestMethod]
    public void TestMethod_First_values()
    {
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(2));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(3));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(5));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(7));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(11));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(1));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(4));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(6));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(8));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(9));
    }

    [TestMethod]
    public void TestMethod_Large_values()
    {
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(7919));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(104729));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(100000));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(123456));
    }

    [TestMethod]
    public void TestMethod_Edge_cases()
    {
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(0));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(1));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(2));
      Assert.IsTrue(ClassLibraryHelper.Helper.IsPrime(3));
      Assert.IsFalse(ClassLibraryHelper.Helper.IsPrime(4));
    }

    [TestMethod]
    public void TestMethod_Performance()
    {
      var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      for (ulong i = 0; i < 10_000; i++)
      {
        ClassLibraryHelper.Helper.IsPrime(i);
      }

      stopwatch.Stop();
      Console.WriteLine($"Time taken to check primes up to 10_000: {stopwatch.ElapsedMilliseconds} ms");
    }
  }
}

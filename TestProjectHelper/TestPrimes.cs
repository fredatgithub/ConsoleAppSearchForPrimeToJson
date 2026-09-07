using ClassLibraryHelper;

namespace TestProjectHelper
{
  [TestClass]
  public sealed class TestPrimes
  {
    [TestMethod]
    public void TestMethod_First_values()
    {
      Assert.IsTrue(Helper.IsPrime(2));
      Assert.IsTrue(Helper.IsPrime(3));
      Assert.IsTrue(Helper.IsPrime(5));
      Assert.IsTrue(Helper.IsPrime(7));
      Assert.IsTrue(Helper.IsPrime(11));
      Assert.IsFalse(Helper.IsPrime(1));
      Assert.IsFalse(Helper.IsPrime(4));
      Assert.IsFalse(Helper.IsPrime(6));
      Assert.IsFalse(Helper.IsPrime(8));
      Assert.IsFalse(Helper.IsPrime(9));
    }

    [TestMethod]
    public void TestMethod_Large_values()
    {
      Assert.IsTrue(Helper.IsPrime(7919));
      Assert.IsTrue(Helper.IsPrime(104729));
      Assert.IsFalse(Helper.IsPrime(100000));
      Assert.IsFalse(Helper.IsPrime(123456));
    }

    [TestMethod]
    public void TestMethod_Edge_cases()
    {
      Assert.IsFalse(Helper.IsPrime(0));
      Assert.IsFalse(Helper.IsPrime(1));
      Assert.IsTrue(Helper.IsPrime(2));
      Assert.IsTrue(Helper.IsPrime(3));
      Assert.IsFalse(Helper.IsPrime(4));
    }

    [TestMethod]
    public void TestMethod_Performance()
    {
      var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      for (ulong i = 0; i < 10_000; i++)
      {
        Helper.IsPrime(i);
      }

      stopwatch.Stop();
      Console.WriteLine($"Time taken to check primes up to 10_000: {stopwatch.ElapsedMilliseconds} ms");
    }

    [TestMethod]
    [DataRow(2UL, true)]
    [DataRow(3UL, true)]
    [DataRow(4UL, false)]
    [DataRow(5UL, true)]
    [DataRow(6UL, false)]
    [DataRow(7UL, true)]
    [DataRow(8UL, false)]
    [DataRow(9UL, false)]
    [DataRow(10UL, false)]
    [DataRow(11UL, true)]
    [DataRow(12UL, false)]
    [DataRow(13UL, true)]
    [DataRow(14UL, false)]
    [DataRow(15UL, false)]
    [DataRow(16UL, false)]
    [DataRow(17UL, true)]
    [DataRow(18UL, false)]
    [DataRow(19UL, true)]
    [DataRow(20UL, false)]
    public void TestMethod_DataDriven(ulong number, bool expected)
    {
      bool result = Helper.IsPrime(number);
      Assert.AreEqual(expected, result);
    }
  }
}

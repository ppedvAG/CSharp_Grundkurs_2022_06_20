using M012;

namespace M012_Tests;

[TestClass]
public class UnitTest1
{
	Rechner Rechner;

	[TestInitialize]
	public void Initialize()
	{
		Rechner = new Rechner();
	}

	[TestCleanup]
	public void Cleanup()
	{
		Rechner = null;
	}

	[TestCategory("Erfolgstest")]
	[TestMethod]
	public void TestAddiere()
	{
		int summe = Rechner.Addiere(4, 6);
		Assert.AreEqual(10, summe);
	}

	[TestCategory("Fehlertest")]
	[TestMethod]
	public void TesteAddiereFehler()
	{
		int sum = Rechner.Addiere(3, 5);
		Assert.AreNotEqual(2, sum);
	}
}
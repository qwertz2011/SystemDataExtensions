using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using SystemDataExtensions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PropertyNameAliasTestMethod()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Test");

            DataRow row = table.NewRow();
            row["Test"] = "Blub";

            var result = row.ToObject<Dummy>();
            Assert.AreEqual<string>("Blub", result.Name);
        }

        [TestMethod]
        public void PropertyNameTestMethod()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");

            DataRow row = table.NewRow();
            row["Name"] = "Blub";

            var result = row.ToObject<Dummy>();

            Assert.AreEqual<string>("Blub", result.Name);
        }
    }
}

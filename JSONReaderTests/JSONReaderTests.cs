using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_Value_Retriever;
using System.IO;

namespace JSONReaderTests
{
    [TestClass]
    public class JSONReaderTests
    {

        [TestMethod]
        public void JSONReaderFromPath()
        {
            string[] paths = { @"C:\Users", "dev", "JSONS", "DummyJSON.json" };
            string fullPath = Path.Combine(paths);
            JSONReader reader = JSONReader.ParseJsonPath(fullPath);
            Assert.IsNotNull(reader);

            string value = reader.GetValue("Dummy");
            Assert.AreEqual("JSON", value);

        }
    }
}

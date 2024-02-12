
namespace UnitTests
{
    /*
     Due to an error that occurs when trying to refrence the main client project methods that needed to be tested were copied over
     */

    [TestClass]
    public class UnitTests
    {
        
        [TestMethod]
        public void WriteToBackendTest()
        {
            Database.SendPostRequestJSON("https://localhost:44390/api/data", "testApiKey", "D:\\Source\\Repos\\HonorsFinal\\UnitTests\\bin\\Debug\\net7.0\\test.json");

            string response = Database.SendGetRequest("https://localhost:44390/api/data", "testApiKey");

            Assert.AreEqual(response, "OK");
        }
        
        [TestMethod]
        public void GetFromBackend()
        {
            string response = Database.SendGetRequest("https://localhost:44390/api/data", "testApiKey");

            Assert.AreEqual(response, "OK");
        }

        [TestMethod]
        public void iTunesLookup()
        {
            string response = ItunesLookup.lookupPodcast("science");

            Assert.IsNotNull(response);
        }

    }

    
    
}
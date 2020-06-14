using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.Data;
using System.IO;

namespace opg_201910_interview.Test
{
    [TestClass]
    public class ClientDataTest
    {
        private readonly string clientIdA;
        private readonly string folderA;
        private readonly string sortOrderA;
        private readonly string clientIdB;
        private readonly string folderB;
        private readonly string sortOrderB;

        public ClientDataTest()
        {
            clientIdA = "1001";
            folderA = "../../../../../src/UploadFiles/ClientA";
            sortOrderA = "shovel,waghor,blaze,discus";

            clientIdB = "2001";
            folderB = "../../../../../src/UploadFiles/ClientB";
            sortOrderB = "orca,widget,eclair,talon";
    
        }

        [TestMethod]
        public void GetClientDataFromDirectoryTestClientA()
        {
            var actualResult = ClientData.GetClientDataFromDirectory(clientIdA, folderA, sortOrderA);

            string expected = "[{\"clientId\":\"1001\",\"fileName\":\"shovel-2000-01-01.xml\"},{\"clientId\":\"1001\",\"fileName\":\"waghor-2012-06-20.xml\"},{\"clientId\":\"1001\",\"fileName\":\"blaze-2018-05-01.xml\"},{\"clientId\":\"1001\",\"fileName\":\"blaze-2019-01-23.xml\"},{\"clientId\":\"1001\",\"fileName\":\"discus-2015-12-16.xml\"}]";
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        public void GetClientDataFromDirectoryTestClientB()
        {
            var actualResult = ClientData.GetClientDataFromDirectory(clientIdB, folderB, sortOrderB);

            string expected = "[{\"clientId\":\"2001\",\"fileName\":\"orca_20130219.xml\"},{\"clientId\":\"2001\",\"fileName\":\"orca_20170916.xml\"},{\"clientId\":\"2001\",\"fileName\":\"widget_20101101.xml\"},{\"clientId\":\"2001\",\"fileName\":\"eclair_20180908.xml\"},{\"clientId\":\"2001\",\"fileName\":\"talon_20150831.xml\"}]";
            Assert.AreEqual(expected, actualResult);
        }
    }
}

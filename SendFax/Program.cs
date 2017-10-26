using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendFax.FxApi;
using System.IO;

namespace SendFax
{
    class Program
    {
        static wfApi api = new wfApi();

        static void Main(string[] args)
        {
            long userID = api.AuthenticateUser("piotr.kirklewski@engie.com", "piotr.kirklewski@engie.com");
            string[] trackLabels = new string[1];
            trackLabels[0] = "tracking label";
            string[] trackValues = new string[1];
            trackValues[0] = "tracking key";
            string[] recpNames = new string[1];
            recpNames[0] = "test recp";
            string[] recpAddresses = new string[1];
            recpAddresses[0] = "+17208704141";
            bool[] recpRawFax = new bool[1];
            recpRawFax[0] = false;
            string[] docName = new string[1];
            docName[0] = "pdf-sample.pdf";
            object[] docBytes = new object[1];
            docBytes[0] = File.ReadAllBytes(@"C:\pdf-sample.pdf");
            bool[] isMerge = new bool[1];
            isMerge[0] = false;

            var results =  api.SendMessage(userID, "Peter", "Engie", "Test Fax", "Test Note", trackLabels, trackValues, recpNames, recpAddresses, recpRawFax, docName, docBytes, isMerge);
            var status = api.GetMessageStatus(results);
            System.Threading.Thread.Sleep(10);
            Console.WriteLine(status);
            Console.ReadLine();
        }
    }
}

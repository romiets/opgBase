using Newtonsoft.Json;
using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Data
{
    public static class ClientData
    {

        public static string GetClientDataFromDirectory(string clientId, string folder, string sortOrder)
        {
            try
            {

                var sortSplit = sortOrder.Split(",");
                string[] filePaths = Directory.GetFiles(folder);
                List<Client> client = new List<Client>();

                foreach (string file in filePaths)
                {
                    int i = 0;

                    foreach (string sort in sortSplit)
                    {
                        if (file.IndexOf(sort) > 0)
                        {
                            var strDate = Path.GetFileNameWithoutExtension(file).Remove(0, sort.Length + 1);
                            DateTime date = DateTime.ParseExact(strDate.Replace("-", ""),
                                      "yyyyMMdd",
                                       CultureInfo.InvariantCulture);
                            client.Add(new Client { clientId = clientId, fileName = Path.GetFileName(file), order = i, fileDate = date });
                            break;
                        }
                        i++;
                    }

                }

                var clientOrder = client.OrderBy(o => o.order).ThenBy(t => t.fileDate).Select(s => new { s.clientId, s.fileName }).ToList();

                string json = JsonConvert.SerializeObject(clientOrder.ToList());

                return json;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

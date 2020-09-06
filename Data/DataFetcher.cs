using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System;

namespace Image_Gallery_Demo1
{
    class DataFetcher
    {
        async Task<string> GetDatafromService(string searchstring)
        {
            string readText = null;
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string picturePath = @"Data\sampleData.json";

            string absolutePath = Path.Combine(basePath, picturePath);
            try
            {
                var azure = @"https://imagefetcher20200529182038.azurewebsites.net";
                string url = azure + @"/api/fetch_images?query=" + searchstring + "&max_count=5";
                using (HttpClient c = new HttpClient())
                {
                    readText = await c.GetStringAsync(url);
                }
            }
            catch
            {
                readText = File.ReadAllText(absolutePath);
            }
            return readText;
        }

        public async Task<List<ImageItem>> GetImageData(string search)
        {
            string data = await GetDatafromService(search);
            return JsonConvert.DeserializeObject<List<ImageItem>>(data);
        }
    }
}
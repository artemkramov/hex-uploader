using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{
    class ECRDictionary
    {

        private static Dictionary<string, object> translations = new Dictionary<string, object>();

        public static void InitTranslations()
        {
            ReadFile();
        }

        private static async void ReadFile()
        {
            try
            {
                var filePath = @"..\..\Assets\dictionary.json";
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true))
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, (int)buffer.Length);
                    string jsonRaw = System.Text.Encoding.UTF8.GetString(buffer).Remove(0, 1);
                    translations = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonRaw);
                }
            }
            catch (Exception)
            {
            }
        }

        public static string GetTranslation(string key)
        {
            try
            {
                return translations[key].ToString();
            }
            catch (Exception)
            {
                return key;
            }
        }

        public static void AddTranslations(string key, string value)
        {
            if (!translations.ContainsKey(key))
            {
                translations.Add(key, value);
            }
            translations[key] = value;
        }

    }
}

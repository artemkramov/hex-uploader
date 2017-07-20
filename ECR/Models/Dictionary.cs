using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR.Models
{

    /// <summary>
    /// Dictionary for the application
    /// </summary>
    class ECRDictionary
    {

        /// <summary>
        /// List of all available translations
        /// </summary>
        private static Dictionary<string, object> translations = new Dictionary<string, object>();

        /// <summary>
        /// Initialize translations
        /// </summary>
        public static void InitTranslations()
        {
            ReadFile();
        }

        /// <summary>
        /// Read all translations from the local dictionary file
        /// </summary>
        private static async void ReadFile()
        {
            try
            {
                /* Read JSON file and parse it */
                var filePath = Application.StartupPath + @"\dictionary.json";
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true))
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, (int)buffer.Length);
                    string jsonRaw = System.Text.Encoding.UTF8.GetString(buffer).Remove(0, 1);
                    translations = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonRaw);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Get translation by the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add translation with defined key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
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

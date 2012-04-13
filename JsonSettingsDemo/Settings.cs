using Newtonsoft.Json;
using System.IO;

namespace JsonSettingsDemo
{
    public abstract class Settings
    {
        private string _filename;

        /// <summary>
        /// This function will load in our settings object, if the file does not exists,
        /// a file with the defaults will be created
        /// This way if you accidently delete the config file, you can recover a template very easy.
        /// </summary>
        /// <typeparam name="T">A class that derives from Settings and has a parameterless constructor
        /// </typeparam>
        /// <param name="filename"> The config file to be loaded </param>
        /// <returns></returns>
        public static T Load<T>(string filename) where T : Settings, new()
        {
            T theSetting;
            if (File.Exists(filename))
            {
                var reader = new StreamReader(filename);
                var configJson = reader.ReadToEnd();
                reader.Close();
                theSetting = JsonConvert.DeserializeObject<T>(configJson);
                theSetting._filename = filename;
            }
            else
            {
                theSetting = new T();
            }

            theSetting._filename = filename;
            theSetting.Save();

            return theSetting;
        }

        public void Save()
        {
            var writer = new StreamWriter(_filename);
            writer.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            writer.Close();
        }

        public void SaveAs(string filename)
        {
            _filename = filename;
            Save();
        }
    }
}
namespace JsonSettingsDemo
{
    class Program
    {
        private static DemoSettings _settings;
        static void Main(string[] args)
        {
            _settings = Settings.Load<DemoSettings>("settings.js");
            string apiUri = _settings.apiUri;
            int waitInterval = _settings.waitInterval;

            _settings.waitInterval = 5;
            _settings.Save();
        }
    }
}

﻿using System.Collections.Generic;

namespace JsonSettingsDemo
{
    public class DemoSettings : Settings
    {
        public DemoSettings()
        {
            // initialize to prevent null values
            exclude = new List<string>();
            someMap = new Dictionary<string, string>();
            apiUri = "";
        }

        protected override void defaults()
        {
            apiUri = "http://example.com";
            waitInterval = 1500;

            exclude.Add("value1");
            someMap.Add("example", "exampleValue");
            someMap.Add("example2", "otherValue");
        }

        
        /* Adding a new config value is as simple as adding a new public field or property
         * You don't need to add it to the config file,
         * The config file will be auto updated with the new value on the next run
         */
        public string apiUri;
        public int waitInterval;
        public List<string> exclude;
        public Dictionary<string, string> someMap;
    }
}
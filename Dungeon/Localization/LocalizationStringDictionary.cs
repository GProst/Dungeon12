﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Dungeon.Localization
{
    public abstract class LocalizationStringDictionary<T> : LocalizationStringDictionary
        where T : LocalizationStringDictionary<T>
    {

        public T ___Load(string lang)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(DoPath(lang)));
        }
    }

    public abstract class LocalizationStringDictionary
    {
        public abstract string ___RelativeLocalizationFilesPath { get; }

        public abstract string ___DefaultLanguageCode { get; }

        public T ___Load<T>(string lang)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(DoPath(lang)));
        }

        protected string DoPath(string lang)
        {
            var root = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var path = Path.Combine(root, ___RelativeLocalizationFilesPath, lang + ".json");

            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return path;
        }

        public object ___AutoLoad(string lang = default, LocalizationStringDictionary strings = default)
        {
            if (lang == default)
                return default;

            try
            {
                var path = DoPath(lang);
                if (!File.Exists(path) && strings != default)
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(strings, Formatting.Indented));
                    return strings;
                }

                return JsonConvert.DeserializeObject(File.ReadAllText(DoPath(lang)), this.GetType());
            }
            catch (FileNotFoundException)
            {
                return default;
            }
        }

        public void ___Save(string lang)
        {
            File.WriteAllText(DoPath(lang), JsonConvert.SerializeObject(this));
        }

        public List<LocalizedString> DynamicStrings { get; set; }
    }
}
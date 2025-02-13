﻿using Dungeon.Localization;

namespace Dungeon12.Localization
{
    public class GameStrings : LocalizationStringDictionary<GameStrings>
    {
        public string NewGame { get; set; } = "Новая игра";

        public string Save { get; set; } = "Сохранить";

        public string Load { get; set; } = "Загрузить";

        public string Settings { get; set; } = "Настройки";

        public string Credits { get; set; } = "Авторы";

        public string FastGame { get; set; } = "Быстрая игра";

        public string ExitGame { get; set; } = "Выйти";

        public override string ___RelativeLocalizationFilesPath => "locale";

        public override string ___DefaultLanguageCode => "ru";
    }
}
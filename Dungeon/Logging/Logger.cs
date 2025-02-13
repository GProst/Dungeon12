﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dungeon.Logging
{
    public class Logger
    {
        private readonly List<LogMessage> Logs = new List<LogMessage>();

        public void SaveIsNeeded(string path)
        {
            if (Logs.Count > 0)
            {
                Save(path);
            }
        }

        public void Log(string msg) => Logs.Add(msg);

        public void Save(string path) => File.WriteAllText(path, string.Join(Environment.NewLine, Logs.Select(x => $"[{x.When}] : {x.Message}").ToList()));

        private class LogMessage
        {
            public DateTime When { get; set; } = DateTime.Now;

            public string Message { get; set; }

            public static implicit operator LogMessage(string msg) => new LogMessage() { Message = msg };
        }
    }
}
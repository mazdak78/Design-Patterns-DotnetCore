using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.Singleton
{
    public interface ISingletonContainer
    {
        Dictionary<string,string> GetConfigs();
        string GetConfig(string key);
    }

    public class SingletonContainer : ISingletonContainer
    {
        private Dictionary<string, string> _configs = new Dictionary<string, string>();

        private SingletonContainer()
        {
            Console.WriteLine("Initializing singleton object");

            _configs = new Dictionary<string, string>();
            
            //can be read configs from a source
            for (int i = 1; i < 4; i++)
            {  
                _configs.Add("Config " + i, "Value " + i);
            }
        }
            

        public Dictionary<string,string> GetConfigs()
        {
            return _configs;
        }

        public string GetConfig(string key)
        {
            string value = null;
            _configs.TryGetValue(key, out value);
            return value;
        }

        private static Lazy<SingletonContainer> instance = new Lazy<SingletonContainer>(() => new SingletonContainer());

        public static SingletonContainer Instance => instance.Value;
    }
}

using MySqlConnector;
using System.IO;

namespace SAASystem.Singleton
{
    public sealed class DatabaseSingleton
    {
        private static DatabaseSingleton instance = null;
        private static readonly object padlock = new object();

        DatabaseSingleton()
        {
        }
        public static DatabaseSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseSingleton();
                    }
                    return instance;
                }
            }
        }
        public MySqlConnection MySqlConnection
        {
            get
            {
                string text = File.ReadAllText(@"C:\Users\Gayan\Desktop\key_saasystem.txt");
                return new MySqlConnection(text);
            }
        }
    }
}
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
        public string ConnectionString
        {
            get
            {
                return null;
            }
        }
    }
}

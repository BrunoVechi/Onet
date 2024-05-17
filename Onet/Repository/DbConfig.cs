using SQLite;

namespace Onet.Repository
{
    public class DbConfig
    {
        public const string DatabaseFilename = "JobSQLite.db3";

        public const SQLiteOpenFlags Flags =

            SQLiteOpenFlags.ReadWrite |

            SQLiteOpenFlags.Create |

            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}

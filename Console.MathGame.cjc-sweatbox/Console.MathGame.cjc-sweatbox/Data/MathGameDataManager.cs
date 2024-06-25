// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Data.MathGameDataManager
// -------------------------------------------------------------------------------------------------
// Data manager class for the application database.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Models;
using SQLite;

namespace Console.MathGame.cjc_sweatbox.Data
{
    public class MathGameDataManager
    {
        #region Variables

        private readonly string _filePath;

        #endregion
        #region Constructors

        public MathGameDataManager(string filePath)
        {
            _filePath = filePath;
            Initialise();
        }

        #endregion
        #region Methods: Public - Initialise

        public void Initialise()
        {
            // Creates a connection, and also creates the database file if it doesn't exist.
            using (var connection = new SQLiteConnection(_filePath,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite))
            {
                connection.CreateTable<Game>();
            }
        }
        #endregion
        #region Methods: Public - Create

        public void InsertGame(Game game)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Insert(game);
            }
        }

        #endregion
        #region Methods: Public - Return

        public IReadOnlyList<Game> GetGames()
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                return [.. connection.Table<Game>()];
            }
        }

        #endregion
        #region Methods: Public - Update

        public void UpdateGame(Game game)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Update(game);
            }
        }

        #endregion
        #region Methods: Public - Delete

        public void DeleteGame(int id)
        {
            using (var connection = new SQLiteConnection(_filePath))
            {
                connection.Delete<Game>(id);
            }
        }

        #endregion
    }
}

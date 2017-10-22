using System.Data;
using System.Data.SQLite;

using System;
using System.IO;

using SQLite;

using SQLiteCommand = System.Data.SQLite.SQLiteCommand;
using SQLiteConnection = System.Data.SQLite.SQLiteConnection;
using SQLiteException = System.Data.SQLite.SQLiteException;

namespace sqlite_winforms_example
{
    using System.Collections.Generic;

    using SQLiteConnection = SQLite.SQLiteConnection;

    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.MaxLength(8)]
        public string Symbol { get; set; }
    }

    public class Valuation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    }
    /// <summary>
    /// Useful resources found for this:
    ///   * https://stackoverflow.com/questions/26020/what-is-the-best-way-to-connect-and-use-a-sqlite-database-from-c-sharp
    ///   * https://www.thoughtco.com/use-sqlite-from-a-c-application-958255
    ///   * https://www.codeproject.com/Articles/22165/Using-SQLite-in-your-C-Application
    /// </summary>
    class SqLiteDatabase
    {
        private SQLite.SQLiteConnection sqlite;

        public SqLiteDatabase()
        {
            string assembly = System.Reflection.Assembly.GetEntryAssembly().Location;
            string database = Path.Combine(Path.GetDirectoryName(assembly), "connection.db");
            //this.sqlite = new SQLiteConnection($"Data Source={database}");

            this.sqlite = new SQLiteConnection(database);
            List<Stock> stocks = this.sqlite.Query<Stock>("select * from Stock");
            this.sqlite.CreateTable<Stock>();
            this.sqlite.Insert(new Stock(){Id=1, Symbol = "Hat"});
            this.sqlite.Insert(new Stock() { Id = 1, Symbol = "Mushroom" });
            //SQLiteConnection.CreateFile(database);
            //SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={database};Version=3;");
            //m_dbConnection.Open();

            //SQLite.SQLiteConnection conn = new SQLiteConnection(database);

            //string sql = "create table if not exists highscores (name varchar(20), score int)";

            //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            //sql = "insert into highscores (name, score) values ('Me', 9001)";

            //command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            //sql = "select name from highscores";
            //command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteReader()

            //m_dbConnection.Close();
        }

        public DataTable SelectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                //this.sqlite.Open();
                //var cmd = this.sqlite.CreateCommand();
                //cmd.CommandText = query;
                //ad = new SQLiteDataAdapter(cmd);
                //ad.Fill(dt);
            }
            catch (SQLiteException ex)
            {
                // Add your exception code here.
            }

            this.sqlite.Close();
            return dt;
        }
    }
}

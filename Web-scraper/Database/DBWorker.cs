using Microsoft.Data.Sqlite;

namespace webscraper
{
    internal class DBWorker
    {
        private string connectionString;

        public DBWorker(string connectionString)
        {
            this.connectionString = connectionString;
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

        }



        public List<parse_Product> GetIds()
        {

            List<parse_Product> products = new List<parse_Product>();
            //parse_Product temp = new parse_Product();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT id, name, salePriceU FROM Main";
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            parse_Product temp = new parse_Product();
                            temp.id = Convert.ToInt32(reader.GetValue(0));
                            temp.name = reader.GetValue(1).ToString();
                            temp.salePriceU = Convert.ToInt32(reader.GetValue(2));
                            products.Add(temp);
                            // Console.WriteLine(temp.name);
                        }
                    }


                    else { return products = null; }


                }
                return products;
            }

        }



    }
}

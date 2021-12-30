using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MarketManagment.Main
{
    class DBHelper
    {
        private static string _folder = Application.StartupPath + "Database";
        private static string _filePath = Application.StartupPath + "Database\\MarketManagement.db";
        private static string _cs = @"URI=file:" + Application.StartupPath + "Database\\MarketManagement.db";

        // connnection string getter
        public static string ConnectionString { get => _cs; }

        public static void InsertData(int barcode, string name, double buyPrice, double salePrice, bool isWeight)
        {
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                // if barcode is exist than warn the user
                string checkCmd = "select count(*) from Products where [barcode] = @Barcode";
                SQLiteCommand checkBarcodeExist = new SQLiteCommand(checkCmd, con);
                checkBarcodeExist.Parameters.AddWithValue("@Barcode", barcode);
                int isBarcodeExist = Convert.ToInt32(checkBarcodeExist.ExecuteScalar());

                if (isBarcodeExist == 0)
                {
                    cmd.CommandText = "insert into Products(barcode, name, buyPrice, salePrice, isWeight) VALUES(@Barcode, @Name, @BuyPrice, @SalePrice, @IsWeight)";

                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@BuyPrice", buyPrice);
                    cmd.Parameters.AddWithValue("@SalePrice", salePrice);
                    cmd.Parameters.AddWithValue("@IsWeight", isWeight);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("barcode is already exist!");
                    return;
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("\n\nCannot insert! " + e);
                return;
            }
        }

        public static void UpdateData(int barcode, string name, double buyPrice, double salePrice, bool isWeight)
        {
            string sql = "update Products set name = @Name, buyPrice = @BuyPrice, salePrice = @SalePrice, isWeight = @IsWeight where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@BuyPrice", buyPrice);
            cmd.Parameters.AddWithValue("@SalePrice", salePrice);
            cmd.Parameters.AddWithValue("@IsWeight", isWeight);

            cmd.ExecuteNonQuery();
        }

        public static void DeleteData(int barcode)
        {
            string sql = "delete from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            cmd.ExecuteNonQuery();
        }

        public static bool CheckDataValid(int barcode)
        {
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            // if barcode is exist than warn the user
            string checkCmd = "select count(*) from Products where [barcode] = @Barcode";
            SQLiteCommand checkBarcodeExist = new SQLiteCommand(checkCmd, con);
            checkBarcodeExist.Parameters.AddWithValue("@Barcode", barcode);
            int isBarcodeExist = Convert.ToInt32(checkBarcodeExist.ExecuteScalar());

            if (isBarcodeExist == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetProductName(int barcode)
        {
            string sql = "select name from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            string productName = (string)cmd.ExecuteScalar();

            return productName;
        }

        public static double GetProductPrice(int barcode)
        {
            string sql = "select salePrice from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            double productPrice = (double)cmd.ExecuteScalar();

            return productPrice;
        }

        public static bool ProductIsWeight(int barcode)
        {
            string sql = "select isWeight from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            string weightStr = cmd.ExecuteScalar().ToString();

            int weightInt = int.Parse(weightStr);
            bool isWeight = Convert.ToBoolean(weightInt);
            return isWeight;
        }

        public static void CreateDB()
        {
            // Create directory
            if (!Directory.Exists(_folder)) Directory.CreateDirectory(_folder);

            // create db
            if (!File.Exists(_filePath))
            {
                SQLiteConnection.CreateFile(_filePath);

                using (var sqlite = new SQLiteConnection(@"Data Source=" + _filePath))
                {
                    sqlite.Open();
                    string sql = "create table Products(barcode INTEGER not null, name text not null, buyPrice REAL, salePrice REAL not null, isWeight INTEGER, primary key(barcode))";
                    SQLiteCommand sqlCmd = new SQLiteCommand(sql, sqlite);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
}

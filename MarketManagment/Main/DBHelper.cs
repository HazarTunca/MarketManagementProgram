using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MarketManagement.Main
{
    class DBHelper
    {
        public static DirectoryInfo dir = Directory.GetParent(Application.UserAppDataPath);
        private static string _folder = Path.Combine(dir.FullName, "Veritabanı");
        private static string _filePath = Path.Combine(dir.FullName, "Veritabanı\\MarketSaleDB.db");
        private static string _cs = @"URI=file:" + Path.Combine(dir.FullName, "Veritabanı\\MarketSaleDB.db");

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
                    cmd.CommandText = "insert into Products(barcode, name, salePrice, buyPrice, profit, isWeight) VALUES(@Barcode, @Name, @SalePrice, @BuyPrice, @Profit, @IsWeight)";

                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    cmd.Parameters.AddWithValue("@Name", name);

                    // convert buyPrice
                    string buyPriceString = "--";
                    if (buyPrice != 0) buyPriceString = $"{buyPrice.ToString("#.00")} ₺";
                    cmd.Parameters.AddWithValue("@BuyPrice", buyPriceString);

                    cmd.Parameters.AddWithValue("@SalePrice", $"{salePrice.ToString("#.00")} ₺");

                    // calculate the profit
                    string profit = "--";
                    if (buyPrice != 0) profit = $"{(salePrice - buyPrice).ToString("#.00")} ₺  (%{((salePrice - buyPrice) * 100 / buyPrice).ToString("#.00")})";
                    cmd.Parameters.AddWithValue("@Profit", profit);

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
            
            con.Close();
        }

        public static void UpdateData(int barcode, string name, double buyPrice, double salePrice, bool isWeight)
        {
            string sql = "update Products set name = @Name, salePrice = @SalePrice, buyPrice = @BuyPrice, profit = @Profit, isWeight = @IsWeight where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            cmd.Parameters.AddWithValue("@Name", name);

            // convert buyPrice
            string buyPriceString = "--";
            if (buyPrice != 0) buyPriceString = $"{buyPrice.ToString("#.00")} ₺";
            cmd.Parameters.AddWithValue("@BuyPrice", buyPriceString);

            cmd.Parameters.AddWithValue("@SalePrice", $"{salePrice.ToString("#.00")} ₺");

            // calculate the profit
            string profit = "--";
            if(buyPrice != 0) profit = $"{(salePrice - buyPrice).ToString("#.00")} ₺  (%{((salePrice - buyPrice) * 100 / buyPrice).ToString("#.00")})";
            cmd.Parameters.AddWithValue("@Profit", profit);

            cmd.Parameters.AddWithValue("@IsWeight", isWeight);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteData(int barcode)
        {
            string sql = "delete from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            cmd.ExecuteNonQuery();

            con.Close();
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

            con.Close();
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
            con.Close();
            return productName;
        }

        public static double GetProductPrice(int barcode)
        {
            string sql = "select salePrice from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            string productPriceString = (string)cmd.ExecuteScalar();
            productPriceString = productPriceString.Trim('₺');

            double productPrice = 0;
            if(productPriceString != "--") productPrice = double.Parse(productPriceString);

            con.Close();
            return productPrice;
        }

        public static double GetProductBuyPrice(int barcode)
        {
            string sql = "select buyPrice from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            string productBuyPriceString = (string)cmd.ExecuteScalar();
            productBuyPriceString = productBuyPriceString.Trim('₺');

            double productBuyPrice = 0;
            if (productBuyPriceString != "--") productBuyPrice = double.Parse(productBuyPriceString);

            con.Close();
            return productBuyPrice;
        }

        public static bool GetProductIsWeight(int barcode)
        {
            string sql = "select isWeight from Products where barcode = @Barcode";
            SQLiteConnection con = new SQLiteConnection(_cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            string weightStr = cmd.ExecuteScalar().ToString();

            int weightInt = int.Parse(weightStr);
            bool isWeight = Convert.ToBoolean(weightInt);

            con.Close();
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
                    string sql = "create table Products(barcode INTEGER not null, name text not null, salePrice text not null, buyPrice text, profit text, isWeight INTEGER, primary key(barcode))";
                    SQLiteCommand sqlCmd = new SQLiteCommand(sql, sqlite);
                    sqlCmd.ExecuteNonQuery();
                    sqlite.Close();
                }
            }
        }
    }
}

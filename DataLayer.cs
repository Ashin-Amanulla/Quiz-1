using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Collections;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Threading;
using System.Windows.Forms;

namespace Quiz
{
    static class DataLayer
    {
        static SQLiteConnection  mDBcon = new SQLiteConnection("Data Source = Library\\DB\\memory.db");
        static SQLiteDataAdapter datadapter;
        static SQLiteCommand cmd;
        static DataSet dataset = new DataSet();
        //static IDbTransaction trans;       
        static Random randmnum = new Random();
       
        public static void CreateFile()
        {        
          
            if (!File.Exists("Library\\DB\\memory.db"))
            {
                cmd = new SQLiteCommand(mDBcon);
                mDBcon.Open();
                cmd.CommandText = "CREATE TABLE if not exists Quiz(Id INTEGER PRIMARY KEY  AUTOINCREMENT ,Question varchar(1000),type varchar(100),category varchar(100),Image binary,choice1 varchar(100),choice2 varchar(100),choice3 varchar(100),choice4 varchar(100),correctchoice varchar(100))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE if not exists TypeMaster(Id INTEGER PRIMARY KEY  AUTOINCREMENT ,TypeName varchar(1000))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE if not exists CategoryMaster(Id INTEGER PRIMARY KEY  AUTOINCREMENT ,CategoryName varchar(1000))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE if not exists User(Id INTEGER PRIMARY KEY  AUTOINCREMENT ,UserName varchar(1000),Password varchar(1000))";
                cmd.ExecuteNonQuery();
                mDBcon.Close();
             
            }
        }
        public static DataSet DisplayData(bool admin = false)
        {
            CreateFile();
            mDBcon.Open();
            DataSet dataset = new DataSet();
            cmd = new  SQLiteCommand(mDBcon);
            cmd.CommandText = admin?"select * from Quiz": "select * from Quiz  ORDER BY RANDOM()";//";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "Quiz");
            mDBcon.Close();
            return dataset;  
 
        }
        public static DataSet GetTypeMaster()
        {
            CreateFile();
            mDBcon.Open();
            DataSet dataset = new DataSet();
            cmd = new SQLiteCommand(mDBcon);
            cmd.CommandText = "select * from TypeMaster";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "TypeMaster");
            mDBcon.Close();
            return dataset;

        }
        public static DataSet GetCategoryMaster()
        {
            CreateFile();
            mDBcon.Open();
            DataSet dataset = new DataSet();
            cmd = new SQLiteCommand(mDBcon);
            cmd.CommandText = "select * from CategoryMaster";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "CategoryMaster");
            mDBcon.Close();
            return dataset;

        }
        public static byte[] LoadImage(int Id)
        {
            byte[] a = null;
            string query = "SELECT Image FROM Quiz WHERE ID="+ Id +";";
            mDBcon.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, mDBcon);
           
            try
            {
                IDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        a = (System.Byte[])rdr[0];
                    }
                }
                catch  {
                    //MessageBox.Show(exc.Message); 
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            mDBcon.Close();
            return a;
        }
        public static void clearData(string tablename)
        {
            mDBcon.Open();
            var trans = mDBcon.BeginTransaction();
            cmd.CommandText = "delete from "+tablename;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM SQLITE_SEQUENCE WHERE name='" + tablename +"'";
            cmd.ExecuteNonQuery();
            trans.Commit();
            mDBcon.Close();

        }
        public static void InsertData(DataGridViewRow row , byte[] image)
        {
            try
            {

                mDBcon.Open();
                var trans = mDBcon.BeginTransaction();
                SQLiteCommand cmd = new SQLiteCommand(mDBcon);
                SQLiteParameter A = new SQLiteParameter("@Question", System.Data.DbType.String);
                A.Value = row.Cells[1].Value;
                cmd.Parameters.Add(A);
                SQLiteParameter B = new SQLiteParameter("@type", System.Data.DbType.String);
                B.Value = row.Cells[3].Value;
                cmd.Parameters.Add(B);
                SQLiteParameter C = new SQLiteParameter("@category", System.Data.DbType.String);
                C.Value = row.Cells[2].Value;
                cmd.Parameters.Add(C);
                SQLiteParameter D = new SQLiteParameter("@Image", System.Data.DbType.Binary);
                D.Value = image;
                cmd.Parameters.Add(D);
                SQLiteParameter E = new SQLiteParameter("@choice1", System.Data.DbType.String);
                E.Value = row.Cells[5].Value;
                cmd.Parameters.Add(E);
                SQLiteParameter F = new SQLiteParameter("@choice2", System.Data.DbType.String);
                F.Value = row.Cells[6].Value;
                cmd.Parameters.Add(F);
                SQLiteParameter G = new SQLiteParameter("@choice3", System.Data.DbType.String);
                G.Value = row.Cells[7].Value;
                cmd.Parameters.Add(G);
                SQLiteParameter H = new SQLiteParameter("@choice4", System.Data.DbType.String);
                H.Value = row.Cells[8].Value;
                cmd.Parameters.Add(H);

                SQLiteParameter I = new SQLiteParameter("@correctchoice", System.Data.DbType.String);
                I.Value = row.Cells[9].Value;
                cmd.Parameters.Add(I);

                cmd.CommandText = "INSERT INTO Quiz(Question,type,category,Image,choice1,choice2,choice3,choice4,correctchoice) VALUES(@Question ,@type,@category,@Image,@choice1,@choice2,@choice3,@choice4,@correctchoice)";
                cmd.ExecuteNonQuery();
                trans.Commit();

                mDBcon.Close();
            }
            catch(Exception ex)
            {

            }
           

        }
        public static bool Login(string username ,string password)
        {
            mDBcon.Open();
            DataSet dataset = new DataSet();
            cmd = new SQLiteCommand(mDBcon);
            cmd.CommandText = "select * from User where username = '"+username+"' and password = '"+password+"'";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "user");
            mDBcon.Close();
            return dataset.Tables[0].Rows.Count > 0 ?true:false;
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static void  InsertTypeMasterData(DataGridViewRow row)
        {
           
            mDBcon.Open();
            var trans = mDBcon.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(mDBcon);
           
            cmd.CommandText = "INSERT INTO TypeMaster(TypeName) VALUES('" + row.Cells[1].Value + "')";
            cmd.ExecuteNonQuery();
            trans.Commit();

            mDBcon.Close();
        }
        public static void InsertCategoryMasterData(DataGridViewRow row)
        {
            
            mDBcon.Open();
            var trans = mDBcon.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(mDBcon);

            cmd.CommandText = "INSERT INTO CategoryMaster(CategoryName) VALUES('" + row.Cells[1].Value + "')";
            cmd.ExecuteNonQuery();
            trans.Commit();

            mDBcon.Close();
        }


    }
}

﻿using System;
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
       
        static SQLiteConnection  mDBcon = new SQLiteConnection("Data Source = Library\\DB\\memory.db"); //connection string
        static SQLiteDataAdapter datadapter;
        static SQLiteCommand cmd;
        static DataSet dataset = new DataSet();    
        static Random randmnum = new Random();

        /// <summary>
        /// This Method Creates the Necessary Tables in the Database if it doesnt Already Exist.
        /// that is , if there is no (sql) database present with this program due to lost,misplacement,unavailabilty etc, 
        /// this function direct the program to create a new sql database  table with following input parameters - 
        /// 1)Quiz with cells id, question,type, category, image ,choice1,choice 2, choice 3,choice 4, correct answer 
        /// 2)TypeMaster with type
        /// 3)CategoryMaster with type
        /// 4)User with Username and password
        /// 
        /// refer the tables design in admin dashboard options
        /// </summary>
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
        /// <summary>
        /// This Method Retrives Datafrom the Quiz Table. 
        /// That is, after entering the data in sql, we need to fetch them to display and compare(answers) as per our need.
        /// So this function when called fetched data from our sql dB.
        /// </summary>
        /// <param>
        /// <c>admin</c>Determines if the call is from admin listing or Quiz to randomize result.
        /// That is, in our program we fetch data mainly for two purpose. One, after successful admin login to enter/edit question, 
        /// we want to see the already stored question data. Here questions are displayed in an ordered manner.
        /// Two, after clicking play button , questions are displayed randomly (not in the order in the sql table).
        /// Here inorder to achieve the randomness, we fetch the questions from the sql by ORDER By RANDOM() function . 
        /// </param>
        /// <returns>
        /// Dataset containing data from the Quiz table.
        /// </returns>
        public static DataSet DisplayData(bool admin = false)
        {
            CreateFile();
            mDBcon.Open();
            DataSet dataset = new DataSet();
            cmd = new  SQLiteCommand(mDBcon);
            cmd.CommandText = admin?"select * from Quiz": "select * from Quiz  ORDER BY RANDOM()";//this terniary operator
            //controls how to provide data - if it is admin(then in order) or player(then random)";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "Quiz");
            mDBcon.Close();
            return dataset;  
 
        }
        /// <summary>
        /// This method retrives data from Typemaster table .
        /// This function fetches "types" inserted by admin (currently true or false, mcq, fill in the blank) and shows in 
        /// the drop down list in the typebutton in question platform(while add/edit new question)
        /// </summary>
        /// <returns>
        /// Dataset containg typemaster data
        /// </returns>
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
        /// <summary>
        /// This method retrives data from CategoryMaster table .
        ///      /// This function fetches "category" inserted by admin (currently mammals,seabirds,amphibians etc) and shows in 
        /// the drop down list in the category button in question platform(while add/edit new question)
        /// </summary>
        /// <returns>
        /// Dataset containg CategoryMaster data
        /// </returns>
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
        /// <summary>
        /// This method retrives stored image from the database.
            /// This function fetches images already inserted by admin  and shows in 
        /// the image column in question platform(while add/edit new question)
        /// </summary>
        /// <param>
        /// <c>Id</c>is the question id of the Image.
        /// </param>
        /// <returns>
        ///byte array of the image
        /// </returns>
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
        /// <summary>
        /// This method clears datafrom given table.
        /// DELETE Function
        /// </summary>
        /// <param>
        /// <c>tablename</c> is the name of the table.
        /// </param>
        public static void clearData(string tablename)
        {
            mDBcon.Open();
            var trans = mDBcon.BeginTransaction();
            cmd.CommandText = "delete from "+tablename;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM SQLITE_SEQUENCE WHERE name='" + tablename +"'";//delete/remove
            cmd.ExecuteNonQuery();
            trans.Commit();
            mDBcon.Close();

        }
        /// <summary>
        /// This method inserts data into the Quiz table .
        /// ADD Function. Add inserted data to the sql dB
        /// </summary>
        /// <param>
        /// <c>row</c> is the row to be inserted.
        /// Add to next row
        /// </param>
        /// <param>
        /// <c>image</c> is the Image byte to be inserted.
        /// NEW IMAGE ADD
        /// </param>
        public static void InsertData(DataGridViewRow row , byte[] image)
        {
            try
            {

                mDBcon.Open();
                var trans = mDBcon.BeginTransaction();
                SQLiteCommand cmd = new SQLiteCommand(mDBcon);
                SQLiteParameter A = new SQLiteParameter("@Question", System.Data.DbType.String); //question parameter
                A.Value = row.Cells[1].Value;
                cmd.Parameters.Add(A);
                SQLiteParameter B = new SQLiteParameter("@type", System.Data.DbType.String); //type parameter(from drop down)
                B.Value = row.Cells[3].Value;
                cmd.Parameters.Add(B);
                SQLiteParameter C = new SQLiteParameter("@category", System.Data.DbType.String); //category parameter(from drop down)
                C.Value = row.Cells[2].Value;
                cmd.Parameters.Add(C);
                SQLiteParameter D = new SQLiteParameter("@Image", System.Data.DbType.Binary); //image parameter as binary(not string!!)
                D.Value = image;
                cmd.Parameters.Add(D);
                SQLiteParameter E = new SQLiteParameter("@choice1", System.Data.DbType.String);// choices parameter
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

                SQLiteParameter I = new SQLiteParameter("@correctchoice", System.Data.DbType.String);//adding correct answer
                I.Value = row.Cells[9].Value;
                cmd.Parameters.Add(I);

                cmd.CommandText = "INSERT INTO Quiz(Question,type,category,Image,choice1,choice2,choice3,choice4,correctchoice) VALUES(@Question ,@type,@category,@Image,@choice1,@choice2,@choice3,@choice4,@correctchoice)";// storing
                //every parameter as single entity / single row in sqldB
                cmd.ExecuteNonQuery();
                trans.Commit();

                mDBcon.Close();
            }
            catch(Exception ex)
            {

            }
           

        }
        /// <summary>
        /// This method validates the user login .
        /// Admin authorisation:
        /// This function checks if the login credentials are right or wrong 
        /// </summary>
        /// <param>
        /// <c>username</c> is the username.
        /// </param>
        /// /// <param>
        /// <c>password</c> is the password.
        /// </param>
        /// <returns>
        /// True if valid False if Invalid.
        /// </returns>
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
        /// <summary>
        /// This method converts the given string to MD5 Hash.
        ///This functions duty is to encrypt / hash any string inputed.
        ///We use this here to encrypt out password
        /// </summary>
        /// <param>
        /// <c>input</c>is the sting to be converted.
        /// </param>
        /// <returns>
        /// MD5 of the input string.
        /// </returns>
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
        /// <summary>
        /// This method inserts data into typeMaster table.
        ///    This function add new type into the db. 

        /// </summary>
        /// <param>
        /// <c>row</c>is the row to be inserted.
        /// </param>
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
        /// <summary>
        /// This method inserts data into categoryMaster table.
               ///    This function add new category into the db.  So if you qnt o make q question on reptiles, first create a
               ///    new category called reptile through this function and then go to question creation platform , select it from dropdown list

        /// </summary>
        /// <param>
        /// <c>row</c>is the row to be inserted.
        /// </param>
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

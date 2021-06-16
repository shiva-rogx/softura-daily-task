﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCWithADOProject.Models
{
    public class CRUDModel
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public CRUDModel()
        {
            con = new SqlConnection("data source=LAPTOP-8J9PFGLH;Integrated Security=true;database=DbBooks;");
            cmd = new SqlCommand();
        }

        public DataTable DisplayBook()
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select b.BookId,b.Title,a.AuthorName,b.Price from tbl_Books b join tbl_author a on b.AuthorId = a.AuthorId";
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DisplayBook(int BookId)
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from tbl_Books where BookId=@BookId";
            cmd.Parameters.AddWithValue("@BookId", BookId);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewBookBySP(string Title, int AuthorId, double Price)
        {
            cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Title", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.AddWithValue("AuthorId", SqlDbType.Int).Value = AuthorId;
            cmd.Parameters.AddWithValue("Price", SqlDbType.Money).Value = Price;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int NewBook(string Title, string AuthorName, double Price)
        {
            cmd = new SqlCommand("Insert into tbl_books values(@Title,(select AuthorId from tbl_author where AuthorName=@AuthorName),@Price)", con);
            cmd.Parameters.AddWithValue("Title", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            cmd.Parameters.AddWithValue("Price", SqlDbType.Money).Value = Price;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int DeleteBook(int BookId)
        {
            cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BookId", SqlDbType.Int).Value = BookId;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int UpdateBook(int BookId, string title, int AuthorId, double Price)
        {
            cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BookId", SqlDbType.Int).Value = BookId;
            cmd.Parameters.AddWithValue("Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("AuthorId", SqlDbType.Int).Value = AuthorId;
            cmd.Parameters.AddWithValue("Price", SqlDbType.Money).Value = Price;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable DisplayAuthor()
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from tbl_author";
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewAuthor(string Name)
        {
            cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", Name);
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
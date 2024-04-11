﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Results : System.Web.UI.Page
{
    string constring = "server=127.0.0.1; user=root; database=f5edu; password=";
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection Sqlcon = new SqlConnection(constring))
        {
            string query = "select * from result";
            Sqlcon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(query, Sqlcon);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            try
{
    Sqlcon.Open();
    // Các thao tác khác...
}
catch (Exception ex)
{
    Console.WriteLine("Lỗi kết nối: " + ex.Message);
}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient; // Changed from System.Data.SqlClient to MySql.Data.MySqlClient

public partial class _Class : System.Web.UI.Page
{
    string constring = "server=127.0.0.1; user=root; database=f5edu; password=";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        using (MySqlConnection Sqlcon = new MySqlConnection(constring))
        {
            try
            {
                Sqlcon.Open();
                string query = "SELECT * FROM classroom";
                MySqlDataAdapter sqlData = new MySqlDataAdapter(query, Sqlcon);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây
                Response.Write("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}

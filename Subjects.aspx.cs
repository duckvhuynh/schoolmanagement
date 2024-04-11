using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class Subjects : System.Web.UI.Page
{
     string constring = "server=127.0.0.1; user=root; database=f5edu; password=";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Kiểm tra xem trang này được tải lần đầu tiên hay là do postback
        if (!IsPostBack)
        {
            LoadSubjects();
        }
    }

    private void LoadSubjects()
    {
        // Tạo một đối tượng DataTable để chứa dữ liệu
        DataTable dataTable = new DataTable();

        // Sử dụng using để đảm bảo kết nối được đóng sau khi sử dụng xong
        using (MySqlConnection con = new MySqlConnection(constring))
        {
            // Câu truy vấn SQL để lấy tất cả dữ liệu từ bảng 'subjects'
            string query = "SELECT * FROM subjects";
            MySqlCommand cmd = new MySqlCommand(query, con);

            // Mở kết nối đến cơ sở dữ liệu
            con.Open();

            // Tạo một MySqlDataAdapter để thực thi câu truy vấn và điền dữ liệu vào DataTable
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);

            // Đóng kết nối
            con.Close();
        }

        // Gán nguồn dữ liệu cho GridView và refresh dữ liệu hiển thị
        GridView1.DataSource = dataTable;
        GridView1.DataBind();
    }
}

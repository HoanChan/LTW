using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class GiaoVien_Details : System.Web.UI.Page
{
    public string TenLop { get; set; }
    public string GiaoVien { get; set; }
    public string MoTa { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["NopBaiTapVeNhaConnectionString"].ConnectionString);
        cnn.Open();
        SqlCommand cmd = cnn.CreateCommand();
        cmd.CommandText = "select * from lophoc where malop = '" + ID + "'";
        var data = cmd.ExecuteReader();
        data.Read();
        TenLop = data["TenLop"].ToString();
        GiaoVien = data["GiaoVien"].ToString();
        MoTa = data["MoTa"].ToString();
        cnn.Close();
    }
}
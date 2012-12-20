using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClassDetails : System.Web.UI.Page
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
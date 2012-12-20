using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditExcercises : System.Web.UI.Page
{
    public string TenLop { get; set; }
    public string MaLop { get; set; }
    public string MaBT { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string ID = Request.QueryString["ID"];
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["NopBaiTapVeNhaConnectionString"].ConnectionString);
        cnn.Open();
        SqlCommand cmd = cnn.CreateCommand();
        cmd.CommandText = "select * from lophoc where malop = '" + ID + "'";
        var data = cmd.ExecuteReader();
        data.Read();
        TenLop = data["TenLop"].ToString();
        MaLop = data["MaLop"].ToString();
        cnn.Close();*/

        int ID = int.Parse(Request.QueryString["ID"]);
        
        MyContextDataContext db = new MyContextDataContext();
        var bt = db.BaiTaps.Where(m => m.Ma == ID).FirstOrDefault();
        MaBT = bt.Ma.ToString();
        txtTenBT.Text = bt.Ten.ToString();
        txtMoTa.Text = bt.MoTa.ToString();
        txtHanNop.Text = bt.HanNop.ToString();

    }

    protected void btnUpdate_Click(object senger,EventArgs e)
    {
    }
}
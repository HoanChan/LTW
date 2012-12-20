using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GiaoVien_CreateExercises : System.Web.UI.Page
{
    MyContextDataContext db = new MyContextDataContext();
    public string TenLop { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        var Data = db.LopHocs.FirstOrDefault(m => m.MaLop == ID);
        TenLop = Data.TenLop;
    }
}
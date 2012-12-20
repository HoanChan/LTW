using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
        int ID = int.Parse(Request.QueryString["ID"]);
        MyContextDataContext db = new MyContextDataContext();
        var bt = db.BaiTaps.Where(m => m.Ma == ID).FirstOrDefault();
        MaBT = bt.Ma.ToString();
        txtTenBT.Text = bt.Ten.ToString();
        txtMoTa.Text = bt.MoTa.ToString();
        txtHanNop.Text = bt.HanNop.ToString();

    }

    protected void btnUpdate_Click(object senger, EventArgs e)
    {
        int ID = int.Parse(Request.QueryString["ID"]);
        MyContextDataContext db = new MyContextDataContext();
        if (txtHanNop.Text != "" && Regex.IsMatch(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})$"))
        {
            lblKQ.Text = "Đề nghị nhập ngày cho đúng";
            return;
        }
        BaiTap bt = db.BaiTaps.Where(m => m.Ma == ID).FirstOrDefault();
        bt.Ten = txtTenBT.Text;
        bt.MoTa = txtMoTa.Text;
        var Match = Regex.Match(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})$");
        bt.HanNop = new DateTime(int.Parse(Match.Groups["Day"].Value), int.Parse(Match.Groups["Month"].Value), int.Parse(Match.Groups["Year"].Value));
        db.SubmitChanges();
    }
}
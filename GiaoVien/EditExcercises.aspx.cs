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
        txtHanNop.Text = bt.HanNop.ToString("dd/MM/yyy HH:mm:ss");
        TenLop = bt.LopHoc.TenLop;
        MaLop = bt.MaLop;
        MaBT = bt.Ma + "";

    }

    protected void btnUpdate_Click(object senger, EventArgs e)
    {
        int ID = int.Parse(Request.QueryString["ID"]);
        MyContextDataContext db = new MyContextDataContext();
        if (txtHanNop.Text != "" && !Regex.IsMatch(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})\s(?:(?<Hour>[0-1]\d|[2][0-4]):(?<Min>[0-5]\d){1,2}:(?<Sec>[0-5]\d){1,2})$"))
        {
            lblKQ.Text = "Đề nghị nhập ngày cho đúng với định dạng [dd/mm/yyyy hh:mm:ss]";
            return;
        }
        var bt = db.BaiTaps.Single(m => m.Ma == ID);
        if (bt == null)
        {
            lblKQ.Text = "ERR";
            return;
        } 
        if (fUpLoad.FileName.Length > 0)
        {
            string fileName = MaLop + "_" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + "_"
                                    + DateTime.Now.Hour.ToString("00") + "h" + DateTime.Now.Minute.ToString("00") + "m" + DateTime.Now.Second.ToString("00") + "s.zip";
            string FilePath = Server.MapPath(@"~\Upload\GiaoVien");
            string FullName = FilePath + @"\" + fileName;
            fUpLoad.SaveAs(FullName);
            bt.AttachFile = @"\Upload\GiaoVien\" + fileName; 
        }
        bt.Ten = txtTenBT.Text;
        bt.MoTa = txtMoTa.Text;
        var Match = Regex.Match(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})\s(?:(?<Hour>[0-1]\d|[2][0-4]):(?<Min>[0-5]\d){1,2}:(?<Sec>[0-5]\d){1,2})$");
        bt.HanNop = new DateTime(int.Parse(Match.Groups["Year"].Value), int.Parse(Match.Groups["Month"].Value), int.Parse(Match.Groups["Day"].Value), int.Parse(Match.Groups["Hour"].Value), int.Parse(Match.Groups["Min"].Value), int.Parse(Match.Groups["Sec"].Value));
        db.SubmitChanges();
        Response.Redirect("/GiaoVien/Details.aspx?ID=" + MaLop);
    }
}
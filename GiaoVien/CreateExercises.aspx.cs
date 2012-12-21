using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GiaoVien_CreateExercises : System.Web.UI.Page
{
    MyContextDataContext db = new MyContextDataContext();
    public string TenLop { get; set; }
    public string MaLop { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        var Data = db.LopHocs.FirstOrDefault(m => m.MaLop == ID);
        TenLop = Data.TenLop;
        MaLop = Data.MaLop;
    }

    protected void btnCreate_Click(object sender, EventArgs e)
{
        if (txtHanNop.Text != "" && !Regex.IsMatch(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})\s(?:(?<Hour>[0-1]\d|[2][0-4]):(?<Min>[0-5]\d){1,2}:(?<Sec>[0-5]\d){1,2})$"))
        {
            lblKQ.Text = "Đề nghị nhập ngày cho đúng với định dạng [dd/mm/yyyy hh:mm:ss]";
            return;
        }
        string AttachFile ="";
        if (fUpLoad.FileName.Length > 0)
        {
            string fileName = MaLop + "_" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + "_"
                                    + DateTime.Now.Hour.ToString("00") + "h" + DateTime.Now.Minute.ToString("00") + "m" + DateTime.Now.Second.ToString("00") + "s.zip";
            string FilePath = Server.MapPath(@"~\Upload\GiaoVien");
            string FullName = FilePath + @"\" + fileName;
            fUpLoad.SaveAs(FullName);
            AttachFile = @"\Upload\GiaoVien\" + fileName;
        }
            MyContextDataContext db = new MyContextDataContext();
            BaiTap bt = new BaiTap() { AttachFile = AttachFile, MaLop = MaLop, Ten = txtTenBai.Text, MoTa = txtMota.Text };
            var Match = Regex.Match(txtHanNop.Text, @"^(?<Day>[0-2]\d|[3][0-1])\/(?<Month>[0]\d|[1][0-2])\/(?<Year>(?:[2][01]|[1][6-9])\d{2})\s(?:(?<Hour>[0-1]\d|[2][0-4]):(?<Min>[0-5]\d){1,2}:(?<Sec>[0-5]\d){1,2})$");
            bt.HanNop = new DateTime(int.Parse(Match.Groups["Year"].Value), int.Parse(Match.Groups["Month"].Value), int.Parse(Match.Groups["Day"].Value), int.Parse(Match.Groups["Hour"].Value), int.Parse(Match.Groups["Min"].Value), int.Parse(Match.Groups["Sec"].Value));
            db.BaiTaps.InsertOnSubmit(bt);
            db.SubmitChanges();
            Response.Redirect("/GiaoVien/Details.aspx?ID=" + MaLop);
    }
}
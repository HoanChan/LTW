using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GiaoVien_DetailsExe : System.Web.UI.Page
{
    public string TenBai { get; set; }
    public string TenLop { get; set; }
    public string MaLop { get; set; }
    public string SV { get; set; }
    public string Ten { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        int EID = int.Parse(Request.QueryString["CID"]);
        string UID = Request.QueryString["UID"];
        MyContextDataContext db= new MyContextDataContext();
        var bainop = db.BaiNops.Where(m => m.Username == UID && m.MaBaiTap == EID).FirstOrDefault();
        var bt = db.BaiTaps.Where(m => m.Ma == EID).FirstOrDefault();
        TenBai = bt.Ten;
        var lop = db.LopHocs.Where(m => m.MaLop == bt.MaLop).FirstOrDefault();
        TenLop = lop.TenLop;
        SV = ID;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileList : System.Web.UI.Page
{
    public string TenBai { get; set; }
    public string TenLop { get; set; }
    public string MaLop { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        var data = from m in (new MyContextDataContext()).BaiTaps select m;
        if (data.Count() > 0)
        {
            var Result = data.FirstOrDefault();
            TenBai = Result.Ten;
            
            MyContextDataContext db = new MyContextDataContext();
            var lop = db.LopHocs.Where(m => m.MaLop == Result.MaLop).FirstOrDefault();
            TenLop = lop.TenLop;
            MaLop = lop.MaLop;
        }
    }
}
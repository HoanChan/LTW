using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    public string Link { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Link"] == string.Empty) return;
        Link = (@"\" + Request.QueryString["Link"].Replace("/",@"\")).Replace(@"\\",@"\");
        var path = Server.MapPath(Link);
        if (!File.Exists(path)) return;
        MyContextDataContext db = new MyContextDataContext();
        var FileName = Path.GetFileName(Link);
        if (User.IsInRole("GiaoVien"))
        {
            var ClassList = db.BaiTaps.Where(m => m.LopHoc.GiaoVien == User.Identity.Name).Select(m => m.LopHoc.MaLop);
            var ClassName = FileName.Substring(0, FileName.IndexOf("_"));
            if (ClassList.Contains(ClassName))
            {
                Response.Redirect(Link);
                return;
            }
        }
        if (User.IsInRole("SinhVien"))
        {
            if (FileName.Contains(User.Identity.Name))
            {
                Response.Redirect(Link);
            }
        }
        Response.Redirect("/Error.aspx");
    }
}
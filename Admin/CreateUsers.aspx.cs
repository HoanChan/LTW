using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        MyContextDataContext db = new MyContextDataContext();
        string UserName = txtUser.Text;
        var user = db.NguoiDungs.Where(p => p.Username == UserName).FirstOrDefault();
        if (user == null)
        {
            if (txtEmail.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtPass1.Text == "")
            {
                lblKQ.Text = "Chưa nhập đầy đủ thông tin";
                return;
            }
            if (txtPass.Text != txtPass1.Text)
            {
                lblKQ.Text = "Mật khẩu chưa đúng";
                return;
            }
            NguoiDung nd = new NguoiDung();
            nd.Username = txtUser.Text;
            nd.Password = txtPass.Text;
            nd.Ten = txtHoTen.Text;
            nd.HoLot = txtHoTen.Text;
            nd.Email = txtEmail.Text;
            //nd.NgaySinh= txtNgaySinh.
            nd.GioiTinh = (RaNam.Checked == true) ? true : false;
            db.NguoiDungs.InsertOnSubmit(nd);
            db.SubmitChanges();
            var a = db.Quyens.Where(p => p.TenQuyen == ddlQuyen.Text).FirstOrDefault();
            Quyen_NguoiDung q = new Quyen_NguoiDung();
            q.Username = txtUser.Text;
            q.MaQuyen = a.MaQuyen;
            db.Quyen_NguoiDungs.InsertOnSubmit(q);
            db.SubmitChanges();
        }
        else
        {
            lblKQ.Text = "bị trùng user";
            return;
        }
    }
    
}
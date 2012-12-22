using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        if (txtEmail.Text != "" && !Regex.IsMatch(txtEmail.Text, "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$"))
        {
            lblKQ.Text = "Đề nghị nhập email cho đúng";
            return;
        }

        if (txtNgaySinh.Text!="" && !Regex.IsMatch(txtNgaySinh.Text, "^(?<Day>\\d{1,2})/(?<Month>\\d{1,2})/(?<Year>(?:\\d{4}|\\d{2}))$"))
        {
            lblKQ.Text = "Đề nghị nhập ngày sinh cho đúng";
            return;
        }
        MyContextDataContext db = new MyContextDataContext();
        string UserName = txtUser.Text;
        var user = db.NguoiDungs.Where(p => p.Username == UserName).FirstOrDefault();
        if (user == null)
        {
            if (txtUser.Text == "" || txtPass.Text == "" || txtPass1.Text == "" || txtHo.Text == "" || txtTen.Text == "") 
            {
                lblKQ.Text = "Chưa nhập đầy đủ thông tin";
                return;
            }
            if (txtPass.Text != txtPass1.Text)
            {
                lblKQ.Text = "Mật khẩu chưa khớp";
                return;
            }
            NguoiDung nd = new NguoiDung();
            nd.Username = txtUser.Text;
            nd.Password = txtPass.Text;
            nd.Ten = txtTen.Text;
            nd.HoLot = txtHo.Text;
            nd.Email = txtEmail.Text;
            var Match = Regex.Match(txtNgaySinh.Text, "^(?<Day>\\d{1,2})/(?<Month>\\d{1,2})/(?<Year>(?:\\d{4}|\\d{2}))$");
            nd.NgaySinh = new DateTime(int.Parse(Match.Groups["Day"].Value), int.Parse(Match.Groups["Month"].Value), int.Parse(Match.Groups["Year"].Value));
            nd.GioiTinh = (RaNam.Checked == true) ? true : false;
            db.NguoiDungs.InsertOnSubmit(nd);
            db.SubmitChanges();
            var a = db.Quyens.FirstOrDefault(p => p.TenQuyen == ddlQuyen.Text);
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
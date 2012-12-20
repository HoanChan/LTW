using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            divLogin.Visible = false;
            btnThoat.Visible = true;
            lblThongBao.Text = "Bạn đã đăng nhập với username là " + User.Identity.Name;
        }
        else
        {
            divLogin.Visible = true;
            btnThoat.Visible = false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!this.IsValid)
            return;
        if (Membership.ValidateUser(txtUsername.Text, txtPassword.Text) == false)
        {
            lblThongBao.Text = "Username hoặc password không đúng";
            return;
        }
        //FormsAuthentication.SetAuthCookie(username, chkRemember.Checked);
        FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, chkRemember.Checked);
        lblThongBao.Text = "Bạn đã đăng nhập thành công";
        btnThoat.Visible = true;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        btnThoat.Visible = false;
        divLogin.Visible = true;
        lblThongBao.Text = "";
    }
}
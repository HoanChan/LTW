﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClassDetails : System.Web.UI.Page
{
    public string TenLop { get; set; }
    public string GiaoVien { get; set; }
    public string MoTa { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        var data = from m in (new MyContextDataContext()).LopHocs select m;
        if (data.Count() > 0)
        {
            var Result = data.FirstOrDefault();
            TenLop = Result.TenLop;
            GiaoVien = Result.GiaoVien;
            MoTa = Result.MoTa;
        }
    }
}
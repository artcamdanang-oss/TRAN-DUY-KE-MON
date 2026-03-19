using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{    
    public partial class DangNhap : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdDangNhap_Click(object sender, EventArgs e)
        {
            var dl = db.TaiKhoans.Where(p => p.TenDN == txtTenDN.Text && p.MatKhau == txtMatKhau.Text).FirstOrDefault();
            if (dl != null)
            {
                Session["login"] = true;
                Session["uname"] = dl.TenDN;
                Session["pword"] = dl.MatKhau;
                Session["fname"] = dl.HoTen;
                Session["public"] = false;
                if (dl.TenDN.ToUpper().Equals("ROOT"))
                    Session["type"] = "ADMIN";
                else
                {
                    if (dl.PhanQuyen != null)
                    {
                        if (dl.PhanQuyen != "")
                            Session["type"] = dl.PhanQuyen;

                    }
                }
                db.Dispose();
                Response.Redirect("default.aspx");
            }
            else
            {
                lblThongBao.Text = "Nhập sai thông tin tài khoản, hãy thử lại.";
                txtTenDN.Focus();
            }
        }
    }
}
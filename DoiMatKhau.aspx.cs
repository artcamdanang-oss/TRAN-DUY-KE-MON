using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string us, fn, pw;

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "" || txtMatKhauMoi1.Text == "" || txtMatKhauMoi2.Text == "")
            {
                lblThongBao.Text = "Bạn cần phải nhập đầy đủ thông tin mật khẩu.";
                return;
            }    
            if (pw.Equals(txtMatKhau.Text) == false)
            {
                lblThongBao.Text = "Bạn nhập sai mật khẩu đăng nhập của tài khoản.";
                return;
            }
            if (txtMatKhauMoi1.Text.Equals(txtMatKhauMoi2.Text) == false)
            {
                lblThongBao.Text = "Mật khẩu mới nhập không khớp nhau.";
                return;
            }
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenDN.Equals(us)).FirstOrDefault();
            tk.MatKhau = txtMatKhauMoi1.Text;
            Session["pword"] = txtMatKhauMoi1.Text;
            db.SubmitChanges();
            db.Dispose();
            Response.Write("<script language='javascript'> { window.close(); }</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            us= (string) Session["uname"];
            pw = (string)Session["pword"];
            fn = (string)Session["fname"];
            if (!IsPostBack)
            {
                txtHoTen.Text = fn;
                txtTaiKhoan.Text = us;
            }
        }
    }
}
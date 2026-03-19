using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class CapNhatTaiKhoan : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        int idLenh = 0;
        string ten = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            idLenh = Int32.Parse(Request["ID"]);
            ten = Request["TenDN"];
            if (!IsPostBack)
            {
                LayHoToc();
                if (idLenh == 1) LayThongTin();
            }
        }
        public void LayThongTin()
        {
            TaiKhoan hs = db.TaiKhoans.Where(p => p.TenDN.Equals(ten)).SingleOrDefault();
            if (hs != null)
            {
                txtTenDN.Text = hs.TenDN;
                txtHoTen.Text = hs.HoTen;
                txtMatKhau.Text = hs.MatKhau;
                txtGhiChu.Text = hs.GhiChu;
                if (hs.PhanQuyen != null)
                {
                    if (hs.PhanQuyen.Equals("ADMIN"))
                        cboPhanQuyen.SelectedIndex = 2;
                    else
                        if (hs.PhanQuyen.Equals("USER"))
                            cboPhanQuyen.SelectedIndex = 0;
                        else
                            cboPhanQuyen.SelectedIndex = 1;
                }
                if (hs.PQHoToc != null)
                {
                    string s = hs.PQHoToc;
                    lblHoToc.Text = s.ToUpper();
                    if (s != "")
                    {
                        foreach (ListItem item in chkDSHoToc.Items)
                        {
                            item.Selected = s.Contains(item.Value.ToUpper());
                        }
                    }
                }
            }
        }

        public void LayHoToc()
        {
            var dl = db.HOTOCs.Select(p => new {p.MaHoToc, p.TenHoToc, sName = "[ " + p.MaHoToc + " ] - " + p.TenHoToc}).ToList();
            chkDSHoToc.DataSource = dl;
            chkDSHoToc.DataTextField = "sName";
            chkDSHoToc.DataValueField = "MaHoToc";
            chkDSHoToc.DataBind();
        }

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "" || txtHoTen.Text == "")
            {
                lblThongBao.Text = "Bạn chưa nhập đủ thông tin tài khoản.";
                return;
            }
            if ( idLenh==0 && txtMatKhau.Text == "")
            {
                lblThongBao.Text = "Bạn chưa nhập mật khẩu tài khoản.";
                return;
            }
            //kiem tra trung ten
            var kt = db.TaiKhoans.Where(p => p.TenDN.ToUpper().Equals(txtTenDN.Text.ToUpper())).ToList();
            if (idLenh == 1)
                kt = db.TaiKhoans.Where(p => p.TenDN.ToUpper().Equals(txtTenDN.Text.ToUpper()) && ten.ToUpper().Equals(txtTenDN.Text.ToUpper())==false).ToList();
            if (kt.Count > 0)
            {
                lblThongBao.Text = "Tên đăng nhập bị trùng với tài khoản đã tồn tại.";
                return;
            }
            //cap nhat
            TaiKhoan hs = new TaiKhoan();
            if (idLenh == 1)
                hs = db.TaiKhoans.Where(p => p.TenDN.Equals(ten)).SingleOrDefault();
            hs.TenDN = txtTenDN.Text;
            hs.HoTen = txtHoTen.Text;
            if (idLenh==0 || txtMatKhau.Text!="")
                hs.MatKhau = txtMatKhau.Text;
            hs.GhiChu = txtGhiChu.Text;
            string sPQ = "";
            foreach(ListItem item in chkDSHoToc.Items)
            {
                if (item.Selected == true)
                    sPQ = sPQ + (sPQ.Equals("")==true ? "" : ",") + item.Value.ToString();
            }
            hs.PQHoToc = sPQ;
            if (idLenh == 0)
            {
                db.TaiKhoans.InsertOnSubmit(hs);
            }
            db.SubmitChanges();
            Response.Write("<script language='javascript'> { window.close(); }</script>");
            db.Dispose();
        }
    }
}
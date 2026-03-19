using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class XoaTaiKhoan : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string ten;
        protected void Page_Load(object sender, EventArgs e)
        {
            ten = Request["TenDN"];
            if (!IsPostBack)
            {
                LayThongTin();
                db.Dispose();
            }
        }
        public void LayThongTin()
        {
            var dl = db.TaiKhoans.Where(p => p.TenDN.Equals(ten)).ToList();
            rpTaiKhoan.DataSource = dl;
            rpTaiKhoan.DataBind();
        }

        protected void cmdXoa_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenDN.Equals(ten)).SingleOrDefault();
            db.TaiKhoans.DeleteOnSubmit(tk);
            db.SubmitChanges();
            db.Dispose();
            Response.Write("<script language='javascript'> { window.close(); }</script>");
        }
    }
}
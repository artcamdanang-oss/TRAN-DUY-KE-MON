using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var blackAcc = new List<string> { "Admin", "root" };
                var tk = db.TaiKhoans.Where(p => !blackAcc.Contains(p.TenDN));
                if (tk != null)
                {
                    lvTaiKhoan.DataSource = tk;
                    lvTaiKhoan.DataBind();
                    db.Dispose();
                }
            }
        }
    }
}
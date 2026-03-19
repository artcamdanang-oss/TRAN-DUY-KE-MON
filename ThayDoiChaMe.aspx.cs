using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class ThayDoiChaMe : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs = "";
        int idHoToc;
        protected void Page_Load(object sender, EventArgs e)
        {
            mahs = Request["MaHoSo"];
            if (!IsPostBack)
            {
                HOSO hs = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
                txtHoTen.Text = hs.HoTen;
            }
        }

        protected void cmdTimKiem_Click(object sender, EventArgs e)
        {
            if (txtHoTenTim.Text == "")
                return;
            HOSO hs = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
            idHoToc = (int)hs.IDHoToc;
            string ht = txtHoTenTim.Text.ToUpper();
            var dl = db.HOSOs.Where(p => (p.IDHoToc == idHoToc) && (p.HoTen.ToUpper().Contains(ht) || p.HoTenVoChong.ToUpper().Contains(ht))).OrderBy(p => p.CapHoSo).ToList();
            rpKetQua.DataSource = dl;
            rpKetQua.DataBind();
        }
    }
}
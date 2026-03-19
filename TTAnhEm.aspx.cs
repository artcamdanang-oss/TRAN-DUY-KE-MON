using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class TTAnhEm : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mahs = Request["MaHoSo"];
            if (!IsPostBack)
            {
                HienThongTin(mahs);
                db.Dispose();
            }
        }
        public void HienThongTin(string ma)
        {
            HOSO hs = db.HOSOs.Where(b => b.MaHoSo.Equals(ma)).SingleOrDefault();
            if (hs != null)
            {
                var dl = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ThuTuVoChong == 1).OrderBy(p => p.ConThu).ToList();
                rpThuTu.DataSource = dl;
                rpThuTu.DataBind();
            }
        }

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            HOSO hs = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
            if (hs != null)
            {
                int ttcu, ttmoi;
                var dl = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe)).OrderBy(p => p.ConThu).ToList();
                for(int i=0;i<dl.Count;i++)
                {
                    ttcu = (int) dl[i].ConThu;
                    ttmoi = Int32.Parse(Request.Form["txt" + ttcu]);
                    dl[i].ConThu = ttmoi;
                }
                db.SubmitChanges();
                db.Dispose();
                Response.Redirect("TTAnhEm.aspx?MaHoSo=" + mahs);
            }
        }
    }
}
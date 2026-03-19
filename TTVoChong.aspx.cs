using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class TTVoChong : System.Web.UI.Page
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
                txtHoTen.Text = hs.HoTen;
                var dl = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ConThu == hs.ConThu).OrderBy(p => p.ThuTuVoChong).ToList();
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
                var dl = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ConThu == hs.ConThu).OrderBy(p => p.ThuTuVoChong).ToList();
                for (int i = 0; i < dl.Count; i++)
                {
                    ttcu = (int)dl[i].ThuTuVoChong;
                    ttmoi = Int32.Parse(Request.Form["txt" + ttcu]);
                    dl[i].ThuTuVoChong = ttmoi;
                }
                db.SubmitChanges();
                db.Dispose();
                Response.Redirect("TTVoChong.aspx?MaHoSo=" + mahs);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class CapNhatChaMe : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs = "",mabmCu="", mabmMoi="";
        string sMaNoiToc = "";
        int conthu = 0, capcu = 0, capmoi = 0, chenhlech=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            mahs = Request["MaHoSo"];
            mabmMoi = Request["MaBoMe"];
            sMaNoiToc = ";" + mahs + ";";
            HienThongTin();
            Hienthigiapha(mahs);
            if (sMaNoiToc.Contains(";" + mabmMoi + ";") == true)
            {
                lblThongBao.Text = "Cha mẹ thuộc nhánh cây con, không cho phép cập nhật.";
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                cmdGhi.Visible = false;
            }
            else
            {
                lblThongBao.Text = "Được phép cập nhật hồ sơ cha mẹ cho hồ sơ chọn.";
                lblThongBao.ForeColor = System.Drawing.Color.Blue;
                cmdGhi.Visible = true;
            }
        }
        public void HienThongTin()
        {
            HOSO hs = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
            txtHoTen.Text = hs.HoTen;
            mabmCu = hs.MaHoSoBoMe;
            conthu = (int)hs.ConThu;
            capcu = (int)hs.CapHoSo;

            HOSO cm = db.HOSOs.Where(p => p.MaHoSo.Equals(mabmMoi)).SingleOrDefault();
            capmoi = (int)cm.CapHoSo + 1;
            if (capmoi != capcu) chenhlech = capmoi - capcu;

            if ((bool)cm.GioiTinh == true)
            {
                txtHoTenCha.Text = cm.HoTen;
                txtHoTenMe.Text = cm.HoTenVoChong;
            }
            else
            {
                txtHoTenCha.Text = cm.HoTenVoChong;
                txtHoTenMe.Text = cm.HoTen;
            }
        }

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            var up = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabmCu) && p.ConThu == conthu).ToList();
            int conthuNew = layMaxConThu();
            foreach(HOSO h in up)
            {
                h.ConThu = conthuNew;
                h.MaHoSoBoMe = mabmMoi;
                h.CapHoSo = capmoi;
                db.SubmitChanges();
                if (chenhlech != 0)
                {
                    capnhatcaphoso(h.MaHoSo, capmoi);
                }
            }
            var tt = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabmCu) && p.ConThu > conthu).ToList();
            foreach(HOSO h in tt)
            {
                h.ConThu = h.ConThu - 1;
            }
            db.SubmitChanges();
            db.Dispose();
            Response.Write("<script language='javascript'> { window.close(); }</script>");
        }

        public void capnhatcaphoso(string mahosobome, int capbome)
        {
            var dl = db.HOSOs.OrderBy(p => p.CapHoSo).ThenBy(p => p.ConThu).ThenBy(p => p.ThuTuVoChong).Where(p => p.MaHoSoBoMe.Equals(mahosobome)).ToList();
            dl.ForEach(p => {
                p.CapHoSo = capbome + 1;
                db.SubmitChanges();
                capnhatcaphoso(p.MaHoSo,(int) p.CapHoSo);
            });
        }

        public int layMaxConThu()
        {
            int iConThu = 1;
            var dl1 = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabmMoi)).ToList();
            if (dl1.Count > 0)
            {
                int dl = Int32.Parse(db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabmMoi)).Max(p => p.ConThu).ToString());
                iConThu = dl + 1;
            }
            return iConThu;
        }

        public void Hienthigiapha(string mahosobome)
        {
            var dl = db.HOSOs.OrderBy(p => p.CapHoSo).ThenBy(p => p.ConThu).ThenBy(p => p.ThuTuVoChong).Where(p => p.MaHoSoBoMe.Equals(mahosobome)).ToList();
            dl.ForEach(p => {                
                sMaNoiToc += ";" + p.MaHoSo + ";";
                Hienthigiapha(p.MaHoSo);
            });
        }
    }
}
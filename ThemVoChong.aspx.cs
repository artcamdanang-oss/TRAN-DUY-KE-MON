using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class ThemVoChong : System.Web.UI.Page
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
                string mabm = hs.MaHoSoBoMe;
                int conthu= (int) hs.ConThu;
                txtHoTen.Text = hs.HoTen;

                int dl = Int32.Parse(db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabm) && p.ConThu==conthu).Max(p => p.ThuTuVoChong).ToString()) +1 ;
                txtThuTuVC.Text = dl.ToString();
            }
        }

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtHoTenVC.Text == "")
                return;
            HOSO hs1 = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
            HOSO hs = new HOSO();

            hs.IDHoToc = hs1.IDHoToc;
            hs.CapHoSo = hs1.CapHoSo;
            hs.LoaiCon = hs1.LoaiCon;
            hs.DanToc = "Kinh";
            hs.TonGiao = "Không";
            hs.MaHoSoBoMe = hs1.MaHoSoBoMe;
            hs.MaHoSo = "Truongbt";

            hs.HoTen = hs1.HoTen;
            hs.TenThuongGoi = hs1.TenThuongGoi;
            hs.TenHieu = hs1.TenHieu;
            hs.NgaySinh = hs1.NgaySinh;
            hs.ConThu = hs1.ConThu;
            hs.GioiTinh = hs1.GioiTinh;
            hs.SoCMTND = hs1.SoCMTND;
            hs.SoLienLac = hs1.SoLienLac;
            hs.SoHoChieu = hs1.SoHoChieu;
            hs.ThuDienTu = hs1.ThuDienTu;
            hs.QuocTich = hs1.QuocTich;
            hs.NoiSinh = hs1.NoiSinh;
            hs.DiaChi = hs1.DiaChi;
            hs.GhiChu = hs1.GhiChu;

            hs.NgayMatDL = hs1.NgayMatDL;
            hs.NgayMatAL = hs1.NgayMatAL;
            hs.NoiAnTang = hs1.NoiAnTang;
            hs.DaMat = hs1.DaMat;

            hs.HoTenVoChong = txtHoTenVC.Text;
            hs.ThuTuVoChong = (txtThuTuVC.Text == "" ? 2 : Int32.Parse(txtThuTuVC.Text));
            hs.DaLyDi = chkDaLyHon.Checked;
            hs.NgaySinhVoChong = txtNgaySinhVC.Text;
            hs.SoLienLacVoChong = txtDienThoaiVC.Text;
            hs.ThuDienTuVoChong = txtEmailVC.Text;
            hs.NoiSinhVoChong = txtNoiSinhVC.Text;

            hs.NgayMatDLVoChong = txtNgayMatDLVC.Text;
            hs.NgayMatVoChong = txtNgayMatALVC.Text;
            hs.NoiAnTangVoChong = txtNoiAnTangVC.Text;
            hs.DaMatVC = (txtNgayMatDLVC.Text != "" || txtNgayMatALVC.Text != "") ? true : false;
            
            db.HOSOs.InsertOnSubmit(hs);
            db.SubmitChanges();

            //cap nhat ma ho so
            HOSO dl = db.HOSOs.Where(p => p.MaHoSo.Equals("Truongbt")).SingleOrDefault();
            int idHS = dl.IDHoSo;
            string mahsmoi = "B" + idHS.ToString("000000000000000");
            dl.MaHoSo = mahsmoi;
            db.SubmitChanges();
            db.Dispose();
            Response.Redirect("ThemVoChong.aspx?MaHoSo=" + mahs);
        }
    }
}
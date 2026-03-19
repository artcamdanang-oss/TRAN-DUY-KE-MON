using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class ThemCon : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs;
        int caphs, idhotoc, conthu;

        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            HOSO hs = new HOSO();
            DocThongTin(hs);
            db.HOSOs.InsertOnSubmit(hs);
            db.SubmitChanges();
            //cap nhat ma ho so
            HOSO dl = db.HOSOs.Where(p => p.MaHoSo.Equals("Truongbt")).SingleOrDefault();
            int idHS = dl.IDHoSo;
            string mahsmoi = "B" + idHS.ToString("000000000000000");
            dl.MaHoSo = mahsmoi;
            db.SubmitChanges();
            db.Dispose();
            Response.Redirect("ThemCon.aspx?MaHoSo=" + mahs);
        }
        public void DocThongTin(HOSO hs)
        {
            HOSO info = db.HOSOs.Where(b => b.MaHoSo.Equals(mahs)).SingleOrDefault();
            idhotoc = (int)info.IDHoToc;
            caphs = (int)info.CapHoSo + 1;

            hs.IDHoToc = idhotoc;
            hs.CapHoSo = caphs;
            hs.LoaiCon = "0";
            hs.DanToc = "Kinh";
            hs.TonGiao = "Không";
            hs.MaHoSoBoMe = mahs;
            hs.MaHoSo = "Truongbt";

            hs.HoTen = txtHoTen.Text;
            hs.TenThuongGoi = ""; hs.TenHieu = "";
            hs.NgaySinh = txtNgaySinh.Text;
            hs.ConThu = (txtConThu.Text == "" ? 1 : Int32.Parse(txtConThu.Text));
            hs.LoaiCon = cboLoaiCon.SelectedValue.ToString();
            //hs.GioiTinh = (txtGioiTinh.Text.ToUpper().Equals("NAM") ? true : false);
            hs.GioiTinh = (cboGioiTinh.SelectedIndex == 1 ? false : true);
            if (cboGioiTinh.SelectedIndex == 2)
                hs.GioiTinhGC = "Không rõ";
            else
                hs.GioiTinhGC = "";
            hs.SoCMTND = ""; hs.SoLienLac = ""; hs.SoHoChieu = ""; hs.ThuDienTu = "";
            hs.QuocTich = "Việt Nam";
            hs.NoiSinh = txtNoiSinh.Text; hs.DiaChi = txtDiaChi.Text;
            hs.GhiChu = "";

            hs.NgayMatDL = ""; hs.NgayMatAL = ""; hs.NoiAnTang = ""; hs.DaMat = false;

            hs.HoTenVoChong = txtHoTenVC.Text;
            hs.ThuTuVoChong = (txtThuTuVC.Text == "" ? 1 : Int32.Parse(txtThuTuVC.Text));
            hs.DaLyDi = chkDaLyHon.Checked;
            hs.NgaySinhVoChong = ""; hs.SoLienLacVoChong = ""; hs.ThuDienTuVoChong = "";
            hs.NoiSinhVoChong = txtNoiSinhVC.Text;

            hs.NgayMatDLVoChong = ""; hs.NgayMatVoChong = ""; hs.NoiAnTangVoChong = ""; hs.DaMatVC = false;
        }
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
                idhotoc = (int)hs.IDHoToc;
                caphs = (int)hs.CapHoSo + 1;
                if (hs.GioiTinh == true)
                {
                    txtHoTenBo.Text = hs.HoTen;
                    txtHoTenMe.Text = hs.HoTenVoChong;
                }
                else
                {
                    txtHoTenMe.Text = hs.HoTen;
                    txtHoTenBo.Text = hs.HoTenVoChong;
                }
                var dl1 = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(ma)).ToList();
                txtConThu.Text = "1";
                if (dl1.Count > 0)
                {
                    int dl = Int32.Parse(db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(ma)).Max(p => p.ConThu).ToString());
                    conthu = dl + 1;
                    txtConThu.Text = conthu.ToString();
                }

            }
        }
    }
}
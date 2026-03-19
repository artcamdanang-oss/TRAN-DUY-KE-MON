using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class ThemHoSo : System.Web.UI.Page
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
            Response.Redirect("ThemHoSo.aspx?MaHoSo=" + mahs);
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
            hs.TenThuongGoi = txtThuongGoi.Text;
            hs.TenHieu = txtTenHieu.Text;
            hs.NgaySinh = txtNgaySinh.Text;
            hs.ConThu = (txtConThu.Text == "" ? 1 : Int32.Parse(txtConThu.Text));
            hs.LoaiCon = cboLoaiCon.SelectedValue.ToString();
            hs.GioiTinh = (cboGioiTinh.SelectedIndex == 1 ? false : true);
            if (cboGioiTinh.SelectedIndex == 2)
                hs.GioiTinhGC = "Không rõ";
            else
                hs.GioiTinhGC = "";
            hs.SoCMTND = txtCMTND.Text;
            hs.SoLienLac = txtDienThoai.Text;
            hs.SoHoChieu = txtHoChieu.Text;
            hs.ThuDienTu = txtEmail.Text;
            hs.QuocTich = txtQuocTich.Text != "" ? txtQuocTich.Text : "Việt Nam";
            hs.DanToc = txtDanToc.Text != "" ? txtDanToc.Text : "Kinh";
            hs.TonGiao = txtTonGiao.Text != "" ? txtTonGiao.Text : "Không";
            hs.NoiSinh = txtNoiSinh.Text;
            hs.DiaChi = txtDiaChi.Text;
            hs.GhiChu = txtGhiChu.Text;

            hs.NgayMatDL = txtNgayMatDL.Text;
            hs.NgayMatAL = txtNgayMatAL.Text;
            hs.NoiAnTang = txtNoiAnTang.Text;
            hs.DaMat = (txtNgayMatDL.Text != "" || txtNgayMatAL.Text != "") ? true : false;

            hs.HoTenVoChong = txtHoTenVC.Text;
            hs.ThuTuVoChong = (txtThuTuVC.Text == "" ? 1 : Int32.Parse(txtThuTuVC.Text));
            hs.DaLyDi = chkDaLyHon.Checked;
            hs.NgaySinhVoChong = txtNgaySinhVC.Text;
            hs.SoLienLacVoChong = txtDienThoaiVC.Text;
            hs.ThuDienTuVoChong = txtEmailVC.Text;
            hs.NoiSinhVoChong = txtNoiSinhVC.Text;

            hs.NgayMatDLVoChong = txtNgayMatDLVC.Text;
            hs.NgayMatVoChong = txtNgayMatALVC.Text;
            hs.NoiAnTangVoChong = txtNoiAnTangVC.Text;
            hs.DaMatVC = (txtNgayMatDLVC.Text != "" || txtNgayMatALVC.Text != "") ? true : false;
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
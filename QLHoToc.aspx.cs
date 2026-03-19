using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class QLHoToc : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();        
        int idHoToc = 0, idLenh = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            idHoToc = Int32.Parse(Request["IDHoToc"]);
            idLenh = Int32.Parse(Request["ID"]);
            if (!IsPostBack)
            {
                if (idLenh==1) LayThongTin();
            }
        }
        public void LayThongTin()
        {
            HOTOC hs = db.HOTOCs.Where(p => p.IDHoToc==idHoToc).SingleOrDefault();
            if (hs != null)
            {
                txtMaHoToc.Text = hs.MaHoToc;
                txtTenHoToc.Text = hs.TenHoToc;
                txtDoiThu.Text = hs.DoiThu.ToString();
                if (hs.MaNguoiLap.Equals("ZON") == true)
                    cboChiaSe.SelectedIndex = 0;
                else
                    cboChiaSe.SelectedIndex = 1;
                txtToOng.Text = hs.TenToOng;
                txtGioOng.Text = hs.GioToOng;
                txtToBa.Text = hs.TenToBa;
                txtGioBa.Text = hs.GioToBa;
                txtGhiChu.Text = hs.GhiChuHoToc;
            }
        }
        protected void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtMaHoToc.Text == "" || txtTenHoToc.Text=="")
                return;
            HOTOC hs = new HOTOC();
            if (idLenh==1)
                hs = db.HOTOCs.Where(p => p.IDHoToc == idHoToc).SingleOrDefault();
            hs.MaHoToc = txtMaHoToc.Text;
            hs.TenHoToc = txtTenHoToc.Text;
            hs.DoiThu = Int32.Parse(txtDoiThu.Text);
            if (cboChiaSe.SelectedIndex == 0)
                hs.MaNguoiLap = "ZON";
            else
                hs.MaNguoiLap = "";
            hs.TenToOng = txtToOng.Text;
            hs.GioToOng = txtGioOng.Text;
            hs.TenToBa = txtToBa.Text;
            hs.GioToBa = txtGioBa.Text;
            hs.GhiChuHoToc = txtGhiChu.Text;
            if (idLenh == 0)
            {
                hs.TenTruongHo = ""; hs.MaTruongHo = "";
                hs.TenNguoiLap = "";
                db.HOTOCs.InsertOnSubmit(hs);
            }
            db.SubmitChanges();
            if (idLenh == 0)
            {
                //ghi lai ho toc neu tai khoan han che xem ho toc
                string sHT = Module.TBT.LayPQHoToc((string)Session["uname"]);
                if (sHT.Equals("") == false)
                {
                    string un = (string)Session["uname"];
                    var dl = db.TaiKhoans.Where(p => p.TenDN.Equals(un)).SingleOrDefault();
                    sHT = sHT + "," + txtMaHoToc.Text;
                    dl.PQHoToc = sHT;
                    db.SubmitChanges();
                }
                ThemThuyTo();
            }
            Response.Write("<script language='javascript'> { window.close(); }</script>");
            db.Dispose();
        }
        public void ThemThuyTo()
        {
            //tim idhotoc
            HOTOC ho = db.HOTOCs.OrderByDescending(p => p.IDHoToc).FirstOrDefault();
            int idHT = (int) ho.IDHoToc;
            //them hoso
            HOSO hs = new HOSO();
            hs.IDHoToc = idHT;
            hs.CapHoSo = 0;
            hs.LoaiCon = "0";
            hs.DanToc = "Kinh"; hs.TonGiao = "Không";
            hs.MaHoSoBoMe = "NULL";
            hs.MaHoSo = "Truongbt";

            hs.HoTen = "Thủy tổ";
            hs.TenThuongGoi = ""; hs.TenHieu = "";
            hs.NgaySinh = "";hs.ConThu = 1;hs.GioiTinh = true ;
            hs.SoCMTND = ""; hs.SoLienLac = ""; hs.SoHoChieu = ""; hs.ThuDienTu = "";
            hs.QuocTich = "Việt Nam"; hs.NoiSinh = ""; hs.DiaChi = ""; hs.GhiChu = "";
            hs.NgayMatDL = ""; hs.NgayMatAL = ""; hs.NoiAnTang = ""; hs.DaMat = false;

            hs.HoTenVoChong = "";hs.ThuTuVoChong = 1;hs.DaLyDi = false;
            hs.NgaySinhVoChong = ""; hs.SoLienLacVoChong = ""; hs.ThuDienTuVoChong = ""; hs.NoiSinhVoChong = "";
            hs.NgayMatDLVoChong = ""; hs.NgayMatVoChong = ""; hs.NoiAnTangVoChong = ""; hs.DaMatVC = false;
            db.HOSOs.InsertOnSubmit(hs);
            db.SubmitChanges();

            //cap nhat ma ho so
            HOSO dl = db.HOSOs.Where(p => p.MaHoSo.Equals("Truongbt")).SingleOrDefault();
            int idHS = dl.IDHoSo;
            string mahsmoi = "B" + idHS.ToString("000000000000000");
            dl.MaHoSo = mahsmoi;
            db.SubmitChanges();
        }
    }
}
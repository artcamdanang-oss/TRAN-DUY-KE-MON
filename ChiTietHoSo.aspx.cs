using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class ChiTietHoSo : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs = "", mabm = "NULL";
        int caphs=0;
        string giadinh = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            mahs = Request["MaHoSo"];
            if (!IsPostBack)
            {
                LayThongTin();
                LayThongTinGiaDinh();
                db.Dispose();
            }
        }
        public void LayThongTin()
        {
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            if (hs != null)
            {
                txtHoTen.Text = hs.HoTen; txtThuongGoi.Text = hs.TenThuongGoi; txtTenHieu.Text = hs.TenHieu;
                txtNgaySinh.Text = hs.NgaySinh; txtConThu.Text = hs.ConThu.ToString();
                if (hs.GioiTinh == true)
                {
                    if (hs.GioiTinhGC!=null && hs.GioiTinhGC != "")
                        cboGioiTinh.SelectedIndex = 2;
                    else
                        cboGioiTinh.SelectedIndex = 0;
                }
                else
                    cboGioiTinh.SelectedIndex = 1;
                txtCMTND.Text = hs.SoCMTND; txtDienThoai.Text = hs.SoLienLac; txtHoChieu.Text = hs.SoHoChieu;
                txtEmail.Text = hs.ThuDienTu; txtQuocTich.Text = hs.QuocTich; txtNoiSinh.Text = hs.NoiSinh;
                cboLoaiCon.SelectedValue = hs.LoaiCon;txtDanToc.Text = hs.DanToc;txtTonGiao.Text = hs.TonGiao;
                txtDiaChi.Text = hs.DiaChi; txtGhiChu.Text = hs.GhiChu;

                txtNgayMatDL.Text = hs.NgayMatDL; txtNgayMatAL.Text = hs.NgayMatAL; txtNoiAnTang.Text = hs.NoiAnTang;

                txtHoTenVC.Text = hs.HoTenVoChong; txtThuTuVC.Text = hs.ThuTuVoChong.ToString(); txtNgaySinhVC.Text = hs.NgaySinhVoChong;
                txtDienThoaiVC.Text = hs.SoLienLacVoChong; txtEmailVC.Text = hs.ThuDienTuVoChong; txtNoiSinhVC.Text = hs.NoiSinhVoChong;
                chkDaLyHon.Checked = hs.DaLyDi==true ? true : false;
                txtNgayMatDLVC.Text = hs.NgayMatDLVoChong; txtNgayMatALVC.Text = hs.NgayMatVoChong; txtNoiAnTangVC.Text = hs.NoiAnTangVoChong;

                mabm = hs.MaHoSoBoMe;
                caphs = (int)hs.CapHoSo;
                
                //hinh anh
                byte[] data;
                string image;                
                if (hs.HinhAnh != null)
                {
                    data = (byte[]) hs.HinhAnh.ToArray();
                    image = Convert.ToBase64String(data);
                    imgHoSo.ImageUrl = "data:Image/png;base64," + image;
                    lblHoTen.Text = hs.HoTen;
                }
                if (hs.HinhAnhVoChong != null)
                {
                    data = (byte[])hs.HinhAnhVoChong.ToArray();
                    image = Convert.ToBase64String(data);
                    imgVoChong.ImageUrl = "data:Image/png;base64," + image;
                    lblHoTenVoChong.Text = hs.HoTenVoChong;
                }

            }
        }
        public void LayThongTinGiaDinh()
        {
            if (caphs > 0)
            {
                HOSO bm = db.HOSOs.Where(b => b.MaHoSo.Equals(mabm)).SingleOrDefault();
                if (bm != null)
                {
                    if (bm.GioiTinh == true)
                    {
                        txtHoTenBo.Text = bm.HoTen;
                        txtHoTenMe.Text = bm.HoTenVoChong;
                        giadinh = "Bố : <a href='ChiTietHoSo.aspx?MaHoSo=" + bm.MaHoSo + "'>" + bm.HoTen + "</a>" + (bm.HoTenVoChong!="" ? ", Mẹ : " + bm.HoTenVoChong : "");
                    }
                    else
                    {
                        txtHoTenMe.Text = bm.HoTen;
                        txtHoTenBo.Text = bm.HoTenVoChong;
                        giadinh = "Mẹ : <a href='ChiTietHoSo.aspx?MaHoSo=" + bm.MaHoSo + "'>" + bm.HoTen + "</a>" + (bm.HoTenVoChong != "" ? ", Bố : " + bm.HoTenVoChong : "");
                    }
                    lblGiaDinh.Text = "Gia Đình : " + giadinh;
 
                }
            }
            else
            {
                txtHoTenMe.Text = "NULL";txtHoTenBo.Text = "NULL";                
            }
            //tim anh em
            var ae = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabm) && (caphs > 0)).OrderBy(p => p.ThuTuVoChong).OrderBy(p => p.ConThu).ToList();
            if (ae.Count>0)
            {
                giadinh = "Anh, chị em : <br />";                
                foreach (HOSO h in ae)
                {
                    giadinh = giadinh + h.ConThu + ". <a href='ChiTietHoSo.aspx?MaHoSo=" + h.MaHoSo + "'>" + h.HoTen + ((bool)h.DaLyDi == false && h.HoTenVoChong!="" ? " - " + h.HoTenVoChong : "") + "</a> <br />";
                }
                lblAnhEm.Text = giadinh;
            }
            

            //tim con cai
            var cc = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mahs)).OrderBy(p => p.ThuTuVoChong).OrderBy(p=>p.ConThu).ToList();
            if (cc.Count>0)
            {
                giadinh = "Con : <br />";
                foreach (HOSO h in cc)
                {
                    giadinh = giadinh + h.ConThu + ". <a href='ChiTietHoSo.aspx?MaHoSo=" + h.MaHoSo + "'>" + h.HoTen + ((bool)h.DaLyDi== false && h.HoTenVoChong != "" ? " - " + h.HoTenVoChong : "") + "</a> <br />";
                }
                lblConCai.Text = giadinh;
            }
            
        }
        protected void cmdGhi_Click1(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            DocThongTin(hs);
            db.SubmitChanges();
            db.Dispose();
        }

        protected void cmdThemCon_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            Response.Redirect("ThemHoSo.aspx?MaHoSo=" + mahs);
        }

        protected void cmdThemVoChong_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            if (txtHoTenVC.Text == "")
            {
                lblThongBao.Text = "Nhập trực tiếp vợ/chồng vào hồ sơ đang xem.";
                return;
            }
            Response.Redirect("ThemVoChong.aspx?MaHoSo=" + mahs);
        }

        protected void cmdTTAnhEm_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            Response.Redirect("TTAnhEm.aspx?MaHoSo=" + mahs);
        }

        protected void cmdTTVoChong_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            Response.Redirect("TTVoChong.aspx?MaHoSo=" + mahs);
        }

        protected void cmdXoaHoSo_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            var kt = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mahs)).ToList();
            if (kt != null)
            {
                if (kt.Count > 0)
                {
                    lblThongBao.Text = "Không xóa được hồ sơ có con - cháu";
                    return;
                }
                HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
                //update thu tu vo chong
                var vc = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ConThu == hs.ConThu && p.ThuTuVoChong > hs.ThuTuVoChong).ToList();
                foreach (HOSO i in vc)
                    i.ThuTuVoChong = i.ThuTuVoChong - 1;
                db.SubmitChanges();
                var dem = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ConThu == hs.ConThu && p.MaHoSo.Equals(mahs)==false).ToList();
                if (dem.Count <= 0)
                {
                    //update thu tu anh em
                    var ac = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(hs.MaHoSoBoMe) && p.ConThu > hs.ConThu).ToList();
                    foreach (HOSO i in ac)
                        i.ConThu = i.ConThu - 1;
                }
                //ghi thay doi
                db.HOSOs.DeleteOnSubmit(hs);
                db.SubmitChanges();
                db.Dispose();
                Response.Write("<script language='javascript'> { window.close(); }</script>");
            }
        }

        protected void cmdThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            Response.Redirect("ThemCon.aspx?MaHoSo=" + mahs);
        }

        protected void cmdUpHA_Click(object sender, EventArgs e)
        {
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            if (upHinhAnh.HasFile)
            {
                hs.HinhAnh = upHinhAnh.FileBytes;
                db.SubmitChanges();
                db.Dispose();
                Response.Redirect("ChiTietHoSo.aspx?MaHoSo=" + mahs);
            }
        }

        protected void cmdUpHAVC_Click(object sender, EventArgs e)
        {
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            if (upHinhAnhVC.HasFile)
            {
                hs.HinhAnhVoChong = upHinhAnhVC.FileBytes;
                db.SubmitChanges();
                db.Dispose();
                Response.Redirect("ChiTietHoSo.aspx?MaHoSo=" + mahs);
            }
        }

        protected void cmdDelHA_Click(object sender, EventArgs e)
        {
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            hs.HinhAnh = null;
            db.SubmitChanges();
            db.Dispose();
            Response.Redirect("ChiTietHoSo.aspx?MaHoSo=" + mahs);
        }

        protected void cmdDelHAVC_Click(object sender, EventArgs e)
        {
            HOSO hs = db.HOSOs.Where(p => p.MaHoSo.Equals(mahs)).SingleOrDefault();
            hs.HinhAnhVoChong = null;
            db.SubmitChanges();
            db.Dispose();
            Response.Redirect("ChiTietHoSo.aspx?MaHoSo=" + mahs);
        }

        protected void cmdDoiChaMe_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                return;
            Response.Redirect("ThayDoiChaMe.aspx?MaHoSo=" + mahs);
        }

        public void DocThongTin(HOSO hs)
        {
            hs.HoTen=txtHoTen.Text;
            hs.TenThuongGoi=txtThuongGoi.Text;
            hs.TenHieu=txtTenHieu.Text;
            hs.NgaySinh=txtNgaySinh.Text;
            hs.ConThu= (txtConThu.Text=="" ?  1: Int32.Parse(txtConThu.Text));
            hs.LoaiCon = cboLoaiCon.SelectedValue.ToString();
            hs.GioiTinh = (cboGioiTinh.SelectedIndex == 1 ? false : true);
            if (cboGioiTinh.SelectedIndex == 2)
                hs.GioiTinhGC = "Không rõ";
            else
                hs.GioiTinhGC = "";
            hs.SoCMTND=txtCMTND.Text;
            hs.SoLienLac=txtDienThoai.Text;
            hs.SoHoChieu=txtHoChieu.Text;
            hs.ThuDienTu=txtEmail.Text;
            hs.QuocTich=txtQuocTich.Text!=""? txtQuocTich.Text:"Việt Nam";
            hs.DanToc = txtDanToc.Text != "" ? txtDanToc.Text : "Kinh";
            hs.TonGiao = txtTonGiao.Text != "" ? txtTonGiao.Text : "Không";
            hs.NoiSinh=txtNoiSinh.Text;
            hs.DiaChi=txtDiaChi.Text;
            hs.GhiChu=txtGhiChu.Text;

            hs.NgayMatDL = txtNgayMatDL.Text;
            hs.NgayMatAL = txtNgayMatAL.Text;
            hs.NoiAnTang = txtNoiAnTang.Text;
            hs.DaMat = (txtNgayMatDL.Text!="" || txtNgayMatAL.Text!="") ? true : false;

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
    }
}
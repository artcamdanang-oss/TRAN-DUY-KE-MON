using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class XemChiTiet : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        string mahs = "", mabm = "NULL";
        int caphs = 0, idoithu = 1;
        string giadinh = "";
        string thongtin = "", temp = "",gt="",lc="";

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
                thongtin = "";
                caphs = (int)hs.CapHoSo;
                idoithu = Module.TBT.LayDoiThu((int) hs.IDHoToc);
                thongtin += "Họ và Tên : " + hs.HoTen + " (đời thứ " + (caphs + idoithu) + ")<br />";
                if (hs.TenThuongGoi != "") thongtin += "    Thường gọi là :  " + hs.TenThuongGoi + "<br />";
                if (hs.TenHieu != "") thongtin += "    Tên hiệu : " + hs.TenHieu + "<br />";
                if (hs.NgaySinh != "") thongtin += "    Sinh ngày : " + hs.NgaySinh + "<br />";
                if (hs.GioiTinh == true)
                {
                    if (hs.GioiTinhGC != null && hs.GioiTinhGC != "")
                        gt = "Không rõ";
                    else
                        gt = "Nam";
                }
                else
                    gt = "Nữ";
                lc = "";
                if (Convert.ToInt32(hs.LoaiCon) > 0)
                {
                    switch (hs.LoaiCon)
                    {
                        case "1":
                            lc = "Con nuôi";
                            break;
                        case "2":
                            lc = "Con riêng của mẹ";
                            break;
                        case "3":
                            lc = "Con riêng của bố";
                            break;
                    }
                }
                thongtin += "    Giới tính : " + gt + " - là con thứ : " + hs.ConThu.ToString() + "." + (lc==""? "": lc) + "<br />";
                if (hs.NoiSinh != "") thongtin += "    Nơi sinh : " + hs.NoiSinh + "<br />";
                if (hs.DiaChi != "") thongtin += (hs.DaMat==true ? "    Địa chỉ : " : "    Nơi ở hiện tại : ") + hs.DiaChi + "<br />";
                temp = "";
                if (hs.SoCMTND != "") temp += "    Số CCCD/CMTND : " + hs.SoCMTND;
                if (hs.SoHoChieu != "") temp += (temp==""?"":" - ") + "    Số Hộ chiếu : " + hs.SoHoChieu;
                if (temp != "") thongtin += temp + "<br />";
                temp = "";
                if (hs.SoLienLac != "") temp += "    Số liên lạc : " + hs.SoLienLac;
                if (hs.ThuDienTu != "") temp += (temp == "" ? "" : " - ") + "    Email : " + hs.ThuDienTu;
                if (temp != "") thongtin += temp + "<br />";
                temp = "";
                if (hs.DanToc != "") temp += "    Dân tộc : " + hs.DanToc;
                if (hs.TonGiao != "") temp += (temp == "" ? "" : ", ") + "Tôn giáo : " + hs.TonGiao;
                if (hs.QuocTich != "") temp += (temp == "" ? "" : ", ") + "Quốc tịch : " + hs.QuocTich;
                if (temp != "") thongtin += temp + "<br />";
                temp = "";
                if (hs.NgayMatDL != "") temp += "    Mất ngày (DL) : " + hs.NgayMatDL;
                if (hs.NgayMatAL != "") temp += (temp == "" ? "Mất ngày " : ", ") + "âm lịch : " + hs.NgayMatAL;
                if (hs.NoiAnTang != "") temp += (temp == "" ? "" : ", ") + "an táng tại : " + hs.NoiAnTang;
                if (temp != "") thongtin += temp + "<br />";

                if (hs.HoTenVoChong != "")
                {
                    thongtin += "<br />Đã kết hôn với : " + hs.HoTenVoChong + 
                        (Convert.ToInt32(hs.ThuTuVoChong)>1? " (là " + (hs.GioiTinh == true ? "vợ" : "chồng") + " thứ " + hs.ThuTuVoChong + ")":"") + 
                        (hs.DaLyDi == true? " - đã ly hôn": "") + 
                        "<br />";
                    if (hs.NgaySinhVoChong != "") thongtin += "    Sinh ngày : " + hs.NgaySinhVoChong + "<br />";
                    if (hs.NoiSinhVoChong != "") thongtin += "    Nơi sinh : " + hs.NoiSinhVoChong + "<br />";
                    temp = "";
                    if (hs.SoLienLacVoChong != "") temp += "    Số liên lạc : " + hs.SoLienLacVoChong;
                    if (hs.ThuDienTuVoChong != "") temp += (temp == "" ? "" : " - ") + "    Email : " + hs.ThuDienTuVoChong;
                    if (temp != "") thongtin += temp + "<br />";
                    temp = "";
                    if (hs.NgayMatDLVoChong != "") temp += "    Mất ngày (DL) : " + hs.NgayMatDLVoChong;
                    if (hs.NgayMatVoChong != "") temp += (temp == "" ? "Mất ngày " : ", ") + "âm lịch : " + hs.NgayMatVoChong;
                    if (hs.NoiAnTangVoChong != "") temp += (temp == "" ? "" : ", ") + "an táng tại : " + hs.NoiAnTangVoChong;
                    if (temp != "") thongtin += temp + "<br />";
                }

                lblThongTin.Text = thongtin;
                txtGhiChu.Visible = false;
                note.Visible = false;
                if (hs.GhiChu != "")
                {
                    txtGhiChu.Visible = true;
                    txtGhiChu.Text = hs.GhiChu;
                    txtGhiChu.Height = 50;
                    note.Visible = true;
                }
                   
                mabm = hs.MaHoSoBoMe;
                

                //hinh anh
                byte[] data;
                string image;
                if (hs.HinhAnh != null)
                {
                    data = (byte[])hs.HinhAnh.ToArray();
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
                        giadinh = "Bố : <a href='XemChiTiet.aspx?MaHoSo=" + bm.MaHoSo + "'>" + bm.HoTen + "</a>" + (bm.HoTenVoChong != "" ? ", Mẹ : " + bm.HoTenVoChong : "");
                    }
                    else
                    {
                        giadinh = "Mẹ : <a href='XemChiTiet.aspx?MaHoSo=" + bm.MaHoSo + "'>" + bm.HoTen + "</a>" + (bm.HoTenVoChong != "" ? ", Bố : " + bm.HoTenVoChong : "");
                    }
                    lblGiaDinh.Text = "Gia Đình : " + giadinh;
                }
            }
            //tim anh em
            var ae = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mabm) && (caphs > 0)).OrderBy(p => p.ThuTuVoChong).OrderBy(p => p.ConThu).ToList();
            if (ae.Count > 0)
            {
                giadinh = "Anh, chị em : <br />";
                foreach (HOSO h in ae)
                {
                    giadinh = giadinh + h.ConThu + ". <a href='XemChiTiet.aspx?MaHoSo=" + h.MaHoSo + "'>" + h.HoTen + ((bool)h.DaLyDi == false && h.HoTenVoChong != "" ? " - " + h.HoTenVoChong : "") + "</a> <br />";
                }
                lblAnhEm.Text = giadinh;
            }


            //tim con cai
            var cc = db.HOSOs.Where(p => p.MaHoSoBoMe.Equals(mahs)).OrderBy(p => p.ThuTuVoChong).OrderBy(p => p.ConThu).ToList();
            if (cc.Count > 0)
            {
                giadinh = "Con : <br />";
                foreach (HOSO h in cc)
                {
                    giadinh = giadinh + h.ConThu + ". <a href='XemChiTiet.aspx?MaHoSo=" + h.MaHoSo + "'>" + h.HoTen + ((bool)h.DaLyDi == false && h.HoTenVoChong != "" ? " - " + h.HoTenVoChong : "") + "</a> <br />";
                }
                lblConCai.Text = giadinh;
            }

        }
    }
}
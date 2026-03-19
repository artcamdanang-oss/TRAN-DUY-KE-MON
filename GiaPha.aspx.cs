using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.IO;
using System.Configuration;

namespace SoanPha
{
    public partial class GiaPha : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        int id = 0, idoithu = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request["IDHoToc"]);
            idoithu = Module.TBT.LayDoiThu(id);
            if (!IsPostBack)
            {
                //lay ten ho toc
                rpHoToc.DataSource = db.HOTOCs.Where(p => p.IDHoToc == id).ToList();
                rpHoToc.DataBind();

                tvGiaPha.Nodes.Clear();
                var dl = db.HOSOs.Select(p=>new { p.IDHoSo,p.MaHoSo, p.IDHoToc, p.CapHoSo, p.HoTen, p.ConThu, p.GioiTinh, p.HoTenVoChong, p.DaLyDi})
                    .Where(p => (p.CapHoSo == 0 && p.IDHoToc==id)).ToList();
                dl.ForEach(p => {
                    TreeNode node = new TreeNode();
                    node.Value = p.MaHoSo;
                    node.Text = ".  " + (p.CapHoSo + idoithu) + "." + p.ConThu + ". " +  p.HoTen + ((p.HoTenVoChong!="" && p.DaLyDi==false) ? " - " + p.HoTenVoChong : "");
                    if (p.GioiTinh == false)
                        node.ImageUrl = "images/Gai.jpg";
                    else
                        node.ImageUrl = "images/Trai.jpg";
                    if (Session["type"].ToString().ToUpper().Equals("USER") == true)
                        node.NavigateUrl = "XemChiTiet.aspx?MaHoSo=" + p.MaHoSo;
                    else
                        node.NavigateUrl = "ChiTietHoSo.aspx?MaHoSo=" + p.MaHoSo;
                    node.Target = "_blank";
                    tvGiaPha.Nodes.Add(node);
                    Hienthigiapha(p.MaHoSo, node);
                    //node.Collapse();
                });
            }
        }

        public void Hienthigiapha(string mahosobome, TreeNode bome)
        {
            var dl = db.HOSOs.Select(p => new { p.IDHoSo, p.MaHoSo, p.IDHoToc, p.CapHoSo, p.HoTen, p.ConThu, p.GioiTinh, p.MaHoSoBoMe, p.HoTenVoChong, p.ThuTuVoChong, p.DaLyDi })
                .OrderBy(p => p.CapHoSo).ThenBy(p => p.ConThu).ThenBy(p => p.ThuTuVoChong)
                .Where(p => p.MaHoSoBoMe.Equals(mahosobome)).ToList();

            dl.ForEach(p => {
                TreeNode node = new TreeNode();
                node.Value = p.MaHoSo;
                node.Text = ".  " + (p.CapHoSo + idoithu) + "." + p.ConThu + ". " + p.HoTen + ((p.HoTenVoChong != "" && p.DaLyDi == false) ? " - " + p.HoTenVoChong : "");
                if (p.GioiTinh==false)
                    node.ImageUrl = "images/Gai.jpg";
                else
                    node.ImageUrl = "images/Trai.jpg";
                if (Session["type"].ToString().ToUpper().Equals("USER") == true)
                    node.NavigateUrl = "XemChiTiet.aspx?MaHoSo=" + p.MaHoSo;
                else
                    node.NavigateUrl = "ChiTietHoSo.aspx?MaHoSo=" + p.MaHoSo;
                node.Target = "_blank";
                bome.ChildNodes.Add(node);
                Hienthigiapha(p.MaHoSo, node);
            });
        }

        protected void cmdXuatGP_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string sExportToExcel = "";
            string style = "<style>.text{mso-number-format:\\@;}</style>";

            var dl = db.HOSOs.Where(p => p.IDHoToc == id).OrderBy(p => p.CapHoSo).ToList();

            if (dl.Count > 0)
            {
                sExportToExcel += "<div id='div1'>";
                sExportToExcel += "<table border='1' cellpadding='0' cellspacing='0' width='99%' align='center'>";
                sExportToExcel += "<tr>";
                sExportToExcel += "<td align='center'><b>Mã bố mẹ</b></td>";
                sExportToExcel += "<td align='center'><b>Đời thứ</b></td>";
                sExportToExcel += "<td align='center'><b>Mã hồ sơ</b></td>";
                sExportToExcel += "<td align='center'><b>Họ tên</b></td>";
                sExportToExcel += "<td align='center'><b>Tên thường gọi</b></td>";
                sExportToExcel += "<td align='center'><b>Tên hiệu</b></td>";
                sExportToExcel += "<td align='center'><b>Ngày sinh</b></td>";
                sExportToExcel += "<td align='center'><b>Con thứ</b></td>";
                sExportToExcel += "<td align='center'><b>Giới tính</b></td>";
                sExportToExcel += "<td align='center'><b>Quan hệ</b></td>";
                sExportToExcel += "<td align='center'><b></b>Số liên lạc</td>";
                sExportToExcel += "<td align='center'><b></b>Thư điện tử</td>";
                sExportToExcel += "<td align='center'><b></b>CMTND/CCCD</td>";
                sExportToExcel += "<td align='center'><b></b>Số hộ chiếu</td>";
                sExportToExcel += "<td align='center'><b></b>Nơi sinh</td>";
                sExportToExcel += "<td align='center'><b></b>Địa chỉ</td>";
                sExportToExcel += "<td align='center'><b></b>Quốc tịch</td>";
                sExportToExcel += "<td align='center'><b></b>Dân tộc</td>";
                sExportToExcel += "<td align='center'><b></b>Tôn giáo</td>";
                sExportToExcel += "<td align='center'><b></b>Ngày mất DL</td>";
                sExportToExcel += "<td align='center'><b></b>Ngày mất âm</td>";
                sExportToExcel += "<td align='center'><b></b>Nơi an táng</td>";
                sExportToExcel += "<td align='center'><b>Vợ/Chồng</b></td>";
                sExportToExcel += "<td align='center'><b>Ngày sinh</b></td>";
                sExportToExcel += "<td align='center'><b>Số liên lạc</b></td>";
                sExportToExcel += "<td align='center'><b>Thư điện tử</b></td>";
                sExportToExcel += "<td align='center'><b>Nơi sinh</b></td>";
                sExportToExcel += "<td align='center'><b>Địa chỉ</b></td>";
                sExportToExcel += "<td align='center'><b>Ngày mất DL</b></td>";
                sExportToExcel += "<td align='center'><b>Ngày mất âm</b></td>";
                sExportToExcel += "<td align='center'><b>Nơi an táng</b></td>";
                sExportToExcel += "<td align='center'><b>Thứ tự V/C</b></td>";
                sExportToExcel += "<td align='center'><b>Đã ly dị</b></td>";
                sExportToExcel += "<td align='center'><b>Học vấn</b></td>";
                sExportToExcel += "<td align='center'><b>Nghề nghiệp</b></td>";
                sExportToExcel += "<td align='center'><b>GG Nơi sinh</b></td>";
                sExportToExcel += "<td align='center'><b>GG Nơi sinh V/C</b></td>";
                sExportToExcel += "<td align='center'><b>GG Địa chỉ</b></td>";
                sExportToExcel += "<td align='center'><b>GG Địa chỉ V/C</b></td>";
                sExportToExcel += "<td align='center'><b>GG An táng</b></td>";
                sExportToExcel += "<td align='center'><b>GG An táng V/C</b></td>";
                sExportToExcel += "<td align='center'><b>Ghi chú</b></td>";
                sExportToExcel += "</tr>";

                foreach (HOSO hs in dl)
                {
                    if (hs != null)
                    {
                        sExportToExcel += "<tr>";
                        sExportToExcel += "<td>" + hs.MaHoSoBoMe + "</td>";
                        sExportToExcel += "<td>" + hs.CapHoSo + "</td>";
                        sExportToExcel += "<td>" + hs.MaHoSo + "</td>";
                        sExportToExcel += "<td>" + hs.HoTen + "</td>";
                        sExportToExcel += "<td>" + hs.TenThuongGoi + "</td>";
                        sExportToExcel += "<td>" + hs.TenHieu + "</td>";
                        sExportToExcel += "<td>" + hs.NgaySinh + "</td>";
                        sExportToExcel += "<td>" + hs.ConThu + "</td>";
                        if ((bool) hs.GioiTinh == true)
                        {
                            if (hs.GioiTinhGC!=null && hs.GioiTinhGC!="")
                                sExportToExcel += "<td>"+ hs.GioiTinhGC +"</td>";
                            else
                                sExportToExcel += "<td>Nam</td>";
                        }
                        else
                            sExportToExcel += "<td>Nữ</td>";
                        sExportToExcel += "<td>" + hs.LoaiCon + "</td>";
                        sExportToExcel += "<td>" + hs.SoLienLac + "</td>";
                        sExportToExcel += "<td>" + hs.ThuDienTu + "</td>";
                        sExportToExcel += "<td>" + hs.SoCMTND + "</td>";
                        sExportToExcel += "<td>" + hs.SoHoChieu + "</td>";
                        sExportToExcel += "<td>" + hs.NoiSinh + "</td>";
                        sExportToExcel += "<td>" + hs.DiaChi + "</td>";
                        sExportToExcel += "<td>" + hs.QuocTich + "</td>";
                        sExportToExcel += "<td>" + hs.DanToc + "</td>";
                        sExportToExcel += "<td>" + hs.TonGiao + "</td>";
                        sExportToExcel += "<td>" + hs.NgayMatDL + "</td>";
                        sExportToExcel += "<td>" + hs.NgayMatAL + "</td>";
                        sExportToExcel += "<td>" + hs.NoiAnTang + "</td>";
                        sExportToExcel += "<td>" + hs.HoTenVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.NgaySinhVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.SoLienLacVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.ThuDienTuVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.NoiSinhVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.DiaChiVochong + "</td>";
                        sExportToExcel += "<td>" + hs.NgayMatDLVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.NgayMatVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.NoiAnTangVoChong + "</td>";
                        sExportToExcel += "<td>" + hs.ThuTuVoChong + "</td>";
                        sExportToExcel += "<td>" + ((bool)hs.DaLyDi==true ? "Yes":"No") + "</td>";
                        sExportToExcel += "<td>" + hs.HocVan + "</td>";
                        sExportToExcel += "<td>" + hs.NgheNghiep + "</td>";
                        sExportToExcel += "<td>" + hs.GGNoiSinh + "</td>";
                        sExportToExcel += "<td>" + hs.GGNoiSinhVC + "</td>";
                        sExportToExcel += "<td>" + hs.GGDiaChi + "</td>";
                        sExportToExcel += "<td>" + hs.GGDiaChiVC + "</td>";
                        sExportToExcel += "<td>" + hs.GGNoiAnTang + "</td>";
                        sExportToExcel += "<td>" + hs.GGNoiAnTangVC + "</td>";
                        if (hs.MaHoSoBoMe.Equals("NULL"))
                            sExportToExcel += "<td>" + hs.GhiChu + get256char() + "</td>";
                        else
                            sExportToExcel += "<td>" + hs.GhiChu + "</td>";
                        sExportToExcel += "</tr>";
                    }
                }
                sExportToExcel += "</table></div>";

                sb.Append(sExportToExcel);
                lblExportExcel.Text = sb.ToString();
                sb.Remove(0, sb.Length);

                Response.Clear();
                Response.Charset = "";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/ms-excel.xls";
                Response.AddHeader("content-disposition", "attachment;filename=dbgiapha_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_.xls");                
                Response.ContentEncoding = Encoding.Unicode;
                Response.BinaryWrite(Encoding.Unicode.GetPreamble());

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                lblExportExcel.RenderControl(htw);
                Response.Output.Write(style + sw.ToString().Replace("td", "td class='text'"));
                Response.Flush();
                Response.End();
            }
        }

        private string get256char()
        {
            string s = "&nbsp;";
            for (int i = 0; i < 256; i++)
                s += "&nbsp;";
            return s;
        }

        protected void cmdNhapGiaPha_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);


                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, "Yes");
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [Sheet1$]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
            }

            var dl = db.HOSOs.Where(p => p.IDHoToc == id).ToList();
            db.HOSOs.DeleteAllOnSubmit(dl);
            db.SubmitChanges();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row[0].ToString() != "")
                {
                    HOSO hs = new HOSO();
                    hs.IDHoToc = id;
                    if (row[0].ToString().Contains("NULL"))
                        hs.MaHoSoBoMe = row[0].ToString();
                    else
                        hs.MaHoSoBoMe = "EX" + row[0].ToString();
                    hs.CapHoSo = Int32.Parse(row[1].ToString());
                    hs.MaHoSo = "EX" + row[2].ToString();
                    hs.HoTen = row[3].ToString();
                    hs.TenThuongGoi = row[4].ToString();
                    hs.TenHieu = row[5].ToString();
                    hs.NgaySinh = row[6].ToString();
                    hs.ConThu = Int32.Parse(row[7].ToString());
                    hs.GioiTinhGC = "";
                    string gt = row[8].ToString().ToUpper();
                    if (gt.Equals("NỮ")) {
                        hs.GioiTinh = false; }
                    else
                    {
                        hs.GioiTinh = true;
                        if (gt.Equals("NAM") == false)
                            hs.GioiTinhGC = row[8].ToString();
                    }                    
                    hs.LoaiCon = row[9].ToString();
                    hs.SoLienLac = row[10].ToString();
                    hs.ThuDienTu = row[11].ToString();
                    hs.SoCMTND = row[12].ToString();
                    hs.SoHoChieu = row[13].ToString();
                    hs.NoiSinh = row[14].ToString();
                    hs.DiaChi = row[15].ToString();
                    hs.QuocTich = row[16].ToString();
                    hs.DanToc = row[17].ToString();
                    hs.TonGiao = row[18].ToString();
                    hs.NgayMatDL = row[19].ToString();
                    hs.NgayMatAL = row[20].ToString();
                    hs.NoiAnTang = row[21].ToString();
                    hs.DaMat = (row[19].ToString() != "" || row[20].ToString() != "") ? true : false;
                    hs.HoTenVoChong = row[22].ToString();
                    hs.NgaySinhVoChong = row[23].ToString();
                    hs.SoLienLacVoChong = row[24].ToString();
                    hs.ThuDienTuVoChong = row[25].ToString();
                    hs.NoiSinhVoChong = row[26].ToString();
                    hs.DiaChiVochong = row[27].ToString();
                    hs.NgayMatDLVoChong = row[28].ToString();
                    hs.NgayMatVoChong = row[29].ToString();
                    hs.NoiAnTangVoChong = row[30].ToString();
                    hs.DaMatVC = (row[28].ToString() != "" || row[29].ToString() != "") ? true : false;
                    hs.ThuTuVoChong = Int32.Parse(row[31].ToString());
                    hs.DaLyDi = row[32].ToString().ToUpper().Equals("YES") ? true : false;
                    hs.HocVan = row[33].ToString();
                    hs.NgheNghiep = row[34].ToString();
                    hs.GGNoiSinh = row[35].ToString();
                    hs.GGNoiSinhVC = row[36].ToString();
                    hs.GGDiaChi = row[37].ToString();
                    hs.GGDiaChiVC = row[38].ToString();
                    hs.GGNoiAnTang = row[39].ToString();
                    hs.GGNoiAnTangVC = row[40].ToString();
                    hs.GhiChu = row[41].ToString().Trim();
                    db.HOSOs.InsertOnSubmit(hs);
                }
            }
            db.SubmitChanges();
            //update ma ho so
            var dl1 = db.HOSOs.Where(p => p.IDHoToc == id).OrderBy(p => p.CapHoSo).ToList();
            foreach(HOSO h in dl1)
            {
                int idHS = h.IDHoSo;
                string mahs = h.MaHoSo;
                string mahsmoi = "B" + idHS.ToString("000000000000000");
                var dl2 = db.HOSOs.Where(p => p.IDHoToc == id && p.MaHoSoBoMe.Equals(mahs)).ToList();
                foreach (HOSO hud in dl2)
                {
                    hud.MaHoSoBoMe = mahsmoi;
                    db.SubmitChanges();
                }
                h.MaHoSo = mahsmoi;
                db.SubmitChanges();
            }
            Response.Redirect("default.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class XoaHoToc : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        int idHoToc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idHoToc = Int32.Parse(Request["IDHoToc"]);
            if (!IsPostBack)
            {
                LayThongTin();
                db.Dispose();
            }
        }

        public void LayThongTin()
        {
            var dl = db.HOTOCs.Where(p => p.IDHoToc == idHoToc).ToList();
            rpHoToc.DataSource = dl;
            rpHoToc.DataBind();
        }
        protected void cmdXoa_Click(object sender, EventArgs e)
        {
            var hs = db.HOSOs.Where(p => p.IDHoToc == idHoToc).ToList();
            db.HOSOs.DeleteAllOnSubmit(hs);
            db.SubmitChanges();
            HOTOC ht = db.HOTOCs.Where(p => p.IDHoToc == idHoToc).SingleOrDefault();
            db.HOTOCs.DeleteOnSubmit(ht);
            db.SubmitChanges();
            db.Dispose();
            Response.Write("<script language='javascript'> { window.close(); }</script>");
        }
    }
}
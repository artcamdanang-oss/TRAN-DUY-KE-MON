using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoanPha
{
    public partial class index : System.Web.UI.Page
    {
        dbGiaPhaDataContext db = new dbGiaPhaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }
        }

        public void getData()
        {
            if ((Boolean)Session["Login"] == false)
            {
                var dlD = db.HOTOCs.OrderByDescending(p=>p.MaNguoiLap).ThenBy(p=>p.TenHoToc).ToList();
                lvHoTocD.DataSource = dlD;
                lvHoTocD.DataBind();
            }
            else
            {
                var dl = db.HOTOCs.OrderBy(p => p.TenHoToc).ToList();
                string sHT = Module.TBT.LayPQHoToc((string)Session["uname"]);
                if (sHT.Equals("") == false)
                {
                    List<string> pq = sHT.Split(',').ToList();
                    dl = db.HOTOCs.Where(p => pq.Contains(p.MaHoToc)).OrderBy(p => p.TenHoToc).ToList();
                }

                if (Session["type"].ToString().ToUpper().Equals("USER"))
                {
                    lvHoTocV.DataSource = dl;
                    lvHoTocV.DataBind();
                }
                else
                {
                    lvHoToc.DataSource = dl;
                    lvHoToc.DataBind();
                }
            }
            db.Dispose();
        }

        protected void lvHoTocD_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            rpD.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            getData();
        }

        protected void lvHoToc_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            rpHT.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            getData();
        }

        protected void lvHoTocV_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            rpV.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            getData();
        }
    }
}
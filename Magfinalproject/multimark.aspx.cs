using Magfinalproject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Magfinalproject
{
    [Authorize]
    public partial class multimark : System.Web.UI.Page
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                var d = db.departments.ToList();
                DropDownList1.DataSource = db.acadyears.ToList(); ;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                DropDownList2.DataSource = d;

                DropDownList2.DataTextField = "name";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();
               
            }
        }
        private void import(string filepath, string ext)
        {
            string constr = "";
            try
            {
                switch (ext)
                {
                    case ".xls":
                        constr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx":
                        constr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;

                }
          
            constr = string.Format(constr, filepath, 1);
            OleDbConnection conxl = new OleDbConnection(constr);
            OleDbCommand cmdex = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdex.Connection = conxl;
            conxl.Open();
            DataTable dtex;
            dtex = conxl.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string cht = dtex.Rows[0]["TABLE_NAME"].ToString();
            conxl.Close();
            conxl.Open();
            cmdex.CommandText = "SELECT * From[" + cht + "]";
            oda.SelectCommand = cmdex;
            oda.Fill(dt);
            conxl.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;

            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)

            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string folder = ConfigurationManager.AppSettings["folder"];
                string filepath = Server.MapPath(folder + filename);
                FileUpload1.SaveAs(filepath);
                import(filepath, ext);

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string d = DropDownList2.SelectedItem.Value;
            int s = Convert.ToInt32(d);
            string dd = DropDownList1.SelectedItem.Value;
            int ss = Convert.ToInt32(d);
            DropDownList3.DataSource = db.subjects.Where(a=>a.departmentid==s&&a.acadyearid==ss).ToList(); ;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "name";
            DropDownList3.DataValueField = "id";
            DropDownList3.DataBind();
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = GridView1.Rows.Count.ToString();
        }

        protected void DropDownList2_TextChanged(object sender, EventArgs e)
        {
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int deid = Convert.ToInt32(DropDownList2.SelectedItem.Value.ToString());
            int year = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
            int su = Convert.ToInt32(DropDownList3.SelectedItem.Value.ToString());
            mark mark = new mark();
            Label2.Text = "";
            for (int i = 0; i < GridView1.Rows.Count ; i++)
            {

                double se = Convert.ToDouble(GridView1.Rows[i].Cells[2].Text.ToString());
                double ex = Convert.ToDouble(GridView1.Rows[i].Cells[3].Text.ToString());
                string stid = GridView1.Rows[i].Cells[1].Text;
                var ss = db.students.Where(a => a.stuid == stid.ToString()); 
                if(ss.Count()==0)
                {
                    Label2.Text += " الطالب  "+ GridView1.Rows[i].Cells[0].Text.ToString()+"  غير موجود ,,,, ";
                    continue;
                }
                var s = db.students.Where(a => a.stuid == stid.ToString()).FirstOrDefault();
                mark.departmentid = deid;
                mark.acadyearid = year;
                mark.subjectid = su;
                mark.studentid = s.id;
                mark.sess = se;
                mark.exam = ex;
                mark.date = DateTime.Now;
                mark.grade = GridView1.Rows[i].Cells[4].Text;
                mark.note = GridView1.Rows[i].Cells[5].Text;
                db.marks.Add(mark);
                db.SaveChanges();
                Label1.Text = "added";
            }

        
            }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string d = DropDownList2.SelectedItem.Value;
            int s = Convert.ToInt32(d);
            string dd = DropDownList1.SelectedItem.Value;
            int ss = Convert.ToInt32(d);
            DropDownList3.DataSource = db.subjects.Where(a => a.departmentid == s && a.acadyearid == ss).ToList(); ;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "name";
            DropDownList3.DataValueField = "id";
            DropDownList3.DataBind();
        }
    }
    }

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HERBONA
{
    public partial class MemberTreeView : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds;
        string L = "0", R = "";

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["con"]);
        SqlCommand cmd;
        SqlDataReader dr;
        string jointype, reduserid, redside;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                detail("9999");
                Lb1.Text = "9999";

            }

        }
        protected void Lb1_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            string val = btn.Text;
            detail(btn.Text);
        }

        public void check()
        {

            Lb2L.Text = "Blank";
            Lb3R.Text = "Blank";
            Lb4L.Text = "Blank";
            Lb5R.Text = "Blank";
            Lb6L.Text = "Blank";
            Lb7R.Text = "Blank";
            Lb8L.Text = "Blank";
            Lb9R.Text = "Blank";
            Lb10L.Text = "Blank";
            Lb11R.Text = "Blank";
            Lb12L.Text = "Blank";
            Lb13R.Text = "Blank";
            Lb14L.Text = "Blank";
            Lb15R.Text = "Blank";

            Lb2L.ToolTip = "STP";
            Lb3R.ToolTip = "STP";
            Lb4L.ToolTip = "STP";
            Lb5R.ToolTip = "STP";
            Lb6L.ToolTip = "STP";
            Lb7R.ToolTip = "STP";
            Lb8L.ToolTip = "STP";
            Lb9R.ToolTip = "STP";
            Lb10L.ToolTip = "STP";
            Lb11R.ToolTip = "STP";
            Lb12L.ToolTip = "STP";
            Lb13R.ToolTip = "STP";
            Lb14L.ToolTip = "STP";
            Lb15R.ToolTip = "STP";


            i2.Src = "../TreeImages/R.jpg";
            i3.Src = "../TreeImages/R.jpg";
            i4.Src = "../TreeImages/R.jpg";
            i5.Src = "../TreeImages/R.jpg";
            i6.Src = "../TreeImages/R.jpg";
            i7.Src = "../TreeImages/R.jpg";
            i8.Src = "../TreeImages/R.jpg";
            i9.Src = "../TreeImages/R.jpg";
            i10.Src = "../TreeImages/R.jpg";
            i11.Src = "../TreeImages/R.jpg";
            i12.Src = "../TreeImages/R.jpg";
            i13.Src = "../TreeImages/R.jpg";
            i14.Src = "../TreeImages/R.jpg";
            i15.Src = "../TreeImages/R.jpg";
        }

        public void detail(string usr)
        {
            try
            {
                con.Open();
                Lb1.Text = usr.ToString();
                //LBL_Name.Text = usr.ToString();
                string sql0 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + Lb1.Text;
                da = new SqlDataAdapter(sql0, con);
                ds = new DataSet();
                da.Fill(ds, "TBL_RELATIONMASTER");
                if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                {
                    jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                }
                if (jointype == "2")
                {
                    i1.Src = "../TreeImages/G.jpg";
                }
                else if (jointype == "1")
                {
                    i1.Src = "../TreeImages/1.jpg";
                }
                else
                {
                    i1.Src = "../TreeImages/0.jpg";
                }
                string sql00 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + Lb1.Text;
                da = new SqlDataAdapter(sql00, con);
                ds = new DataSet();
                da.Fill(ds, "TBL_ASSOCIATEMASTER");
                if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                {
                    Lb1.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                    LBL_Name.Text = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                }
                TreeShow ss = new TreeShow();
                check();
                ss.find(Lb1.Text, out L, out R);
                string l2 = L.ToString();
                string r3 = R.ToString();
                if (l2 != "")
                {
                    Lb2L.Visible = true;
                    Lb2L.Text = l2;




                    string sql1 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l2;
                    da = new SqlDataAdapter(sql1, con);
                    ds = new DataSet();
                    da.Fill(ds, "TBL_RELATIONMASTER");
                    if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                    {
                        jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                    }
                    if (jointype == "2")
                    {
                        i2.Src = "../TreeImages/G.jpg";
                    }
                    else if (jointype == "1")
                    {
                        i2.Src = "../TreeImages/1.jpg";
                    }
                    else
                    {
                        i2.Src = "../TreeImages/0.jpg";
                    }
                    string sql22 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l2;
                    da = new SqlDataAdapter(sql22, con);
                    ds = new DataSet();
                    da.Fill(ds, "TBL_ASSOCIATEMASTER");
                    if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                    {
                        Lb2L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                    }

                    ss.find(l2, out L, out R);
                    string l4 = L.ToString();
                    string r5 = R.ToString();

                    if (l4 != "")
                    {
                        Lb4L.Visible = true;
                        Lb4L.Text = l4;
                        string sql4 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l4;
                        da = new SqlDataAdapter(sql4, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_RELATIONMASTER");
                        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                        {
                            jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                        }
                        if (jointype == "2")
                        {
                            i4.Src = "../TreeImages/G.jpg";
                        }
                        else if (jointype == "1")
                        {
                            i4.Src = "../TreeImages/1.jpg";
                        }
                        else
                        {
                            i4.Src = "../TreeImages/0.jpg";
                        }
                        string sql23 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l4;
                        da = new SqlDataAdapter(sql23, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_ASSOCIATEMASTER");
                        if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                        {
                            Lb4L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                        }
                        ss.find(l4, out L, out R);
                        string l8 = L.ToString();
                        string r9 = R.ToString();

                        if (l8 != "")
                        {
                            Lb8L.Visible = true;
                            Lb8L.Text = l8;
                            string sql8 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l8;
                            da = new SqlDataAdapter(sql8, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i8.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i8.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i8.Src = "../TreeImages/0.jpg";
                            }
                            string sql24 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l8;
                            da = new SqlDataAdapter(sql24, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb8L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                        if (r9 != "")
                        {
                            Lb9R.Visible = true;
                            Lb9R.Text = r9;
                            string sql9 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r9;
                            da = new SqlDataAdapter(sql9, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i9.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i9.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i9.Src = "../TreeImages/0.jpg";
                            }
                            string sql25 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r9;
                            da = new SqlDataAdapter(sql25, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb9R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }


                        }
                    }
                    if (r5 != "")
                    {
                        Lb5R.Visible = true;
                        Lb5R.Text = r5;
                        string sql5 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r5;
                        da = new SqlDataAdapter(sql5, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_RELATIONMASTER");
                        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                        {
                            jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                        }
                        if (jointype == "2")
                        {
                            i5.Src = "../TreeImages/G.jpg";
                        }
                        else if (jointype == "1")
                        {
                            i5.Src = "../TreeImages/1.jpg";
                        }
                        else
                        {
                            i5.Src = "../TreeImages/0.jpg";
                        }
                        string sql26 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r5;
                        da = new SqlDataAdapter(sql26, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_ASSOCIATEMASTER");
                        if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                        {
                            Lb5R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                        }
                        ss.find(r5, out L, out R);
                        string l10 = L.ToString();
                        string r11 = R.ToString();

                        if (l10 != "")
                        {
                            Lb10L.Visible = true;
                            Lb10L.Text = l10;
                            string sql10 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l10;
                            da = new SqlDataAdapter(sql10, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i10.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i10.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i10.Src = "../TreeImages/0.jpg";
                            }
                            string sql27 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l10;
                            da = new SqlDataAdapter(sql27, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb10L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }


                        }
                        if (r11 != "")
                        {
                            Lb11R.Visible = true;
                            Lb11R.Text = r11;
                            string sql11 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r11;
                            da = new SqlDataAdapter(sql11, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i11.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i11.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i11.Src = "../TreeImages/0.jpg";
                            }
                            string sql28 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r11;
                            da = new SqlDataAdapter(sql28, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb11R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                    }
                }
                if (r3 != "")
                {
                    Lb3R.Visible = true;
                    Lb3R.Text = r3;


                    string sql3 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r3;
                    da = new SqlDataAdapter(sql3, con);
                    ds = new DataSet();
                    da.Fill(ds, "TBL_RELATIONMASTER");
                    if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                    {
                        jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                    }
                    if (jointype == "2")
                    {
                        i3.Src = "../TreeImages/G.jpg";
                    }
                    else if (jointype == "1")
                    {
                        i3.Src = "../TreeImages/1.jpg";
                    }
                    else
                    {
                        i3.Src = "../TreeImages/0.jpg";
                    }
                    string sql29 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r3;
                    da = new SqlDataAdapter(sql29, con);
                    ds = new DataSet();
                    da.Fill(ds, "TBL_ASSOCIATEMASTER");
                    if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                    {
                        Lb3R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                    }


                    ss.find(r3, out L, out R);
                    string l6 = L.ToString();
                    string r7 = R.ToString();
                    if (l6 != "")
                    {
                        Lb6L.Visible = true;
                        Lb6L.Text = l6;
                        string sql6 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l6;
                        da = new SqlDataAdapter(sql6, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_RELATIONMASTER");
                        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                        {
                            jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                        }
                        if (jointype == "2")
                        {
                            i6.Src = "../TreeImages/G.jpg";
                        }
                        else if (jointype == "1")
                        {
                            i6.Src = "../TreeImages/1.jpg";
                        }
                        else
                        {
                            i6.Src = "../TreeImages/0.jpg";
                        }
                        string sql30 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l6;
                        da = new SqlDataAdapter(sql30, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_ASSOCIATEMASTER");
                        if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                        {
                            Lb6L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                        }



                        ss.find(l6, out L, out R);
                        string l12 = L.ToString();
                        string r13 = R.ToString();
                        if (l12 != "")
                        {
                            Lb12L.Visible = true;
                            Lb12L.Text = l12;
                            string sql12 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l12;
                            da = new SqlDataAdapter(sql12, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i12.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i12.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i12.Src = "../TreeImages/0.jpg";
                            }
                            string sql31 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l12;
                            da = new SqlDataAdapter(sql31, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb12L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                        if (r13 != "")
                        {
                            Lb13R.Visible = true;
                            Lb13R.Text = r13;
                            string sql13 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r13;
                            da = new SqlDataAdapter(sql13, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i13.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i13.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i13.Src = "../TreeImages/0.jpg";
                            }
                            string sql32 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r13;
                            da = new SqlDataAdapter(sql32, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb13R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                    }
                    if (r7 != "")
                    {
                        Lb7R.Visible = true;
                        Lb7R.Text = r7;
                        string sql7 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r7;
                        da = new SqlDataAdapter(sql7, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_RELATIONMASTER");
                        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                        {
                            jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                        }
                        if (jointype == "2")
                        {
                            i7.Src = "../TreeImages/G.jpg";
                        }
                        else if (jointype == "1")
                        {
                            i7.Src = "../TreeImages/1.jpg";
                        }
                        else
                        {
                            i7.Src = "../TreeImages/0.jpg";
                        }
                        string sql33 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r7;
                        da = new SqlDataAdapter(sql33, con);
                        ds = new DataSet();
                        da.Fill(ds, "TBL_ASSOCIATEMASTER");
                        if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                        {
                            Lb7R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                        }


                        ss.find(r7, out L, out R);
                        string l14 = L.ToString();
                        string r15 = R.ToString();
                        if (l14 != "")
                        {
                            Lb14L.Visible = true;
                            Lb14L.Text = l14;
                            string sql14 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + l14;
                            da = new SqlDataAdapter(sql14, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i14.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i14.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i14.Src = "../TreeImages/0.jpg";
                            }
                            string sql34 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + l14;
                            da = new SqlDataAdapter(sql34, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb14L.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                        if (r15 != "")
                        {
                            Lb15R.Visible = true;
                            Lb15R.Text = r15;
                            string sql15 = "select count(*) from TBL_RELATIONMASTER where REFERENCE_ID=" + r15;
                            da = new SqlDataAdapter(sql15, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_RELATIONMASTER");
                            if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
                            {
                                jointype = ds.Tables["TBL_RELATIONMASTER"].Rows[0][0].ToString();
                            }
                            if (jointype == "2")
                            {
                                i15.Src = "../TreeImages/G.jpg";
                            }
                            else if (jointype == "1")
                            {
                                i15.Src = "../TreeImages/1.jpg";
                            }
                            else
                            {
                                i15.Src = "../TreeImages/0.jpg";
                            }
                            string sql35 = "select NAME from TBL_ASSOCIATEMASTER where ASSID=" + r15;
                            da = new SqlDataAdapter(sql35, con);
                            ds = new DataSet();
                            da.Fill(ds, "TBL_ASSOCIATEMASTER");
                            if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
                            {
                                Lb15R.ToolTip = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0][0].ToString();
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (Lb2L.Text == "Blank" || Lb3R.Text == "Blank")
            {
                LBL_PAIR.Text = "0";
            }

            else
            {
                LBL_PAIR.Text = "1";
            }
            string s = ConfigurationSettings.AppSettings["con"];
            con = new SqlConnection(s);
            con.Open();

            string s1 = ConfigurationSettings.AppSettings["con"];
            con = new SqlConnection(s1);
            string sql2 = "select ASSID,PAIR,LEFT_CHILD,RIGHT_CHILD from TBL_PAIRMASTER where ASSID='" + Lb1.Text.Trim() + "'";
            da = new SqlDataAdapter(sql2, con);
            ds = new DataSet();
            da.Fill(ds, "TBL_PAIRMASTER");
            con.Close();
            if (ds.Tables["TBL_PAIRMASTER"].Rows.Count > 0)
            {
                LBL_LEFT.Text = ds.Tables["TBL_PAIRMASTER"].Rows[0]["LEFT_CHILD"].ToString();
                LBL_RIGHT.Text = ds.Tables["TBL_PAIRMASTER"].Rows[0]["RIGHT_CHILD"].ToString();
                LBL_PAIR.Text = ds.Tables["TBL_PAIRMASTER"].Rows[0]["PAIR"].ToString();
            }

        }

        protected void ImgBack_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void Lb2L_Click(object sender, EventArgs e)
        {
            if (Lb2L.Text == "Blank")
            {

                if (Lb1.Text != "Blank")
                {

                    reduserid = Lb1.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }

            }
            else
            {
                detail(Lb2L.Text);
            }
        }
        protected void Lb3R_Click(object sender, EventArgs e)
        {
            if (Lb3R.Text == "Blank")
            {
                if (Lb1.Text != "Blank")
                {
                    reduserid = Lb1.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb3R.Text);
            }
        }
        protected void Lb4L_Click(object sender, EventArgs e)
        {
            if (Lb4L.Text == "Blank")
            {
                if (Lb2L.Text != "Blank")
                {
                    reduserid = Lb2L.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }

            }
            else
            {
                detail(Lb4L.Text);
            }
        }
        protected void Lb5R_Click(object sender, EventArgs e)
        {
            if (Lb5R.Text == "Blank")
            {
                if (Lb2L.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb5R.Text);
            }
        }
        protected void Lb6L_Click(object sender, EventArgs e)
        {
            if (Lb6L.Text == "Blank")
            {
                if (Lb3R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb6L.Text);
            }
        }
        protected void Lb7R_Click(object sender, EventArgs e)
        {
            if (Lb7R.Text == "Blank")
            {
                if (Lb3R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb7R.Text);
            }
        }
        protected void Lb8L_Click(object sender, EventArgs e)
        {
            if (Lb8L.Text == "Blank")
            {
                if (Lb4L.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb8L.Text);
            }
        }
        protected void Lb9R_Click(object sender, EventArgs e)
        {
            if (Lb9R.Text == "Blank")
            {
                if (Lb4L.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb9R.Text);
            }
        }
        protected void Lb10L_Click(object sender, EventArgs e)
        {
            if (Lb10L.Text == "Blank")
            {
                if (Lb5R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb10L.Text);
            }
        }
        protected void Lb11R_Click(object sender, EventArgs e)
        {
            if (Lb11R.Text == "Blank")
            {
                if (Lb5R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {

                detail(Lb11R.Text);
            }
        }
        protected void Lb12L_Click(object sender, EventArgs e)
        {
            if (Lb12L.Text == "Blank")
            {
                if (Lb6L.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb12L.Text);
            }
        }
        protected void Lb13R_Click(object sender, EventArgs e)
        {
            if (Lb13R.Text == "Blank")
            {
                if (Lb6L.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {

                detail(Lb13R.Text);
            }
        }
        protected void Lb14L_Click(object sender, EventArgs e)
        {
            if (Lb14L.Text == "Blank")
            {
                if (Lb7R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {

                detail(Lb14L.Text);
            }
        }
        protected void Lb15R_Click(object sender, EventArgs e)
        {
            if (Lb15R.Text == "Blank")
            {
                if (Lb7R.Text != "Blank")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                detail(Lb15R.Text);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            detail("" + TextBox1.Text.Trim() + "");
            Lb1.Text = "" + TextBox1.Text.Trim() + "";
        }
    }
}

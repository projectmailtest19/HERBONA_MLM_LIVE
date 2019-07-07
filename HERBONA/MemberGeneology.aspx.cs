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
    public partial class MemberGeneology : System.Web.UI.Page
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                tvwItems.Nodes.Clear();
                //BindRoots(3);
                BindRoots(Convert.ToInt32(HttpContext.Current.Session["Login_user_ID"].ToString()));


                string s = ConfigurationSettings.AppSettings["truckingCon"];
                con = new SqlConnection(s);


                //string sql1 = "select ID,NAME from CONTACT";
                //da = new SqlDataAdapter(sql1, con);
                //ds = new DataSet();
                //da.Fill(ds, "CONTACT");
                //con.Close();

                //ddlassid.DataSource = ds.Tables["CONTACT"];
                //ddlassid.DataTextField = "ID";
                //ddlassid.DataBind();

                //ddlname.DataSource = ds.Tables["CONTACT"];
                //ddlname.DataTextField = "NAME";
                //ddlname.DataBind();
            }
        }
        private void BindRoots(int assid)
        {
            try
            {

                string str = "SELECT [Placed_MemberID],c.NAME FROM CONTACT as c left join Agent_Sponsor_Details as a on c.id = a.Contact_id  where c.ID=" + assid;
                SqlDataReader reader = GetData(str);
                while (reader.Read())
                {
                    string p = reader[0].ToString();
                    string p1 = reader[1].ToString();
                    string p2 = p1 + "(" + p + ")";
                    TreeNode rootNode = new TreeNode(p2.ToString(), reader[0].ToString());

                    tvwItems.Nodes.Add(rootNode);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void BindChilds(TreeNode node, string parentNodeID)
        {

            string str = "SELECT r.[Placed_MemberID],a.NAME,r.Placed_Team FROM CONTACT AS a inner join Agent_Sponsor_Details AS r on a.ID=r.Contact_id " +
                " inner join Agent_Sponsor_Details as s on r.Sponsor_ID = s.Contact_id where s.[Placed_MemberID]='" + parentNodeID + "'";
            SqlDataReader reader = GetData(str);
            int i = 0;
            while (reader.Read())
            {

                string p = reader[0].ToString();
                string p1 = reader[1].ToString();
                string p2 = reader[2].ToString();
                string p3 = p1 + "(" + p + ")(" + p2 + ")";



                TreeNode childNode = new TreeNode(p3.ToString(), reader[0].ToString());
                node.ChildNodes.Add(childNode);
            }
            reader.Close();
        }

        protected void tvwItems_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (!(tvwItems.SelectedNode.ChildNodes.Count > 0))
            {
                BindChilds(tvwItems.SelectedNode, Convert.ToString(tvwItems.SelectedNode.Value));
                tvwItems.SelectedNode.Expand();
            }
        }

        private SqlDataReader GetData(string commandText)
        {
            string s = ConfigurationSettings.AppSettings["truckingCon"];
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(commandText, con);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            return dr;
        }
        //protected void ddlassid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txt_associateid.Text = ddlassid.SelectedValue.ToString();
        //    DataTable table = new DataTable();
        //    string s = ConfigurationSettings.AppSettings["truckingCon"];
        //    con = new SqlConnection(s);
        //    if (ddlassid.SelectedItem.Text == "All")
        //    {
        //        //session login ID
        //        tvwItems.Nodes.Clear();
        //        BindRoots(3);

        //    }
        //    else
        //    {
        //        int i = Int32.Parse(ddlassid.SelectedItem.Text);
        //        tvwItems.Nodes.Clear();
        //        BindRoots(i);

        //    }

        //}
        //protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable table = new DataTable();
        //    string s = ConfigurationSettings.AppSettings["truckingCon"];
        //    con = new SqlConnection(s);
        //    if (ddlname.SelectedItem.Text == "All")
        //    {
        //        //session login ID
        //        tvwItems.Nodes.Clear();
        //        BindRoots(3);
        //    }
        //    else
        //    {
        //        string sql = "SELECT ID FROM CONTACT where NAME='" + ddlname.SelectedItem + "'";
        //        ds = new DataSet();
        //        da = new SqlDataAdapter(sql, con);
        //        da.Fill(ds, "CONTACT");
        //        int i = Int32.Parse(ds.Tables["CONTACT"].Rows[0]["ID"].ToString());
        //        tvwItems.Nodes.Clear();
        //        BindRoots(i);


        //    }
        //}
        //protected void txt_associateid_TextChanged(object sender, EventArgs e)
        //{
        //    ddlassid.SelectedValue = txt_associateid.Text.Trim();
        //    ddlassid_SelectedIndexChanged(this.ddlassid, e);

        //}
    }
}
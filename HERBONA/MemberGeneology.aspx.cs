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
            tvwItems.Nodes.Clear();
            BindRoots(9999);


            string s = ConfigurationSettings.AppSettings["con"];
            con = new SqlConnection(s);


            string sql1 = "select ASSID,NAME from TBL_ASSOCIATEMASTER";
            da = new SqlDataAdapter(sql1, con);
            ds = new DataSet();
            da.Fill(ds, "TBL_ASSOCIATEMASTER");
            con.Close();
            if (Page.IsPostBack != true)
            {
                ddlassid.DataSource = ds.Tables["TBL_ASSOCIATEMASTER"];
                ddlassid.DataTextField = "ASSID";
                ddlassid.DataBind();

                ddlname.DataSource = ds.Tables["TBL_ASSOCIATEMASTER"];
                ddlname.DataTextField = "NAME";
                ddlname.DataBind();
            }
        }
        private void BindRoots(int assid)
        {
            try
            {

                string str = "SELECT r.ASSID,a.NAME FROM TBL_ASSOCIATEMASTER AS a inner join TBL_RELATIONMASTER AS r on a.ASSID=r.ASSID where r.ASSID=" + assid;
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

            string str = "SELECT r.ASSID,a.NAME,r.SIDE FROM TBL_ASSOCIATEMASTER AS a inner join TBL_RELATIONMASTER AS r on a.ASSID=r.ASSID where r.REFERENCE_ID=" + parentNodeID;
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
            string s = ConfigurationSettings.AppSettings["con"];
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(commandText, con);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            return dr;
        }
        protected void ddlassid_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_associateid.Text = ddlassid.SelectedValue.ToString();
            DataTable table = new DataTable();
            string s = ConfigurationSettings.AppSettings["con"];
            con = new SqlConnection(s);
            if (ddlassid.SelectedItem.Text == "All")
            {
                //session login ID
                tvwItems.Nodes.Clear();
                BindRoots(9999);

            }
            else
            {
                int i = Int32.Parse(ddlassid.SelectedItem.Text);
                tvwItems.Nodes.Clear();
                BindRoots(i);

            }

        }
        protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string s = ConfigurationSettings.AppSettings["con"];
            con = new SqlConnection(s);
            if (ddlname.SelectedItem.Text == "All")
            {
                //session login ID
                tvwItems.Nodes.Clear();
                BindRoots(9999);
            }
            else
            {
                string sql = "SELECT ASSID FROM TBL_ASSOCIATEMASTER where NAME='" + ddlname.SelectedItem + "'";
                ds = new DataSet();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "TBL_ASSOCIATEMASTER");
                int i = Int32.Parse(ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0]["ASSID"].ToString());
                tvwItems.Nodes.Clear();
                BindRoots(i);


            }
        }
        protected void txt_associateid_TextChanged(object sender, EventArgs e)
        {
            ddlassid.SelectedValue = txt_associateid.Text.Trim();
            ddlassid_SelectedIndexChanged(this.ddlassid, e);

        }
    }
}
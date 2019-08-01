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
                
            }
        }
        private void BindRoots(int assid)
        {
            try
            {

                string str = "SELECT [MemberID],c.NAME FROM CONTACT as c left join Agent_Sponsor_Details as a on c.id = a.Contact_id  where c.ID=" + assid;
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

            string str = "SELECT r.[MemberID],a.NAME,r.Placed_Team FROM CONTACT AS a inner join Agent_Sponsor_Details AS r on a.ID=r.Contact_id " +
                " inner join Agent_Sponsor_Details as s on r.Placed_Contact_Id = s.Contact_id where s.[MemberID]='" + parentNodeID + "'";
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class TreeShow
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;   
    string sql;

    int status;
	public TreeShow()
	{      
        string s = ConfigurationSettings.AppSettings["truckingCon"];
        con = new SqlConnection(s);
	}
    string msg;

    public void find(string apid, out string Left, out string Right)
    {
        Left = "";
        Right = "";     
        con.Open();
        string sql = "select Contact_id from Agent_Sponsor_Details where Sponsor_ID=" + apid + " and Placed_Team='L'";
        da = new SqlDataAdapter(sql, con);
        ds = new DataSet();
        da.Fill(ds, "Agent_Sponsor_Details");        
        if (ds.Tables["Agent_Sponsor_Details"].Rows.Count > 0)
        {
            Left = ds.Tables["Agent_Sponsor_Details"].Rows[0]["Contact_id"].ToString();
        }
        
        string sql1 = "select Contact_id from Agent_Sponsor_Details where Sponsor_ID=" + apid + " and Placed_Team='R'";
        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds, "Agent_Sponsor_Details");
        con.Close();
        if (ds.Tables["Agent_Sponsor_Details"].Rows.Count > 0)
        {
            Right = ds.Tables["Agent_Sponsor_Details"].Rows[0]["Contact_id"].ToString();
        }        

        con.Close();
    }

    public DataTable fillUserDetail(string apid)
    {
        DataTable ufill = new DataTable();
        da = new SqlDataAdapter("select * from Agent_Sponsor_Details where Contact_id=" + apid, con);
        da.Fill(ufill);
        return ufill;

    }
}
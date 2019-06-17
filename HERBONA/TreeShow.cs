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
        string s = ConfigurationSettings.AppSettings["con"];
        con = new SqlConnection(s);
	}
    string msg;

    public void find(string apid, out string Left, out string Right)
    {
        Left = "";
        Right = "";     
        con.Open();
        string sql = "select ASSID from TBL_RELATIONMASTER where REFERENCE_ID=" + apid + " and SIDE='L'";
        da = new SqlDataAdapter(sql, con);
        ds = new DataSet();
        da.Fill(ds, "TBL_RELATIONMASTER");        
        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
        {
            Left = ds.Tables["TBL_RELATIONMASTER"].Rows[0]["ASSID"].ToString();
        }
        
        string sql1 = "select ASSID from TBL_RELATIONMASTER where REFERENCE_ID=" + apid + " and SIDE='R'";
        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds, "TBL_RELATIONMASTER");
        con.Close();
        if (ds.Tables["TBL_RELATIONMASTER"].Rows.Count > 0)
        {
            Right = ds.Tables["TBL_RELATIONMASTER"].Rows[0]["ASSID"].ToString();
        }        

        con.Close();
    }

    public DataTable fillUserDetail(string apid)
    {
        DataTable ufill = new DataTable();
        da = new SqlDataAdapter("select * from TBL_RELATIONMASTER where ASSID=" + apid, con);
        da.Fill(ufill);
        return ufill;

    }
}
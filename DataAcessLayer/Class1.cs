using System;
using System.Configuration;
using System.Data;



namespace DataAcessLayer
{
    public class Class1
    {
        public DataSet GetStates()
        { 
        string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        System.Data.SqlConnection con = new SqlConnection(maincon);

        string sqlquery = "select * from STATE";
        SqlCommand com = new SqlCommand(sqlquery, con);
        SqlDataAdapter da = new SqlDataAdapter(com);

        con.Open();

            DataSet ds = new DataSet();
        da.Fill(ds);
        }

    }
}

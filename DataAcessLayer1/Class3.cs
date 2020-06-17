using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAcessLayer1
{
    public class Class3
    {
        public static string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(maincon);
        private DataSet myds;
        private int rc;
        public int customer_id;

        public int GetCustomerPK(long phone)
        {
            SqlCommand command = new SqlCommand("spGETPKCUSTOMER", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@phone_number", phone);

            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myds = new DataSet();
            myadapter.Fill(myds, "CUSTOMER");
            rc = myds.Tables["CUSTOMER"].Rows.Count;
            if (rc > 0)
            {
                this.customer_id = Convert.ToInt32(myds.Tables["CUSTOMER"].Rows[0][0]);

            }
            
            return customer_id;
        }

        public void AddPolicyDetails(int customer_id,
            int cover_amount,
            string payout_option,
            int policy_term,
           int payment_term,
            string plan_type,
          string  add_on)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT into POLICY_DETAILS (customer_id,cover_amount,payout_option,policy_term,payment_term,plan_type,add_on,policy_start_date,policy_active_flag,policy_applied) values (@customer_id,@cover_amount,@payout_option,@policy_term,@payment_term,@plan_type,@add_on,@policy_start_date,@policy_active_flag,@policy_applied)", con);
            con.Open();

            sqlCmd.Parameters.AddWithValue("@customer_id", customer_id);

            sqlCmd.Parameters.AddWithValue("@cover_amount", cover_amount);
            sqlCmd.Parameters.AddWithValue("@payout_option", payout_option);
            sqlCmd.Parameters.AddWithValue("@policy_term", policy_term);
            sqlCmd.Parameters.AddWithValue("@payment_term", payment_term);
            sqlCmd.Parameters.AddWithValue("@plan_type", plan_type);
            sqlCmd.Parameters.AddWithValue("@add_on", add_on);
            sqlCmd.Parameters.AddWithValue("@policy_start_date", DateTime.Now);
            //sqlCmd.Parameters.AddWithValue("@policy_end_date", );
            sqlCmd.Parameters.AddWithValue("@policy_active_flag", 0);
            sqlCmd.Parameters.AddWithValue("@policy_applied", DateTime.Now);


            SqlDataReader sdr = sqlCmd.ExecuteReader();
            con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DataAcessLayer1;

namespace WebApplication1.Controllers
{
    public class PolicyController : Controller
    {
        public int customer_id ;
        public Class3 policy = new Class3();
       
        [HttpGet]
        // GET: Policy
        public ActionResult Index()
        {
            Response.Write("Customer_id=   " + policy.customer_id);

            return View();
        }

        [HttpGet]
        public ActionResult Details(Policy cusObj)
        {
            string con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select cover_amount,payout_option,policy_term,payment_term,plan_type,add_on from POLICY_DETAILS where policy_id=(Select max (policy_id) From POLICY_DETAILS)", sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
                cusObj.cover_amount = Convert.ToInt32(sdr["cover_amount"]);
                cusObj.payout_option = sdr["payout_option"].ToString();
                cusObj.policy_term = Convert.ToInt32(sdr["policy_term"]);
                cusObj.payment_term = Convert.ToInt32(sdr["payment_term"]);
                cusObj.plan_type = sdr["plan_type"].ToString();
                cusObj.add_on = sdr["add_on"].ToString();

            }
            else
            {
                ViewData["Message"] = "User Login Failed";
            }
            sqlCon.Close();




            return View(cusObj);
        }

        [HttpPost]
        public ActionResult Details()
        {
            return RedirectToRoute(new
            {
                controller = "Payment",
                action = "Index"

            });
        }

        [HttpPost]
        public ActionResult Index(Policy cusObj)
        {
            Response.Write("Phone NUmber = " + TempData["Phone_Number"]);
            long Phone = (long)Convert.ToDouble(TempData["Phone_Number"]);

            customer_id = policy.GetCustomerPK(Phone);

            Response.Write("Customer_id=   " + policy.customer_id);

            if (cusObj.add_on == "")
            {
                cusObj.add_on = "null";
            }

            string add_on = cusObj.add_on.ToString();
            

            policy.AddPolicyDetails(customer_id,
                cusObj.cover_amount,
                cusObj.payout_option,
                cusObj.policy_term,
                 cusObj.payment_term,
                cusObj.plan_type,
                add_on);


            return RedirectToRoute(new
            {
                controller = "Policy",
                action = "Details"

            });

        }
    }



}
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

            
            return View();

        }
    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Policy
    {
        public int cover_amount { get; set; }

        public string payout_option { get; set; }

        public int policy_term { get; set; }

        public int payment_term { get; set; }

        public string plan_type { get; set; }

        public string add_on { get; set; }

        public string policy_start_date { get; set; }

        public string policy_end_date { get; set; }

        public bool policy_active_flag { get; set; }

        public string policy_applied { get; set; }
    }
}
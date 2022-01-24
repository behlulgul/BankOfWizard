using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfWizard.Identity.Model
{
    public class TokenViewModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string auth_token { get; set; }
        public int expires_in { get; set; }
    }
}

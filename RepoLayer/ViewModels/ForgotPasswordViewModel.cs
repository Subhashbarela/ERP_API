using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.ViewModels
{
    public class ForgotPasswordViewModel
    {
        public int UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.ViewModels
{
    public class EmailSendingViewModel
    {
        public string From { get; set; }
        public string Message { get; set; }
        public string Body { get; set; }
    }
}

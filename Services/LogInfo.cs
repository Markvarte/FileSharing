using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fileSharing.Services
{
    public class LogInfo
    {
        public string sharingLink { get; set; }
        public string uploadedFileName { get; set; }
        public string ipAddress { get; set; }
        public string eMail { get; set; }
        public string uploadDate { get; set; }
        public string uploadedTime { get; set; }
    }
}
using fileSharing.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fileSharing.Pages
{
    public partial class fileSharingClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileSharingService fileSharingService = new FileSharingService();
            lblUploadResult.Text = fileSharingService.CreateSharing(oFile, PasswordBox.Text, TextBox1, TextBox2);
            
        }

        public void DownloadFile(string fileName, string dirName)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + fileName);
            Response.TransmitFile(Server.MapPath($"~/Pages/{dirName}/")
                + fileName);
            Response.End();
        }

    }
}
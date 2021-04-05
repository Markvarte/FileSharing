using fileSharing.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

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
            string clientIp = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                   Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
            string[] serviceResult = fileSharingService.CreateSharing(oFile, clientIp, PasswordBox.Text, TextBox1, TextBox2);
            lblUploadResult.Text = serviceResult[0];
            if (serviceResult[1] != "")
            {
                ReadLogfile(serviceResult[1]);
            }

        }

        private void ReadLogfile(string filename)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filename);
            dataGridViewLogfile.DataSource = ds;
            dataGridViewLogfile.DataMember = ds.Tables[0].TableName;
            dataGridViewLogfile.DataBind();
        }

    }
}
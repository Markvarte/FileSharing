using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace fileSharing.Services
{
    /// <summary>
    /// Summary description for FileSharingService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileSharingService : System.Web.Services.WebService
    {

        [WebMethod]
        public string CreateSharing(HtmlInputFile oFile, string pw, TextBox eMail = null, TextBox comment = null)
        {
            if (pw != "123")
            {
                return "Wrong password! Access denied.";

            }
            return UploadFile(oFile);
        }
        [WebMethod]
        public string UploadFile(HtmlInputFile oFile)
        {

            string strFileName;
            string strFilePath;
            string strFolder;
            String timeStamp = GetTimestamp(DateTime.Now);
            strFolder = Server.MapPath($"./{timeStamp}/");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (oFile.Value != "")
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    // return it to lblUploadResult.Text on client
                    return strFileName + " already exists on the server!";
                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);
                    // Here code for link!
                    // return it to lblUploadResult.Text on client
                    return strFileName + " has been successfully uploaded.";
                }
            }
            else
            {
                // return it to lblUploadResult.Text on client
                return "Click 'Browse' to select the file to upload.";
            }
        }
        [WebMethod]
        public string CreateLinkForUploadedFile()
        {
            return "Hello World";
        }

        static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}

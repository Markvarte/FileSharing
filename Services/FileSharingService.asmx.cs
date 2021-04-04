using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

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
        IPAddress globalIp = null;
        string globalUploadedDate = "";
        string globalUploadedTime = "";

        [WebMethod]
        public string CreateSharing(HtmlInputFile oFile, string pw, TextBox eMail = null, TextBox comment = null)
        {
            if (pw != "123")
            {
                return "Wrong password! Access denied.";

            }
            string resString;
            string sharingLink = UploadFile(oFile);
            resString = sharingLink;
            if (eMail != null && sharingLink.StartsWith("http"))
            {
                string mailResult = SentMail(eMail, comment, sharingLink);
                resString = $"Sent mail result: {mailResult}, sharing link: {sharingLink}";
            }

            LogInfo loginfo = new LogInfo {
                sharingLink = sharingLink,
                uploadedFileName = oFile.PostedFile.FileName,
                ipAddress = "localhost",
                eMail = eMail.Text,
                uploadDate = globalUploadedDate,
                uploadedTime = globalUploadedTime };

            WriteLogInformation(loginfo);
            return resString;

        }
        [WebMethod]
        public string UploadFile(HtmlInputFile oFile)
        {
            string sharingLink;
            string strFileName;
            string strFilePath;
            string strFolder;
            string timeStamp = GetTimestamp(DateTime.Now);
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
                    return strFileName + " already exists on the server!";
                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);

                    // Returning link to download file
                    // For axample http://haring.azurewebsites.net/api/File/202104031232546682
                    var isAzure = Environment.GetEnvironmentVariable("IsAzure") == "1";
                    var host = isAzure ? "http://haring.azurewebsites.net" : "https://localhost:44399";

                    sharingLink = $"{host}/api/File/{timeStamp}";
                    return sharingLink;
                }
            }
            else
            {
                return "Click 'Browse' to select the file to upload.";
            }
        }
        private void WriteLogInformation(LogInfo logInfo)
        {
            StringBuilder sbuilder = new StringBuilder();
            using (StringWriter sw = new StringWriter(sbuilder))
            {
                using (XmlTextWriter w = new XmlTextWriter(sw))
                {
                    w.WriteStartElement("LogInfo");
                    w.WriteElementString("sharingLink", logInfo.sharingLink);
                    w.WriteElementString("uploadedFileName", logInfo.uploadedFileName);
                    w.WriteElementString("ipAddress", logInfo.ipAddress);
                    w.WriteElementString("eMail", logInfo.eMail);
                    w.WriteElementString("uploadDate", logInfo.uploadDate);
                    w.WriteElementString("uploadedTime", logInfo.uploadedTime);
                    w.WriteEndElement();
                }
            }

            string strFolder = Server.MapPath($"./Logs/");
            // Create the directory if it does not exist.
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            string logFilePath = Server.MapPath($"./Logs/{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.xml");
            using (StreamWriter w = new StreamWriter(logFilePath, false, Encoding.UTF8))
            {
                w.WriteLine(sbuilder.ToString());
            }
        }

        public string SentMail(TextBox email, TextBox comment, string sharinklink)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email.Text);
                mail.From = new MailAddress("ASPNETwebapp@user.lv");
                mail.Subject = "Sharing Link";
                mail.Body = $"{comment.Text}\n{sharinklink}";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.hronoss.com";
                smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("studenti@hronoss.com", "TestaPasts1");
                smtp.EnableSsl = false;

                smtp.Send(mail);
                return "Mail Send succcesfully";
            }
            catch (Exception ex)
            {                         
                return ex.Message;
            }
        }

        string GetTimestamp(DateTime value)
        {
            globalUploadedDate = value.ToString("yyyy-MM-dd");
            globalUploadedTime = value.ToString("HH:mm:ss");
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}

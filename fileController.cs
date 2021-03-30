using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace fileSharing
{
    public class FileController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get(string id)
        {
            string filePath = "C:\\Users\\Natalija\\source\\repos\\fileSharing\\Pages\\202103302218445812\\7GGRMW34Va8.jpg";
            if (File.Exists(filePath))
            {
                //byte[] fileContent = File.ReadAllBytes(f.FullName);
                //FileStream fs = File.Create(f.FullName);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");
                return result;
            } else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
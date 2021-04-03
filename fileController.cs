using fileSharing.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace fileSharing
{
    public class FileController : ApiController
    {
        // GET api/<controller>/id
        public HttpResponseMessage Get(string id)
        {
            string fullPath = HttpContext.Current.Server.MapPath($"~\\Pages\\{id}");
            if (Directory.Exists(fullPath))
            {
                string[] fineNamesWithPath = Directory.GetFiles(fullPath);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                // Every Directory contains only 1 file, so get first fineNamesWithPath array item => fineNamesWithPath[0]
                var stream = new FileStream(fineNamesWithPath[0], FileMode.Open, FileAccess.Read);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");
                return result;
            } else
            {
                // Directory does not exist or path is incorrect.
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
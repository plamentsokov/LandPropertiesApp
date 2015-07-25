using LandPropertiesApp.Web.Helpers;
using LandPropertiesApp.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LandPropertiesApp.Web.Controllers
{
    public class FilesController : ApiController
    {
        [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = Utils.GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            return this.Request.CreateResponse(HttpStatusCode.OK, new { fileName = uploadedFileInfo.Name });
        }        
    }
}
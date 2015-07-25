using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LandPropertiesApp.Web.Helpers
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName;
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                var ext = Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
                fileName = Guid.NewGuid() + ext;
            }
            else
            {
                fileName = Guid.NewGuid() + ".data";
            }
            return fileName;
        }
    }
}
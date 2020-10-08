using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Model.Images;

namespace UselessCMS.Models
{
    public static class Utilities
    {
        public static byte[] Getbytes(this IFormFile file)
        {
            using (var reader = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                reader.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}

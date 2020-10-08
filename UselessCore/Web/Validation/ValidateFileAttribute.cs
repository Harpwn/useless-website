﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace UselessCore.Web.Validation
{
    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var file = value as IFormFile;
            if (file == null)
            {
                return false;
            }

            if (file.Length > 1 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var ms = new MemoryStream())
                {
                    file.OpenReadStream().CopyTo(ms);
                    var img = Image.FromStream(ms);

                    return img.RawFormat.Equals(ImageFormat.Png) || img.RawFormat.Equals(ImageFormat.Jpeg);
                }
            }
            catch(Exception e) { }
            return false;
        }
    }
}

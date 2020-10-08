using System;
using System.Collections.Generic;
using System.Text;

namespace UselessCore.Services.Images.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public DateTime LastModified { get; set; }
    }
}

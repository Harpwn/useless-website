using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Web.Validation;
using Xunit;

namespace UselessCore.Tests.Web.Validation
{
    public class ValidateFileAttributeTests
    {
        [Fact]
        public void ValidateFileAttribute_IsValid_WhenNoInput()
        {
            var attribute = new ValidateFileAttribute();
            var result = attribute.IsValid(null);
            Assert.True(result);
        }

        [Fact]
        public void ValidateFileAttribute_IsInValid_WhenInputIsNotFile()
        {
            var attribute = new ValidateFileAttribute();
            var result = attribute.IsValid(1);
            Assert.False(result);
        }

        [Fact]
        public void ValidateFileAttribute_IsValid_WhenInputIsCorrectFormat()
        {
            using (var fileStream = new MemoryStream())
            {
                Image image = new Bitmap(1, 1);
                image.Save(fileStream, ImageFormat.Png);
                IFormFile file = new FormFile(fileStream, 0, fileStream.Length, "Data", "dummy.png");

                var attribute = new ValidateFileAttribute();
                var result = attribute.IsValid(file);
                Assert.True(result);
            }
        }

        [Fact]
        public void ValidateFileAttribute_IsInValid_WhenInputIsTooBig()
        {
            using (var fileStream = new MemoryStream())
            {
                Image image = new Bitmap(1, 1);
                image.Save(fileStream, ImageFormat.Png);
                IFormFile file = new FormFile(fileStream, 0, 2 * 1024 * 1024, "Data", "dummy.png");

                var attribute = new ValidateFileAttribute();
                var result = attribute.IsValid(file);
                Assert.False(result);
            }
        }

        [Fact]
        public void ValidateFileAttribute_IsInValid_WheInputIsNotSupportedFormat()
        {
            using (var fileStream = new MemoryStream())
            {
                Image image = new Bitmap(1, 1);
                image.Save(fileStream, ImageFormat.Gif);
                IFormFile file = new FormFile(fileStream, 0, fileStream.Length, "Data", "dummy.png");

                var attribute = new ValidateFileAttribute();
                var result = attribute.IsValid(file);
                Assert.False(result);
            }
        }
    }
}

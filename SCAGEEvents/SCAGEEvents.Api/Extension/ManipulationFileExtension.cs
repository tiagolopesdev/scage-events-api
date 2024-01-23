﻿using System.IO;

namespace SCAGEEvents.Api.Extension
{
    public static class ManipulationFileExtension
    {
        public static string CheckExtensionFile(IFormFile formFile)
        {
            string result = Path.GetExtension(formFile.FileName);

            return result switch
            {
                ".png" => "image/png",
                ".jpeg" => "image/jpeg",
                ".jpg" => "image/jpeg",
                _ => throw new Exception("A extensão das miniaturas deve ser .png, .jpeg ou .jpg")
            };
        }        
    }
}

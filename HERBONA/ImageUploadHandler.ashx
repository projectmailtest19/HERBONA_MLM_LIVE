<%@ WebHandler Language="C#" Class="ImageUploadHandler" %>

using System;
using System.Web;
using System.IO;
using System.Configuration;

public class ImageUploadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string dirFullPath = HttpContext.Current.Server.MapPath("CompanyLogo/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;
        string str_image = "";
        string pathToSave_100 = "";
        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            string fileName = file.FileName;
            string fileExtension = file.ContentType;

            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = System.IO.Path.GetExtension(fileName);
                str_image = "CMPPHOTO_" + numFiles.ToString() + fileExtension;
                pathToSave_100 = HttpContext.Current.Server.MapPath("CompanyLogo/") + str_image;
                if (System.IO.File.Exists(pathToSave_100))
                {
                    System.IO.File.Delete(pathToSave_100);
                }
                file.SaveAs(pathToSave_100);
            }
        }
        //  database record update logic here  ()
        if (System.IO.File.Exists(pathToSave_100))
        {
            context.Response.Write(str_image);
            return;
        }
        context.Response.Write(str_image);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
} 
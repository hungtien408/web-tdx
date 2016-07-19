using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Drawing.Imaging;


namespace TLLib
{
    public class ResizeCropImage
    {
        public static void ResizeByWidth(string OriginalImagePath, int WidthToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            if (origBMP.Width > WidthToResize)
            {
                int HeightToResize = (int)(((float)origBMP.Height / origBMP.Width) * WidthToResize);
                Bitmap newBMP = new Bitmap(WidthToResize, HeightToResize);
                Graphics objGra = Graphics.FromImage(newBMP);
                objGra.SmoothingMode = SmoothingMode.AntiAlias;
                objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
                objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
                objGra.CompositingQuality = CompositingQuality.HighQuality;
                objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
                origBMP.Dispose();
                newBMP.Save(FullPath, format);
                newBMP.Dispose();
                objGra.Dispose();
            }
            origBMP.Dispose();
        }
        public static void CreateThumbNailByWidth(string OriginalImagePath, string PathToSaveThumbNail, int ThumbNailWidth)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int ThumbNailHeight = (int)(((float)origBMP.Height / origBMP.Width) * ThumbNailWidth);
            Bitmap newBMP = new Bitmap(ThumbNailWidth, ThumbNailHeight, PixelFormat.Format24bppRgb);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory, format);
            newBMP.Dispose();
            objGra.Dispose();
        }
        public static void CreateThumbNailByWidth(string OriginalImagePath, string PathToSaveThumbNail, string filename, int ThumbNailWidth)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath + "/" + filename);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);

            if (!Directory.Exists(FullSaveDirectory))
                Directory.CreateDirectory(FullSaveDirectory);

            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int ThumbNailHeight = (int)(((float)origBMP.Height / origBMP.Width) * ThumbNailWidth);
            Bitmap newBMP = new Bitmap(ThumbNailWidth, ThumbNailHeight, PixelFormat.Format24bppRgb);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory + "/" + filename, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void CreateThumbNailByHeight(string OriginalImagePath, string PathToSaveThumbNail, string filename, int ThumbNailHeight)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath + "/" + filename);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int ThumbNailWidth = (int)(((float)origBMP.Width / origBMP.Height) * ThumbNailHeight);
            Bitmap newBMP = new Bitmap(ThumbNailWidth, ThumbNailHeight, PixelFormat.Format24bppRgb);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory + "/" + filename, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void ResizeByHeight(string OriginalImagePath, int HeightToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            if (origBMP.Height > HeightToResize)
            {
                int WidthToResize = (int)(((float)origBMP.Width / origBMP.Height) * HeightToResize);
                Bitmap newBMP = new Bitmap(WidthToResize, HeightToResize, PixelFormat.Format24bppRgb);
                Graphics objGra = Graphics.FromImage(newBMP);
                objGra.SmoothingMode = SmoothingMode.AntiAlias;
                objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
                objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
                objGra.CompositingQuality = CompositingQuality.HighQuality;
                objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
                origBMP.Dispose();
                newBMP.Save(FullPath, format);
                newBMP.Dispose();
                objGra.Dispose();
            }
            origBMP.Dispose();
        }
        public static void ResizeByCondition(string OriginalImagePath, int WidthToResize, int HeightToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(width, height);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullPath, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void ResizeWithBackGroundColor(string OriginalImagePath, int WidthToResize, int HeightToResize, string BackGroundColor)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            BackGroundColor = BackGroundColor.StartsWith("#") ? BackGroundColor : "#" + BackGroundColor;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(WidthToResize, HeightToResize);
            Graphics objGra = Graphics.FromImage(newBMP);
            Color color = ColorTranslator.FromHtml(BackGroundColor);

            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;

            objGra.Clear(color);
            objGra.DrawImage(origBMP, new Rectangle((WidthToResize - width) / 2, (HeightToResize - height) / 2, width, height));
            origBMP.Dispose();
            newBMP.Save(FullPath, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void CreateThumbNailByCondition(string OriginalImagePath, string PathToSaveThumbNail, string filename, int WidthToResize, int HeightToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath + "/" + filename);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);

            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(width, height);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory + "/" + filename, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void CreateThumbNailWithBackGroundColor(string OriginalImagePath, string PathToSaveThumbNail, string filename, int WidthToResize, int HeightToResize, string BackGroundColor)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;
            BackGroundColor = BackGroundColor.StartsWith("#") ? BackGroundColor : "#" + BackGroundColor;

            string FullPath = HttpContext.Current.Server.MapPath(OriginalImagePath + "/" + filename);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);

            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(WidthToResize, HeightToResize);
            Graphics objGra = Graphics.FromImage(newBMP);
            Color color = ColorTranslator.FromHtml(BackGroundColor);

            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;

            objGra.Clear(color);
            objGra.DrawImage(origBMP, new Rectangle((WidthToResize - width) / 2, (HeightToResize - height) / 2, width, height));

            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory + "/" + filename, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void crop(string imagePath, int WidthToCrop, int HeightToCrop)
        {
            imagePath = imagePath.StartsWith("~/") ? imagePath : "~/" + imagePath;

            string displayedImg = HttpContext.Current.Server.MapPath(imagePath);
            Bitmap origBMP = new Bitmap(displayedImg);
            ImageFormat format = origBMP.RawFormat;
            int newWidth = WidthToCrop;
            int newHeight = (int)(((float)origBMP.Height / origBMP.Width) * WidthToCrop);
            Bitmap newBMP = new Bitmap(origBMP, WidthToCrop, HeightToCrop);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            Rectangle rec = new Rectangle(0, 0, newBMP.Width, newBMP.Height);
            int CropPointX = (origBMP.Width - WidthToCrop) / 2;
            int CropPointY = (origBMP.Height - HeightToCrop) / 2;
            objGra.DrawImage(origBMP, rec, CropPointX, CropPointY, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            origBMP.Dispose();
            newBMP.Save(displayedImg, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        
        public static void ResizeWidthCorner(string imagePath, int WidthToResize)
        {
            imagePath = imagePath.StartsWith("~/") ? imagePath : "~/" + imagePath;

            string displayedImg = HttpContext.Current.Server.MapPath(imagePath);
            string background = HttpContext.Current.Server.MapPath("~/assets/drawRes/bg.jpg");

            string rc = HttpContext.Current.Server.MapPath("~/assets/drawRes/rc.jpg");
            string cb = HttpContext.Current.Server.MapPath("~/assets/drawRes/cb.jpg");
            string rt = HttpContext.Current.Server.MapPath("~/assets/drawRes/rt.jpg");
            string rb = HttpContext.Current.Server.MapPath("~/assets/drawRes/rb.jpg");
            string lb = HttpContext.Current.Server.MapPath("~/assets/drawRes/lb.jpg");

            Bitmap baseImg = new Bitmap(displayedImg);
            ImageFormat format = baseImg.RawFormat;
            Bitmap origBMP = new Bitmap(baseImg, WidthToResize, (int)(((float)baseImg.Height / baseImg.Width) * WidthToResize));
            Bitmap backgroundBMP = new Bitmap(background);
            Bitmap rcBMP = new Bitmap(rc);
            Bitmap cbBMP = new Bitmap(cb);
            Bitmap rtBMP = new Bitmap(rt);
            Bitmap rbBMP = new Bitmap(rb);
            Bitmap lbBMP = new Bitmap(lb);

            int newWidth = WidthToResize;
            int newHeight = (int)(((float)origBMP.Height / origBMP.Width) * WidthToResize);
            Bitmap newBMP = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            Rectangle rectl = new Rectangle(0, 0, newBMP.Width, newBMP.Height);
            int CropPointX = (origBMP.Width - WidthToResize) / 2;
            int CropPointY = (origBMP.Height - newHeight) / 2;
            objGra.DrawImage(backgroundBMP, newWidth, newHeight);
            objGra.DrawLine(new Pen(Color.FromArgb(238, 238, 238)), 0, 0, newBMP.Width, 0);
            objGra.DrawLine(new Pen(Color.FromArgb(238, 238, 238)), 0, 0, 0, newBMP.Height);
            for (int i = 7; i < newBMP.Height - 7; i++)
            {
                objGra.DrawImage(rcBMP, new Rectangle(newBMP.Width - 7, i, newBMP.Width, newBMP.Height), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            }
            for (int i = 8; i < newBMP.Width - 7; i++)
            {
                objGra.DrawImage(cbBMP, new Rectangle(i, newBMP.Height - 8, newBMP.Width, newBMP.Height), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            }
            objGra.DrawImage(rtBMP, new Rectangle(newBMP.Width - 7, 0, newBMP.Width, newBMP.Height), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            objGra.DrawImage(rbBMP, new Rectangle(newBMP.Width - 7, newBMP.Height - 7, newBMP.Width, newBMP.Height), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            objGra.DrawImage(lbBMP, new Rectangle(0, newBMP.Height - 8, newBMP.Width, newBMP.Height), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);
            objGra.DrawImage(origBMP, new Rectangle(7, 7, newBMP.Width - 21, newBMP.Height - 21), 0, 0, newBMP.Width, newBMP.Height, GraphicsUnit.Pixel);

            baseImg.Dispose();
            origBMP.Dispose();
            backgroundBMP.Dispose();
            rcBMP.Dispose();
            cbBMP.Dispose();
            rtBMP.Dispose();
            rbBMP.Dispose();
            lbBMP.Dispose();

            newBMP.Save(HttpContext.Current.Server.MapPath(imagePath), format);
            newBMP.Dispose();
            objGra.Dispose();
        }
        public static void CreateThumbNailWithBorder(string OriginalImagePath, string PathToSaveThumbNail, int ThumbNailWidth)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string displayedImg = HttpContext.Current.Server.MapPath(OriginalImagePath);
            string FullSaveDirectory = HttpContext.Current.Server.MapPath(PathToSaveThumbNail);
            string tl = HttpContext.Current.Server.MapPath("~/assets/drawRes/ctl.png");
            string tr = HttpContext.Current.Server.MapPath("~/assets/drawRes/ctr.png");
            string br = HttpContext.Current.Server.MapPath("~/assets/drawRes/cbr.png");
            string bl = HttpContext.Current.Server.MapPath("~/assets/drawRes/cbl.png");
            Bitmap origBMP = new Bitmap(displayedImg);
            ImageFormat format = origBMP.RawFormat;
            Bitmap tlBMP = new Bitmap(tl);
            Bitmap trBMP = new Bitmap(tr);
            Bitmap brBMP = new Bitmap(br);
            Bitmap blBMP = new Bitmap(bl);

            int newWidth = ThumbNailWidth;
            int newHeight = (int)(((float)origBMP.Height / origBMP.Width) * ThumbNailWidth);
            Bitmap newBMP = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            int CropPointX = (origBMP.Width - ThumbNailWidth) / 2;
            int CropPointY = (origBMP.Height - newHeight) / 2;
            Pen penDrawLine = new Pen(Color.FromArgb(153, 153, 153));

            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            objGra.DrawLine(penDrawLine, 0, 0, newBMP.Width, 0);
            objGra.DrawLine(penDrawLine, newBMP.Width, 0, newBMP.Width, newBMP.Height);
            objGra.DrawLine(penDrawLine, newBMP.Width, newBMP.Height, 0, newBMP.Height);
            objGra.DrawLine(penDrawLine, 0, newBMP.Height, 0, 0);
            objGra.DrawImage(tlBMP, new Rectangle(0, 0, 6, 6));
            objGra.DrawImage(trBMP, new Rectangle(newBMP.Width - 6, 0, 6, 6));
            objGra.DrawImage(brBMP, new Rectangle(newBMP.Width - 6, newBMP.Height - 6, 6, 6));
            objGra.DrawImage(blBMP, new Rectangle(0, newBMP.Height - 6, 6, 6));

            origBMP.Dispose();
            tlBMP.Dispose();

            trBMP.Dispose();

            brBMP.Dispose();

            blBMP.Dispose();

            newBMP.Save(FullSaveDirectory, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

    }
}

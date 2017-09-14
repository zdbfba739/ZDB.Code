using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;

namespace ZDB.Images.QRCode
{
    public class QRCode
    {
        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="contents">要生成二维码包含的信息</param>
        /// <param name="width">生成的二维码宽度（默认300像素）</param>
        /// <param name="height">生成的二维码高度（默认300像素）</param>
        /// <returns>二维码图片</returns>
        public static Bitmap GeneratorQrImage(string contents, int width = 300, int height = 300)
        {
            if (string.IsNullOrEmpty(contents))
            {
                return null;
            }
            //本文地址：http://www.cnblogs.com/Interkey/p/qrcode.html
            EncodingOptions options = null;
            BarcodeWriter writer = null;
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
                ErrorCorrection = ErrorCorrectionLevel.H,
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            //WriteableBitmap dd = writer.Write(contents);
            Bitmap bitmap = BitmapFromWriteableBitmap(writer.Write(contents)) ;

            return bitmap;
        }

        /// <summary>
        /// 生成中间带有图片的二维码图片
        /// </summary>
        /// <param name="contents">要生成二维码包含的信息</param>
        /// <param name="middleImg">要生成到二维码中间的图片</param>
        /// <param name="width">生成的二维码宽度（默认300像素）</param>
        /// <param name="height">生成的二维码高度（默认300像素）</param>
        /// <returns>中间带有图片的二维码</returns>
        public static Bitmap GeneratorQrImage(string contents, Image middleImg, int width = 300, int height = 300)
        {
            if (string.IsNullOrEmpty(contents))
            {
                return null;
            }
            if (middleImg == null)
            {
                //return null;
                return GeneratorQrImage(contents);
            }
            ////本文地址：http://www.cnblogs.com/Interkey/p/qrcode.html
            //构造二维码写码器
            MultiFormatWriter mutiWriter = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            //生成二维码
            BitMatrix bm = mutiWriter.encode(contents, BarcodeFormat.QR_CODE, width, height, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap bitmap = BitmapFromWriteableBitmap(barcodeWriter.Write(bm));
            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleImgW = Math.Min((int)(rectangle[2] / 3.5), middleImg.Width);
            int middleImgH = Math.Min((int)(rectangle[3] / 3.5), middleImg.Height);
            int middleImgL = (bitmap.Width - middleImgW) / 2;
            int middleImgT = (bitmap.Height - middleImgH) / 2;

            //将img转换成bmp格式，否则后面无法创建 Graphics对象
            Bitmap bmpimg = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(bitmap, 0, 0);
            }

            //在二维码中插入图片
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底
            myGraphic.FillRectangle(Brushes.White, middleImgL, middleImgT, middleImgW, middleImgH);
            myGraphic.DrawImage(middleImg, middleImgL, middleImgT, middleImgW, middleImgH);
            return bmpimg;
        }

        private static System.Drawing.Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
        {
            System.Drawing.Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }

    }
}

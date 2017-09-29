using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using ThoughtWorks.QRCode.Codec;
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
        /// 生产二维码
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <returns></returns>
        public static Bitmap EnCoder(string content)
        {
            QRCodeEncoder endocder = new QRCodeEncoder();
            //二维码背景颜色
            endocder.QRCodeBackgroundColor = System.Drawing.Color.White;
            //二维码编码方式
            endocder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //每个小方格的宽度
            endocder.QRCodeScale = 10;
            //二维码版本号
            endocder.QRCodeVersion = 5;
            //纠错等级
            endocder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //将json川做成二维码
            Bitmap bitmap = endocder.Encode(content, System.Text.Encoding.UTF8);
            
            return bitmap;
        }

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string DeCoder(string filePath)
        {
            string result = "";
            if (System.IO.File.Exists(filePath))
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                result = decoder.decode(new ThoughtWorks.QRCode.Codec.Data.QRCodeBitmapImage(new Bitmap(Image.FromFile(filePath))));
            }
            return result;
        }

    }
}

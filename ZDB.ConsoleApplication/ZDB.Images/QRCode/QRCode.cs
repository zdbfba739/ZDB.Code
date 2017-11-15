using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
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

        public static List<string> FilterFileAndDir = new List<string>();
        private static List<FileInfo> GetFileList(string sDirectoryPath, PackingScope scope)
        {
            List<FileInfo> filesInfo = new List<FileInfo>();
            DirectoryInfo dir = new DirectoryInfo(sDirectoryPath);
            if (FilterFileAndDir.Contains(dir.Name))
            {
                return filesInfo;
            }
            if (scope != PackingScope.Folder)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo fTemp in files)
                {
                    if (FilterFileAndDir.Contains(fTemp.Name))
                    {
                        continue;
                    }
                    else
                    {
                        filesInfo.Add(fTemp);
                    }

                }
            }
            if (scope != PackingScope.File)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo dirTemp in dirs)
                {
                    List<FileInfo> templist = GetFileList(dirTemp.FullName, PackingScope.All);
                    foreach (FileInfo fileTemp in templist)
                    {
                        if (FilterFileAndDir.Contains(fileTemp.Name))
                        {
                            continue;
                        }
                        else
                        {
                            filesInfo.Add(fileTemp);
                        }

                    }
                }
            }
            return filesInfo;

        }

        /// <summary>
        /// 把文件夹里面的文件为一个压缩包文件
        /// </summary>
        /// <param name="sDirectoryPath">需要打包的目录</param>
        /// <param name="FileName">打包之后保存的文件名称，如D:\packing.zip</param>
        /// <param name="scope">打包的范围</param>
        /// <returns></returns>
        public static bool ToFile(string sDirectoryPath, string FileName, PackingScope scope)
        {
            bool result = false;
            List<FileInfo> filesInfo = new List<FileInfo>();
            Crc32 crc = new Crc32();
            ZipOutputStream s = null;
            int i = 1;
            try
            {
                FileInfo filedd = new FileInfo(FileName);
                if (!Directory.Exists(filedd.Directory.FullName))
                {
                    Directory.CreateDirectory(filedd.Directory.FullName);
                }
                s = new ZipOutputStream(File.OpenWrite(FileName));
                s.SetLevel(9);

                DirectoryInfo mainDir = new DirectoryInfo(sDirectoryPath);
                filesInfo = GetFileList(mainDir.FullName, scope);
                foreach (FileInfo file in filesInfo)
                {
                    using (FileStream fs = File.OpenRead(file.FullName))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        ZipEntry entry = new ZipEntry(ZipEntry.CleanName(file.Name));
                        entry.DateTime = DateTime.Now;
                        entry.Comment = i.ToString();
                        entry.ZipFileIndex = i++;
                        entry.Size = fs.Length;
                        fs.Close();
                        crc.Reset();
                        crc.Update(buffer);
                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);
                        s.Write(buffer, 0, buffer.Length);
                    }
                }
                s.Finish();
                s.Close();
                result = true;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                s.Close();
            }
            return result;
        }

        public enum PackingScope
        {
            Folder,
            File,
            All
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDB.Images.ZoomPic
{
    public class ZoomPic
    {


        public static void ZoomPicture(string ImgPath, int TargetWidth, int TargetHeight)
        {
            var fileInfo = new FileInfo(ImgPath);
            var savePath = fileInfo.DirectoryName + "\\" + fileInfo.Name + "_"+ TargetWidth + "x"+ TargetHeight + fileInfo.Extension;
            var stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var SourceImage = Image.FromStream(stream);
            stream.Close();

            int IntWidth; //新的图片宽
            int IntHeight; //新的图片高

            //计算新图片的宽高
            var k1 = (double)TargetWidth / (double)SourceImage.Width; //以宽作为缩放基准
            if (TargetHeight >= (SourceImage.Height * k1))
            {
                IntWidth = TargetWidth;
                IntHeight = Convert.ToInt32(SourceImage.Height * k1);
            }
            else//以高作为缩放基准
            {
                IntHeight = TargetHeight;
                IntWidth = Convert.ToInt32(SourceImage.Width * ((double)TargetHeight / (double)SourceImage.Height));

            }
            //生成新的Bitmap实例
            using (var newImage = new Bitmap(IntWidth, IntHeight))
            {
                //绘制图片
                Graphics g = Graphics.FromImage(newImage);
                g.Clear(Color.White);
                g.DrawImage(SourceImage, 0, 0, IntWidth, IntHeight);
                //保存新图片
                newImage.Save(savePath);
                //var stream = new FileStream(savePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //return stream;
            }
        }


    }
}

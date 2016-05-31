using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//将二进制数据编码为BASE64
namespace cook_book.ch_03
{
    public static class ch_03_01
    {
        public static string Base64EncodeBytes(this byte[] inputBytes) => Convert.ToBase64String(inputBytes);

        public static string EncodeBitmapToString(string bitmapFilePath)
        {
            byte[] image = null;
            FileStream fstrm = new FileStream(bitmapFilePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fstrm))
            {
                image = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                {
                    image[i] = reader.ReadByte();
                }
            }
            return image.Base64EncodeBytes();
        }

        public static string MakeBase64EncodeStringForMime(string base64Encode)
        {
            StringBuilder originalStr = new StringBuilder(base64Encode);
            StringBuilder newStr = new StringBuilder();
            const int mimeBoundary = 76;
            int cntr = 1;
            while ((cntr*mimeBoundary) < (originalStr.Length - 1))
            {
                newStr.AppendLine(originalStr.ToString(((cntr - 1)*mimeBoundary),
                    mimeBoundary));
                cntr++;
            }
            if (((cntr - 1)*mimeBoundary) < (originalStr.Length - 1))
            {
                newStr.AppendLine(originalStr.ToString(((cntr - 1)*mimeBoundary),
                    ((originalStr.Length) - ((cntr - 1)*mimeBoundary))));
            }
            return newStr.ToString();
        }
    }
}
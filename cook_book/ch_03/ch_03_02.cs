using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//将BASE64数据反编码为二进制
namespace cook_book.ch_03
{
    static class ch_03_02
    {
        public static byte[] Base64DecodeString(this string imputStr)
        {
            byte[] decodedByteArray = Convert.FromBase64String(imputStr);
            return decodedByteArray;
        }
    }
}

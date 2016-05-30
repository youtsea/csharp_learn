using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//类似C++中的联合体
namespace cook_book.ch_01
{
    [StructLayout(LayoutKind.Explicit)]
    struct SignedNumber
    {
        [FieldOffset(0)]
        public sbyte num1;
        [FieldOffset(0)]
        public short num2;
        [FieldOffset(0)]
        public int num3;
        [FieldOffset(0)]
        public long num4;
        [FieldOffset(0)]
        public float num5;
        [FieldOffset(0)]
        public double num6;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//结构体初始化
namespace cook_book.ch_01
{
    public class ch_01_18
    {
    }

    public struct Data
    {
        public Data(int intData, float floatData, string strData, char charData, bool boolData)
        {
            this.IntData = intData;
            this.FloatData = floatData;
            this.StrData = strData;
            this.CharData = charData;
            this.BoolData = boolData;
        }

        public int IntData { get; }
        public float FloatData { get; }
        public string StrData { get; }
        public char CharData { get; }
        public bool BoolData { get; }

        public override string ToString() => IntData + " :: " + FloatData + " :: " +
                                             StrData + " :: " + CharData + " :: " + BoolData;
    }
}
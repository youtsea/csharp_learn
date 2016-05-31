﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//将byte数组转为字符串
namespace cook_book.ch_03
{
    class ch_03_03
    {
        public static void Test()
        {
            byte[] asciiCharacterArray =
            {
                128, 83, 111, 117, 114, 99, 101,
                32, 83, 116, 114, 105, 110, 103, 128
            };
            string asciiCHaracters = Encoding.ASCII.GetString(asciiCharacterArray);

            byte[] unicodeCharacterArray = {128, 0, 83, 0, 111, 0, 117, 0, 114, 0, 99, 0,
                            101, 0, 32, 0, 83, 0, 116, 0, 114, 0, 105, 0, 110,
                        0, 103, 0, 128, 0};

            string unicodeCharacters = Encoding.Unicode.GetString(unicodeCharacterArray);
        }
    }
}
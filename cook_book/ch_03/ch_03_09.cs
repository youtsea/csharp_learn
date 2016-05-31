using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//枚举值有效性的验证
namespace cook_book.ch_03
{
    class ch_03_09
    {
    }

    public enum Language
    {
        Other = 0, CSharp = 1, VBNET = 2, VB6 = 3,
        All = (Other | CSharp | VBNET | VB6)
    }
}

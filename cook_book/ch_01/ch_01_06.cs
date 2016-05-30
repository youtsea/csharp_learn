using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//在运行时初始化常量
namespace cook_book.ch_01
{
    class Foo
    {
        public readonly int x;
        public const int y = 1;

        public Foo()
        {
            
        }

        public Foo(int constInitValue)
        {
            x = constInitValue;
        }
    }
}

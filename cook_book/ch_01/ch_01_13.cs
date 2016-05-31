using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//初始化泛型变量
namespace cook_book.ch_01
{
    class ch_01_13
    {
    }

    public class DefaultValueExample<T>
    {
        T data = default(T);

        public bool IsDefaultData()
        {
            T temp = default(T);
            if (temp.Equals(data))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetData(T val) => data = val;
    }
}

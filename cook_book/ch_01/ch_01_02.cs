using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//实现可排序类型
namespace cook_book.ch_01
{
    public class Square: IComparable<Square>
    {
        public Square()
        {
            
        }

        public Square(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height { get; set; }
        public int Width { get; set; }

        public override string ToString()=>
            ($"Height: {this.Height}    Width: {this.Width}");

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Square square = obj as Square;
            if (square != null)
                return this.Height == square.Height;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Height.GetHashCode() | this.Width.GetHashCode();
        }

        public static bool operator ==(Square x, Square y) => x.Equals(y);
        public static bool operator !=(Square x, Square y) => !(x == y);
        public static bool operator <(Square x, Square y) => (x.CompareTo(y) < 0);
        public static bool operator >(Square x, Square y) => (x.CompareTo(y) > 0);

        public int CompareTo(Square other)
        {
            long area1 = this.Height*this.Width;
            long area2 = other.Height*other.Width;
            if (area1 == area2)
            {
                return 0;
            }
            else if (area1 > area2)
                return 1;
            else if (area2 > area1)
                return -1;
            else
            {
                return -1;
            }
        }

    }

    public class CompareHeight : IComparer<Square>
    {
        public int Compare(Square x, Square y)
        {
            if (x.Height == y.Height)
                return 0;
            else if (x.Height > y.Height)
                return 1;
            else if (x.Height < y.Height)
                return -1;
            return -1;
        }
    }
}

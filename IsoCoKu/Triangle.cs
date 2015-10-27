using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoCoKu
{
    class Triangle
    {
        public static int[][] Triangles = new int[][]
        {   new int[]{0, 0, 0},
            new int[]{1, 0, 0},
            new int[]{1, 1, 0},
            new int[]{1, 1, 1},
            new int[]{2, 0, 0},
            new int[]{2, 1, 0},
            new int[]{2, 1, 0},
            new int[]{2, 1, 0},
            new int[]{2, 0, 1},
            new int[]{2, 0, 1},
            new int[]{2, 0, 1},
            new int[]{2, 2, 0},
            new int[]{2, 2, 2},
            new int[]{3, 0, 0},
            new int[]{3, 1, 2},
            new int[]{3, 1, 2},
            new int[]{3, 2, 1},
            new int[]{3, 2, 1},
            new int[]{3, 3, 0},
            new int[]{3, 3, 3}
        };

        public int[] dots;

        public Triangle(int DotsTop, int DotsLeft, int DotsRight)
        {
            dots = new int[] { DotsTop, DotsLeft, DotsRight };
        }

        public Triangle(int[] triangle, int rotation)
        {
            dots = new int[]{
                triangle[rotation],
                triangle[(1 + rotation) % 3],
                triangle[(2 + rotation) % 3]
            };
        }

        public Triangle(Triangle triangle, int rotation) :
            this(triangle.dots, rotation) { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Triangle t = obj as Triangle;
            if ((Object)t == null) return false;

            return (t.dots[0] == dots[0] && t.dots[1] == dots[1] && t.dots[2] == dots[2]);
        }
    }
}

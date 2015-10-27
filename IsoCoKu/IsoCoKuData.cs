using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoCoKu
{
    class IsoCoKuData
    {
        public static int[][] pinsPerTriangle = new int[][]{
            new int[]{0, 1, 2},
            new int[]{0, 2, 3},
            new int[]{0, 3, 4},
            new int[]{0, 4, 5},
            new int[]{0, 5, 1},
            new int[]{2, 6, 7},
            new int[]{3, 7, 8},
            new int[]{4, 8, 9},
            new int[]{5, 9, 10},
            new int[]{1, 10, 6},
            new int[]{6, 2, 1},
            new int[]{7, 3, 2},
            new int[]{8, 4, 3},
            new int[]{9, 5, 4},
            new int[]{10, 1, 5},
            new int[]{11, 7, 6},
            new int[]{11, 8, 7},
            new int[]{11, 9, 8},
            new int[]{11, 10, 9},
            new int[]{11, 6, 10}
        };

        public int[] pins = new int[11];
        public Triangle[] triangles = new Triangle[20];

        public int[] dotCount = new int[12];

        public IsoCoKuData()
        {
            for (int n = 0; n < 11; n++)
            {
                pins[n] = n + 2;
            }

            SetDefaultTriangles();
        }

        public IsoCoKuData(int[] pins)
        {
            if (pins.Length == 12)
            {
                for (int n = 0; n < 11; n++)
                {
                    this.pins[n] = pins[n + 1];
                }
            }
            else this.pins = pins;

            SetDefaultTriangles();
        }

        public IsoCoKuData(int[] pins, Triangle[] triangles)
        {
            this.pins = pins;
            this.triangles = triangles;

            CountDots();
        }

        public IsoCoKuData(IsoCoKuData source)
        {
            for (int n = 0; n < 11; n++)
            {
                this.pins[n] = source.pins[n];
            }

            for (int n = 0; n < 12; n++)
            {
                this.dotCount[n] = source.dotCount[n];
            }

            for (int n = 0; n < 20; n++)
            {
                this.triangles[n] = source.triangles[n];
            }
        }

        public void swap(int triangle1, int triangle2, int rotation1, int rotation2)
        {
            RemoveDots(triangle1);
            RemoveDots(triangle2);

            Triangle buffer = triangles[triangle1];
            triangles[triangle1] = new Triangle(triangles[triangle2], rotation2);
            triangles[triangle2] = new Triangle(buffer, rotation1);

            AddDots(triangle1);
            AddDots(triangle2);
        }

        public void rotate(int triangle, int rotation)
        {
            RemoveDots(triangle);

            triangles[triangle] = new Triangle(triangles[triangle], rotation);

            AddDots(triangle);
        }

        private void SetDefaultTriangles()
        {
            for (int n = 0; n < 20; n++)
            {
                triangles[n] = new Triangle(Triangle.Triangles[n], 0);
            }

            CountDots();
        }

        private void CountDots()
        {
            for (int n = 0; n < 20; n++)
            {
                AddDots(n);
            }
        }

        private void AddDots(int triangle)
        {
            Triangle triangleinstance = triangles[triangle];

            for (int pin = 0; pin < 3; pin++)
            {
                int pinPosition = pinsPerTriangle[triangle][pin];

                dotCount[pinPosition] += triangleinstance.dots[pin];
            }
        }

        private void RemoveDots(int triangle)
        {
            Triangle triangleinstance = triangles[triangle];

            for (int pin = 0; pin < 3; pin++)
            {
                int pinPosition = pinsPerTriangle[triangle][pin];

                dotCount[pinPosition] -= triangleinstance.dots[pin];
            }
        }
    }
}

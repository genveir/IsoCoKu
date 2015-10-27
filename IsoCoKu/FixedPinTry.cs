using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoCoKu
{
    class FixedPinTry
    {
        FixedPinTryNode root = new FixedPinTryNode();

        public bool Contains(IsoCoKuData data)
        {
            int[] dotArray = new int[60];

            for (int n = 0; n < 60; n++)
            {
                dotArray[n] = data.triangles[n % 20].dots[n / 20];
            }

            return root.Contains(dotArray, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoCoKu
{
    class FixedPinTryNode
    {
        FixedPinTryNode[] children = new FixedPinTryNode[4];

        public FixedPinTryNode() { }

        public FixedPinTryNode(int[] dots, int index)
        {
            if (index != 59)
            {
                children[dots[index]] = new FixedPinTryNode(dots, index + 1);
            }
        }

        public bool Contains(int[] dots, int index)
        {
            if (index == 59) return true;

            if (children[dots[index]] == null)
            {
                children[dots[index]] = new FixedPinTryNode(dots, index + 1);
                return false;
            }
            else return children[dots[index]].Contains(dots, index + 1);
        }
    }
}

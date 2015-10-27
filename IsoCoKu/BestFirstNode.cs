using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoCoKu
{
    class BestFirstNode
    {
        public int value;
        public IsoCoKuData data;

        public BestFirstNode(IsoCoKuData data)
        {
            this.data = data;
            Evaluate();
        }

        private void Evaluate()
        {
            value = Math.Abs(data.dotCount[0] - 1);

            for (int n = 0; n < 11; n++)
            {
                value += Math.Abs(data.dotCount[n + 1] - data.pins[n]);
            }
        }

        public List<BestFirstNode> Expand(FixedPinTry fixedPinTry)
        {
            List<BestFirstNode> newNodesList = new List<BestFirstNode>();

            for (int firstTriangle = 0; firstTriangle < 20; firstTriangle++)
            {
                for (int secondTriangle = firstTriangle + 1; secondTriangle < 20; secondTriangle++)
                {
                    for (int firstRotation = 0; firstRotation < 3; firstRotation++)
                    {
                        for (int secondRotation = 0; secondRotation < 3; secondRotation++)
                        {
                            IsoCoKuData newData = new IsoCoKuData(data);
                            newData.swap(firstTriangle, secondTriangle, firstRotation, secondRotation);

                            AddToList(newNodesList, newData, fixedPinTry);
                        }
                    }
                }
            }

            for (int triangle = 0; triangle < 20; triangle++)
            {
                for (int rotation = 1; rotation < 3; rotation++)
                {
                    IsoCoKuData newData = new IsoCoKuData(data);
                    newData.rotate(triangle, rotation);

                    AddToList(newNodesList, newData, fixedPinTry);
                }
            }

            return newNodesList;
        }

        private void AddToList(List<BestFirstNode> newNodesList, IsoCoKuData newData, FixedPinTry fixedPinTry)
        {
            if (!fixedPinTry.Contains(newData))
            {
                BestFirstNode newNode = new BestFirstNode(newData);
                newNodesList.Add(newNode);
            }
        }
    }
}

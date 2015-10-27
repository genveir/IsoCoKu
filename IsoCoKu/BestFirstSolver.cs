using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IsoCoKu
{
    class BestFirstSolver
    {
        public static IsoCoKuData solution = new IsoCoKuData();

        private static ConcurrentPriorityQueue queue = new ConcurrentPriorityQueue();
        private static FixedPinTry fixedPinTry = new FixedPinTry();

        private static bool solved = false;

        public static void Solve(int[] pins)
        {
            IsoCoKuData data = new IsoCoKuData(pins);

            BestFirstNode start = new BestFirstNode(data);

            queue.Enqueue(start);

            for (int n = 0; n < 10; n++)
            {
                new Thread(Solve).Start();
            }

            while (!solved)
            {
                Thread.Sleep(30);
            }
        }

        private static void Solve()
        {
            while (!solved)
            {

                // there is always a solution, so this should be okay.
                BestFirstNode node = null;
                while (node == null)
                {
                    node = queue.Dequeue();
                    if (node == null)
                    {
                        if (solved) return;
                        Thread.Sleep(1);
                    }
                }

                List<BestFirstNode> newNodes = node.Expand(fixedPinTry);

                foreach (BestFirstNode newNode in newNodes)
                {
                    if (newNode.value == 0)
                    {
                        solved = true;
                        solution = newNode.data;
                    }
                    else
                    {
                        queue.Enqueue(newNode);
                    }
                }
            }
        }
    }
}

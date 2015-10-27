using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace IsoCoKu
{
    class ConcurrentPriorityQueue
    {
        private ConcurrentQueue<BestFirstNode>[] queues = new ConcurrentQueue<BestFirstNode>[160];

        private int length;

        public ConcurrentPriorityQueue()
        {
            for (int n = 0; n < queues.Length; n++)
            {
                queues[n] = new ConcurrentQueue<BestFirstNode>();
            }
        }

        public BestFirstNode Dequeue()
        {
            BestFirstNode node = null;

            while (node == null)
            {
                if (length > 0)
                {
                    for (int n = 0; n < queues.Length; n++)
                    {
                        if (queues[n].IsEmpty) continue;
                        else
                        {
                            queues[n].TryDequeue(out node);
                            break;
                        }
                    }
                }
                else return null;
            }

            return node;
        }

        public void Enqueue(BestFirstNode node)
        {
            queues[node.value].Enqueue(node);
            Interlocked.Increment(ref length);
        }
    }
}

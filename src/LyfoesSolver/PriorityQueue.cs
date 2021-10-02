using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
    /// <summary>
    /// priority queue. if a state has one or more copleted pipes,that state gets higher priority.
    /// it gets fast result. but not optimized (with minimum moves) result
    /// </summary>
    public class PriorityGameQueue : IGameQueue
    {
        private readonly Queue<Game>[] queues = new Queue<Game>[100];
        private int count;
        private int currentPos;
        public PriorityGameQueue()
        {
            for (int i = 0; i < 100; i++)
                queues[i] = new Queue<Game>();
        }

        public void Enqueue(Game game)
        {
            count++;
            var priority = game.Point;
            if (priority>currentPos)
                currentPos = priority;
            queues[priority].Enqueue(game);
        }

        public Game Dequeue()
        {
            count--;
            while (currentPos>=0)
            {
                if (queues[currentPos].Any())
                    return queues[currentPos].Dequeue();
                currentPos--;
            }
            return null;
        }

        public bool Any()
        {
            return count > 0;
        }
    }
}

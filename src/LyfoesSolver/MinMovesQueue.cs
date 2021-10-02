using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
    /// <summary>
    /// Queue implementation for minimum moves solution
    /// </summary>
    public class MinMovesQueue : IGameQueue
    {
        private int moves = 0;
		private readonly Queue<Game>[] queues = new Queue<Game>[100];
        public MinMovesQueue()
        {
            for (int i = 0; i < 100; i++)
                queues[i] = new Queue<Game>();
        }
        
        public bool Any()
        {
            return queues.Any(x => x.Any());
        }

        public Game Dequeue()
        {
            while (!queues[moves].Any())
                moves++;
            return queues[moves].Dequeue();
        }

        public void Enqueue(Game game)
        {
            queues[game.Moves.Sum(x=>x.Count)].Enqueue(game);
        }
    }
}

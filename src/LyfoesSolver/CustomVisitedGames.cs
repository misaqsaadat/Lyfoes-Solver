using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
    /// <summary>
    /// stores a list of visited game to check no duplicate game board add to queue.
    /// </summary>
	public class CustomVisitedGames
    {
        public List<Game>[] currentGames = new List<Game>[30];

        public CustomVisitedGames()
        {
            for (int i = 0; i < 30; i++)
                currentGames[i] = new List<Game>();
        }
        public bool Contains(Game game)
        {
            return currentGames[game.CorrectCount].Contains(game);
        }

        public void Add(Game game)
        {
            currentGames[game.CorrectCount].Add(game);
        }

        public int Count()
        {
            return currentGames.Sum(x => x.Count());
        }
    }
}

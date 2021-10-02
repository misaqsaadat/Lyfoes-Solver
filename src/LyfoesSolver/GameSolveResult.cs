using System.Collections.Generic;

namespace LyfoesSolver
{
	public class GameSolveResult
	{
		public int CheckedGames { get; set; }
		public int Depth { get; set; }
		public List<Move> Moves { get; set; }
	}
}
